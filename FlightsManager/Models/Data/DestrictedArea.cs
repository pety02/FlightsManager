using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models.Data
{
    public partial class DestrictedArea
    {
        public DestrictedArea()
        {
            Addresses = new HashSet<Address>();
            DestrictedAreaStreets = new HashSet<DestrictedAreaStreet>();
            LivingPlaceDestrictedAreaIds = new HashSet<LivingPlaceDestrictedArea>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<DestrictedAreaStreet> DestrictedAreaStreets { get; set; }
        public virtual ICollection<LivingPlaceDestrictedArea> LivingPlaceDestrictedAreaIds { get; set; }
    }
}
