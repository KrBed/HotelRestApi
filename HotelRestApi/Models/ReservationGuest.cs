using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRestApi.Models
{
    public class ReservationGuest
    {
        [Key]
        [Column(Order = 1)]
        public int ReservationId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int GuestId { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual Guest Guest { get; set; }
    }
}