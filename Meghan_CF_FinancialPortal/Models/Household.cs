using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meghan_CF_FinancialPortal.Models
{
    public class Household
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<ApplicationUser> Members { get; set; }
        public virtual ICollection<PersonalAccount> PersonalAccounts { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<Invite> Invites { get; set; }

        public Household()
        {
            Categories = new HashSet<Category>();
            Members = new HashSet<ApplicationUser>();
            Budgets = new HashSet<Budget>();
            PersonalAccounts = new HashSet<PersonalAccount>();
        }
    }
}