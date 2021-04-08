using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Web.Reservation
{
    public class ReservationViewModel
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public int TicketId { get; set; }
    }
}
