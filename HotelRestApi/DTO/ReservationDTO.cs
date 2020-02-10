using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using HotelRestApi.Models;

namespace HotelRestApi.DTO
{
    public class ReservationDto
    {
        public ReservationDto()
        {
            this.Guests = new List<GuestDto>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string ReservationCode { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime BookInDate { get; set; }
        [Required]
        public DateTime BookOutDate { get; set; }
        [Required]
        public string Currency { get; set; }

        public double? Commission { get; set; }

        public string Source { get; set; }

        public List<GuestDto> Guests { get; set; }

        public static ReservationDto CreateReservationDto(Reservation reservation, List<GuestDto> guests = null)
        {
            var dto = new ReservationDto();

            dto.BookInDate = reservation.BookInDate;
            dto.BookOutDate = reservation.BookOutDate;
            dto.Commission = reservation.Commission;
            dto.CreationDate = reservation.CreationDate;
            dto.Currency = reservation.Currency;
            dto.Id = reservation.Id;
            dto.Price = reservation.Price;
            dto.ReservationCode = reservation.ReservationCode;
            dto.Source = reservation.Source;
            if (guests != null)
            {
                dto.Guests = guests;

            }

            return dto;
        }

        public static Reservation CreateReservation(ReservationDto reservationDto)
        {
            var reservation = new Reservation();

            reservation.BookInDate = reservationDto.BookInDate;
            reservation.BookOutDate = reservationDto.BookOutDate;
            reservation.Commission = reservationDto.Commission;
            reservation.CreationDate = reservationDto.CreationDate;
            reservation.Currency = reservationDto.Currency;
            reservation.Id = reservationDto.Id;
            reservation.Price = reservationDto.Price;
            reservation.ReservationCode = reservationDto.ReservationCode;
            reservation.Source = reservationDto.Source;

            var guests = new List<ReservationGuest>();

            foreach (var guestDto in reservationDto.Guests)
            {
                guests.Add(new ReservationGuest() {Guest = GuestDto.CreateGuest(guestDto)});
            }

            reservation.ReservationsGuests = guests;

            return reservation;
        }

        public static List<ReservationDto> CreateManyReservationDto(IEnumerable<Reservation> reservations)
        {
            var reservationsDto = new List<ReservationDto>();
            foreach (var reservation in reservations)
            {
                var dto = CreateReservationDto(reservation);
                dto.Guests =
                    GuestDto.CreateManyGuestDto(reservation.ReservationsGuests.Select(rg => rg.Guest).ToList());
                reservationsDto.Add(dto);
            }

            return reservationsDto;
        }

       

    }
}