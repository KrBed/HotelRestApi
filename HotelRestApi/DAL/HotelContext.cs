using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HotelRestApi.Models;

namespace HotelApi.DAL
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<HotelContext>(new DropCreateDatabaseIfModelChanges<HotelContext>());
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Guest> Guests { get; set; }
    }
}