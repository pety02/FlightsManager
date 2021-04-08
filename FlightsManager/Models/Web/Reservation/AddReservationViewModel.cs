using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Web.Reservation
{
    public class AddReservationViewModel
    {
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ReservationDate { get; set; }
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int FlightId { get; set; }
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]{1,}")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]{1,}")]
        public string SecondName { get; set; }
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]{1,}")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("[0-9]{10}")]
        public string EGN { get; set; }
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int NationalityId { get; set; }
        [Required]
        [RegularExpression("((\\+359)|0)[0-9]{9}")]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int TicketTypeId { get; set; }
    }
}
