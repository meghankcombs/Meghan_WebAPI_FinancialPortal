﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Meghan_CF_FinancialPortal.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Household> Households { get; set; }
    }
}