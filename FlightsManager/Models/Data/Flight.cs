using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int LocationFromId { get; set; }
        public int LocationToId { get; set; }
        public DateTime TakeOffDateTime { get; set; }
        public DateTime LandingDateTime { get; set; }
        public int PlaneId { get; set; }

        public virtual Address LocationFrom { get; set; }
        public virtual Address LocationTo { get; set; }
        public virtual Plane Plane { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
