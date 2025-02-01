namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.FinalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.FinalContext context)
        {
            //for (int i = 1; i <= 5; i++) {
            //    context.Categories.Add(new EF.Tables.Category() { 
                
            //        Name = "C"+i
            //    });
            //}
            //context.SaveChanges();
            //Random rand = new Random();

            //for (int i = 1; i <= 100; i++) {
            //    context.Products.Add(new EF.Tables.Product
            //    {
            //        Name = "Pro"+i,
            //        Price = 23,
            //        Qty = rand.Next(50,251),
            //        CatId = rand.Next(1,6)
            //    });
            //}
            //context.SaveChanges();
        }
    }
}
