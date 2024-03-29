﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FlightsManager.Models.Web.Flights
{
    public class EditFlightViewModel
    {
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int Id { get; set; }
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
