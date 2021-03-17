using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Web.Flights
{
    public class AddFlightViewModel
    {
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int LocationFromId { get; set; }
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int LocationToId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TakeOffDateTime { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LandingDateTime { get; set; }
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int PlaneId { get; set; }
    }
}
