using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HotelRestApi.Models;

namespace HotelRestApi.DTO
{
    public class GuestDto
    {
        public GuestDto()
        {
            this.Reservations = new List<ReservationGuest>();
        }

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public string PostalCode { get; set; }

        public string Telephone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public List<ReservationGuest> Reservations { get; set; }

        public static GuestDto CreateGuestDto(Guest guest, bool addReservations = false)
        {
            var dto = new GuestDto();
            dto.Id = guest.Id;
            dto.FirstName = guest.FirstName;
            dto.LastName = guest.LastName;
            dto.Address = guest.Address;
            dto.BirthDate = guest.BirthDate;
            dto.City = guest.City;
            dto.Email = guest.Email;
            dto.PostalCode = guest.PostalCode;
            dto.Telephone = guest.Telephone;

            if (addReservations == true)
            {
                dto.Reservations = guest.GuestReservations.ToList();
            }

            return dto;
        }

        public static List<Guest> CreateManyGuests(List<GuestDto> guestsDto)
        {
            var guests = new List<Guest>();
            foreach (var guestDto in guestsDto)
            {
                var guest = CreateGuest(guestDto);
                guests.Add(guest);
            }

            return guests;
        }

        public static Guest CreateGuest(GuestDto guestDto)
        {
            var guest = new Guest();
            guest.Id = guestDto.Id;
            guest.FirstName = guestDto.FirstName;
            guest.LastName = guestDto.LastName;
            guest.Address = guestDto.Address;
            guest.BirthDate = guestDto.BirthDate;
            guest.City = guestDto.City;
            guest.Email = guestDto.Email;
            guest.PostalCode = guestDto.PostalCode;
            guest.Telephone = guestDto.Telephone;

            return guest;
        }

        public static List<GuestDto> CreateManyGuestDto(List<Guest> guests)
        {
            var guestsDto = new List<GuestDto>();
            foreach (var guest in guests)
            {
                var dto = CreateGuestDto(guest);
                guestsDto.Add(dto);
            }

            return guestsDto;
        }
    }


}