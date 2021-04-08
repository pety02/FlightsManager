using FlightsManager.Models.Web.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Web.Reservation
{
    public class IndexReservationViewModel
    {
        public PagerViewModel Pager { get; set; }
        public List<ReservationViewModel> Items { get; set; }
    }
}
