using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Meghan_CF_FinancialPortal.Models;
using Meghan_CF_FinancialPortal.Models.Helpers;
using Meghan_CF_FinancialPortal.Models.ViewModels;
using Microsoft.AspNet.Identity;

namespace Meghan_CF_FinancialPortal.Controllers
{
    public class HouseholdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private HouseholdHelper househldHelper = new HouseholdHelper();
        private UserHelper userHelper = new UserHelper();

        // GET: Households
        public ActionResult Index()
        {
            return View(db.Households.ToList());
        }

        // GET: Households/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // GET: Households/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Households/Create
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(HouseholdViewModel vm)
        {
            //Create new household
            Household household = new Household();

            //check if name is unique
            if (househldHelper.IsUnique(household.Name) == true)
            {
                household.Name = vm.HouseholdName;
            }
            else
            {
                TempData["NameNotUnique"] = "The Household name you entered is not unique. Please enter a different name.";
                return RedirectToAction("Create"); //bring create household view back up...
            }

            // add household to database
            db.Households.Add(household);
            db.SaveChanges();

            //Add the current user as the first member of the new household
            var user = db.Users.Find(User.Identity.GetUserId());
            household.Members.Add(user);
            db.SaveChanges();
            await ControllerContext.HttpContext.RefreshAuthentication(user); //refresh thier cookies and direct them to their dashboard

            return RedirectToAction("Index", "Home");
        }

        // GET: Households/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Entry(household).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(household);
        }

        //GET : Invite
        public ActionResult Invite()
        {
            return View();
        }

        //POST: INVITE
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Invite(string email)
        {
            var code = Guid.NewGuid();
            var callbackUrl = Url.Action("CreateJoinHousehold", "Home", new { code }, protocol: Request.Url.Scheme);

            //send email
            var from = "Financial Portal<meghankcombs@gmail.com>";
            var to = email;
            var sendEmail = new MailMessage(from, to)
            {
                Subject = "Financial Portal: Household Invite",
                Body = "You have been invited to a household! Click here to join: " + callbackUrl,
                IsBodyHtml = true
            };
            var svc = new PersonalEmail();
            await svc.SendAsync(sendEmail);

            //create invite record
            Invite model = new Invite();
            model.Email = email;
            model.HHToken = code;
            model.HouseholdId = User.Identity.GetHouseholdId().Value;
            model.InviteDate = DateTimeOffset.Now;
            model.InvitedById = User.Identity.GetUserId();

            db.Invites.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        //POST: Leave Household
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> LeaveHousehold(int householdId)
        {
            //already in household details view, so can get household id through route values and pass in here
            Household household = db.Households.Find(householdId); //find household by id passed in
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId()); //get user's id
            household.Members.Remove(user);
            db.SaveChanges();

            await ControllerContext.HttpContext.RefreshAuthentication(user); //method in extensions class
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RemoveUserFromHousehold(string userId) //remove user from Household
        {
            var householdId = HttpContext.User.Identity.GetHouseholdId().Value;
            if (userHelper.InHousehold(userId, householdId))
            {
                Household household = db.Households.Find(householdId);
                var delUser = db.Users.Find(userId);

                household.Members.Remove(delUser);
                db.Entry(household).State = EntityState.Modified; //modifies existing Household record
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Households/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Household household = db.Households.Find(id);
            db.Households.Remove(household);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
