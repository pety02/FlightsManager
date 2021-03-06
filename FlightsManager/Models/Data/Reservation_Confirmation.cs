using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models
{
    public class Reservation_Confirmation
    {
        public Reservation_Confirmation()
        {
            
        }

        public int Id { get; set; }
        public int ReservationId { get; set; }
        public string Email { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
