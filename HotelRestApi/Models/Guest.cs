using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelRestApi.Models
{
    public class Guest
    {
        public Guest()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public DateTime? BirthDate { get; set; }

        public string PostalCode { get; set; }
       

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}