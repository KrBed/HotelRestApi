using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using HotelApi.DAL;
using HotelRestApi.Controllers;
using HotelRestApi.Models;

namespace HotelRestApi.Repositories
{
    public class GuestRepository
    {
        private HotelContext _context;

        public GuestRepository()
        {
            this._context = new HotelContext();
        }

        public IEnumerable<Guest> FindAllByFilter(Expression<Func<Guest, bool>> filter)
        {
            return _context.Guests.Where(filter);
        }
    }
}