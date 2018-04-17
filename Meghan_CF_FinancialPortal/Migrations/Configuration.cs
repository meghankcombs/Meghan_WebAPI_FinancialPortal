namespace Meghan_CF_FinancialPortal.Migrations
{
    using Meghan_CF_FinancialPortal.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Meghan_CF_FinancialPortal.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Meghan_CF_FinancialPortal.Models.ApplicationDbContext context)
        {
            #region Categories
            context.Categories.AddOrUpdate(
                c => c.Name,
                new Category { Id = 100, Name = "Auto" },
                new Category { Id = 200, Name = "Bills & Utilities" },
                new Category { Id = 300, Name = "Entertainment" },
                new Category { Id = 400, Name = "Food & Dining" },
                new Category { Id = 500, Name = "Home" },
                new Category { Id = 600, Name = "Kids" },
                new Category { Id = 700, Name = "Misc Expenses" },
                new Category { Id = 800, Name = "Taxes" },
                new Category { Id = 900, Name = "Travel" }
                );
            #endregion
        }
    }
}
