using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Meghan_CF_FinancialPortal.Models;
using Meghan_CF_FinancialPortal.Models.Helpers;
using Microsoft.AspNet.Identity;

namespace Meghan_CF_FinancialPortal.Controllers
{
    public class PersonalAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PersonalAccounts
        public ActionResult Index()
        {
            var personalAccounts = db.PersonalAccounts.Include(p => p.CreatedBy).Include(p => p.Household);
            return View(personalAccounts.ToList());
        }

        // GET: PersonalAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalAccount personalAccount = db.PersonalAccounts.Find(id);
            if (personalAccount == null)
            {
                return HttpNotFound();
            }

            //Math
            var debits = personalAccount.Transactions.Where(t => t.Type == false).Sum(t => t.Amount);
            ViewBag.Balance = (personalAccount.Balance - debits);

            var credits = personalAccount.Transactions.Where(t => t.Type == true).Sum(t => t.Amount);
            ViewBag.Balance += credits;

            var dtrx = personalAccount.Transactions.Where(t => t.Type == false && t.Reconciled == true).Sum(t => t.Amount);
            ViewBag.RecBalance = (personalAccount.Balance - dtrx);

            var ctrx = personalAccount.Transactions.Where(t => t.Type == true && t.Reconciled == true).Sum(t => t.Amount);
            ViewBag.RecBalance += ctrx;

            return View(personalAccount);
        }

        // GET: PersonalAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalAccounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Balance,ReconciledBalance,IsDeleted")] PersonalAccount personalAccount)
        {
            if (ModelState.IsValid)
            {
                personalAccount.HouseholdId = HttpContext.User.Identity.GetHouseholdId().Value;
                var user = db.Users.Find(User.Identity.GetUserId());
                personalAccount.CreatedById = user.Id;
                personalAccount.IsDeleted = false;
                db.PersonalAccounts.Add(personalAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personalAccount);
        }

        // GET: PersonalAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalAccount personalAccount = db.PersonalAccounts.Find(id);
            if (personalAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReturnUrl = Request.UrlReferrer;
            return View(personalAccount);
        }

        // POST: PersonalAccounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,ReconciledBalance,IsDeleted")] PersonalAccount personalAccount, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //how to handle is deleted?
                db.Entry(personalAccount).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(returnUrl);
            }
            return View(personalAccount);
        }

        // GET: PersonalAccounts/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PersonalAccount personalAccount = db.PersonalAccounts.Find(id);
        //    if (personalAccount == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(personalAccount);
        //}

        // POST: PersonalAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonalAccount personalAccount = db.PersonalAccounts.Find(id);
            db.PersonalAccounts.Remove(personalAccount);
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
