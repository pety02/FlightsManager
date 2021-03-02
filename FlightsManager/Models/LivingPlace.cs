using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models
{
    public partial class LivingPlace
    {
        public LivingPlace()
        {
            Addresses = new HashSet<Address>();
            CountryLivingPlaces = new HashSet<CountryLivingPlace>();
            LivingPlaceDestrictedAreaIds = new HashSet<LivingPlaceDestrictedAreaId>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<CountryLivingPlace> CountryLivingPlaces { get; set; }
        public virtual ICollection<LivingPlaceDestrictedAreaId> LivingPlaceDestrictedAreaIds { get; set; }
    }
}
