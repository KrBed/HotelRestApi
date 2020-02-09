using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HotelRestApi.DTO;
using HotelRestApi.Models;
using HotelRestApi.Repositories;

namespace HotelRestApi.Controllers
{
    public class GuestsController : ApiController
    {
        private GuestRepository _guestRepo = null; 
        
        public GuestsController()
        {
            _guestRepo = new GuestRepository();
        }

        // GET: api/guests
        public IHttpActionResult Get([FromUri]string name ="Piotr" , string city="")
        {
            var guests = new List<Guest>();

            if (String.IsNullOrEmpty(city))
            {
                guests = _guestRepo.FindAllByFilter(x => x.FirstName == name).ToList();
            }
            else
            {
                guests = _guestRepo.FindAllByFilter(x => x.FirstName == name && x.City == city).ToList();
            }

            if (!guests.Any())
            {
                return NotFound();
            }

            var guestsDto = GuestDto.CreateManyGuestDto(guests);

            return Ok(guestsDto);
        }

    }
}
