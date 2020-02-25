using HotelRestApi.DAL;

namespace HotelRestApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelApi.DAL.HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(HotelApi.DAL.HotelContext context)
        {
            FakeData.SeedData(context);
        }
    }
}
