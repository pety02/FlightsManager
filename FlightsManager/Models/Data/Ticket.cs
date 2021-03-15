using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models.Data
{
    public partial class Ticket
    {
        public Ticket()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public int FlightId { get; set; }
        public int TicketTypeId { get; set; }
        public decimal Price { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual TicketType TicketType { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
