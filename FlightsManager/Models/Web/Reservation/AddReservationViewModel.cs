using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Web.Reservation
{
    public class AddReservationViewModel
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public int FlightId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }
        public int NationalityId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int TicketTypeId { get; set; }
    }
}
