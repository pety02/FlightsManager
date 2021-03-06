using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models
{
    public partial class CountryLivingPlace
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int LivingPlaceId { get; set; }

        public virtual Continent Country { get; set; }
        public virtual LivingPlace LivingPlace { get; set; }
    }
}
