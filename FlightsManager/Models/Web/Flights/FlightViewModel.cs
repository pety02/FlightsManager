using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Web.Flights
{
    public class FlightViewModel
    {
        public int Id { get; set; }
        public int LocationFromId { get; set; }
        public int LocationToId { get; set; }
        public DateTime TakeOffDateTime { get; set; }
        public DateTime LandingDateTime { get; set; }
        public int PlaneId { get; set; }
    }
}
