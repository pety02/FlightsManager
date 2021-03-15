using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models.Data
{
    public partial class Plane
    {
        public Plane()
        {
            Flights = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public string UniquePlaneNumber { get; set; }
        public int PlaneTypeId { get; set; }
        public int PilotId { get; set; }
        public int PassagerCapacity { get; set; }
        public int BussinessClassCapacity { get; set; }

        public virtual Employee Pilot { get; set; }
        public virtual PlaneType PlaneType { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
