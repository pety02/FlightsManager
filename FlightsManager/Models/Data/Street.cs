using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models.Data
{
    public partial class Street
    {
        public Street()
        {
            Addresses = new HashSet<Address>();
            DestrictedAreaStreets = new HashSet<DestrictedAreaStreet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<DestrictedAreaStreet> DestrictedAreaStreets { get; set; }
    }
}
