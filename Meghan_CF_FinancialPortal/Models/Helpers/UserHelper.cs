using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meghan_CF_FinancialPortal.Models.Helpers
{
    public class UserHelper
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static string UserFirstName() //logged in user's first name
        {
            if (HttpContext.Current.User != null)
            {
                var userId = HttpContext.Current.User.Identity.GetUserId();
                var userFName = db.Users.FirstOrDefault(n => n.Id == userId).FirstName;
                return (userFName);
            }
            return "";
        }

        public static string UserLastName() //logged in user's last name
        {
            if (HttpContext.Current.User != null)
            {
                var userId = HttpContext.Current.User.Identity.GetUserId();
                var userLName = db.Users.FirstOrDefault(n => n.Id == userId).LastName;
                return (userLName);
            }
            return "";
        }

        public bool InHousehold(string userId, int householdId) //Check if user is in household already
        {
            return db.Households.Find(householdId).Members.Any(u => u.Id == userId);
        }
    }
}