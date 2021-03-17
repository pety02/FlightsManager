using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Web.Flights
{
    public class IndexFlightViewModel
    {
        public PagerViewModel Pager { get; set; }
        public List<FlightViewModel> Items { get; set; }
    }
}