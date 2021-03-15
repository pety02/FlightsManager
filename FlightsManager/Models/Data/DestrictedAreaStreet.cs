using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models.Data
{
    public partial class DestrictedAreaStreet
    {
        public int Id { get; set; }
        public int DestrictedAreaId { get; set; }
        public int StreetId { get; set; }

        public virtual DestrictedArea DestrictedArea { get; set; }
        public virtual Street Street { get; set; }
    }
}
