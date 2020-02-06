﻿using HotelRestApi.DAL;

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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HotelApi.DAL.HotelContext context)
        {
            context.Guests.AddRange(FakeData.SeedData());
        }
    }
}
