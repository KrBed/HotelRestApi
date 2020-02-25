using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelRestApi.DTO;
using HotelRestApi.Repositories;

namespace HotelRestApi.Controllers
{
    public class ReservationsController : ApiController
    {
        private ReservationRepository _reservationRepo = null;
        
        public ReservationsController()
        {
            this._reservationRepo = new ReservationRepository();
        }
        // GET: api/reservations
        public IHttpActionResult Get()
        {
            var reservations = _reservationRepo.GetAllWithGuests().ToList();

            var dto = ReservationDto.CreateManyReservationDto(reservations);

            return Ok(dto);
        }

        // POST: api/reservations
        [HttpPost]
        public IHttpActionResult Post([FromBody]ReservationDto reservationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            if (_reservationRepo.FindReservation(x => x.ReservationCode == reservationDto.ReservationCode) != null)
            {
                return BadRequest(String.Format("Reservation with code:{0}, already exists",reservationDto.ReservationCode));
            }

            var reservation = ReservationDto.CreateReservation(reservationDto);

            _reservationRepo.Insert(reservation);

            return Ok(Request.CreateResponse(HttpStatusCode.Created));
        }

    }
}
