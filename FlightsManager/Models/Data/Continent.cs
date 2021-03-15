using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models.Data
{
    public partial class Continent
    {
        public Continent()
        {
            Addresses = new HashSet<Address>();
            Countries = new HashSet<Country>();
            CountryLivingPlaces = new HashSet<CountryLivingPlace>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Country> Countries { get; set; }
        public virtual ICollection<CountryLivingPlace> CountryLivingPlaces { get; set; }
    }
}
