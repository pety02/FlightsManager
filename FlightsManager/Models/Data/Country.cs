using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models.Data
{
    public partial class Country
    {
        public Country()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
