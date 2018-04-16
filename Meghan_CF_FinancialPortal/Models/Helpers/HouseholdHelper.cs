using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meghan_CF_FinancialPortal.Models.Helpers
{
    public class HouseholdHelper
    {
        private static Household household = new Household();
        private static ApplicationDbContext db = new ApplicationDbContext();
        private static UserHelper userHelper = new UserHelper();

        public bool IsUnique(string houseName) //check to see if household name is unique when creating it
        {
            foreach (Household house in db.Households.ToList())
            {
                if (house.Name == houseName)
                {
                    return false;
                }
            }
            return true;
        }

        public void GetInviterName()
        {
            //get inviter id
            //compare to user record who sent invite
            //return their name
        }
    }
}