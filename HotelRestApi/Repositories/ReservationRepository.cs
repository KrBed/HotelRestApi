using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HotelApi.DAL;
using HotelRestApi.Models;

namespace HotelRestApi.Repositories
{
    public class ReservationRepository
    {
        private HotelContext _context = null;

        public ReservationRepository()
        {
            _context = new HotelContext();
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public ICollection<Reservation> GetAllWithGuests()
        {
            
            return _context.Reservations.Include(r => r.ReservationsGuests.Select(rg=>rg.Guest)).ToList();
        }

        public void Insert(Reservation reservation)
        {
            var guests = reservation.ReservationsGuests.Select(rg => rg.Guest).ToList();

            reservation.ReservationsGuests.Clear();

            var savedReservation = _context.Reservations.Add(reservation);

           Save();

            var emails = guests.Select(g => g.Email).ToList();
            
            var guestsInDb = _context.Guests.Where(g => emails.Contains(g.Email)).ToList();

            foreach (var guest in guestsInDb)
            {
                if (guestsInDb.Any(x => x.Email == guest.Email))
                {
                    reservation.ReservationsGuests.Add(new ReservationGuest() { GuestId = guest.Id });
                }

                var guestToRemove = guests.FirstOrDefault(x => x.Email == guest.Email);
                guests.Remove(guestToRemove);
            }

            if (guests.Any())
            {
                foreach (var guest in guests)
                {
                    guest.GuestReservations.Add(new ReservationGuest() { ReservationId = savedReservation.Id });
                    _context.Guests.Add(guest);
                }
            }
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}