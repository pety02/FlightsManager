using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models
{
    public partial class TicketType
    {
        public TicketType()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
