using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            ReservationPassagers = new HashSet<ReservationPassager>();
            ReservationConfirmations = new HashSet<Reservation_Confirmation>();
        }

        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual ICollection<ReservationPassager> ReservationPassagers { get; set; }
        public virtual ICollection<Reservation_Confirmation> ReservationConfirmations { get; set; }
    }
}
