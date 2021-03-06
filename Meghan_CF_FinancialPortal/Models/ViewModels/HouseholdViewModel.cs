﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meghan_CF_FinancialPortal.Models.ViewModels
{
    public class HouseholdViewModel
    {
        public bool IsJoinHouse { get; set; }
        public int? HouseholdId { get; set; }
        public string HouseholdName { get; set; }
        public ApplicationUser Member { get; set; }
    }
}