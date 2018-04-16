using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Meghan_CF_FinancialPortal.Models
{
    public class PersonalAccount
    {
        public int Id { get; set; }
        public int HouseholdId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        [Display(Name = "Reconciled Balance")]
        public decimal ReconciledBalance { get; set; }
        public string CreatedById { get; set; }
        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; }


        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual Household Household { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }

        public PersonalAccount()
        {
            Transactions = new HashSet<Transaction>();
        }
    }
}