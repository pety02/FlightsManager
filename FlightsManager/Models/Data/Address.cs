using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models.Data
{
    public partial class Address
    {
        public Address()
        {
            FlightLocationFroms = new HashSet<Flight>();
            FlightLocationTos = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public int ContitnetId { get; set; }
        public int CountryId { get; set; }
        public int LivingPlaceId { get; set; }
        public int DestrictedAreaId { get; set; }
        public int StreetId { get; set; }
        public int Number { get; set; }
        public int? Floor { get; set; }
        public int? Apartament { get; set; }
        public int AddressTypeId { get; set; }

        public virtual AddressType AddressType { get; set; }
        public virtual Continent Contitnet { get; set; }
        public virtual Country Country { get; set; }
        public virtual DestrictedArea DestrictedArea { get; set; }
        public virtual LivingPlace LivingPlace { get; set; }
        public virtual Street Street { get; set; }
        public virtual ICollection<Flight> FlightLocationFroms { get; set; }
        public virtual ICollection<Flight> FlightLocationTos { get; set; }
    }
}
