using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models
{
    public partial class ReservationPassager
    {
        public int Id { get; set; }
        public int PassagerId { get; set; }
        public int ResrvationId { get; set; }

        public virtual Passager Passager { get; set; }
        public virtual Reservation Resrvation { get; set; }
    }
}
