using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HotelRestApi.Models
{
    public class Reservation
    {
        public Reservation()
        {
            this.ReservationsGuests = new HashSet<ReservationGuest>();
        }
        [Key]
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

        public virtual ICollection<ReservationGuest> ReservationsGuests { get; set; }

    }
}