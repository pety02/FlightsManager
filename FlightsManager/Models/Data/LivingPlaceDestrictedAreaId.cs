using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models.Data
{
    public partial class LivingPlaceDestrictedAreaId
    {
        public int Id { get; set; }
        public int LivingPlaceId { get; set; }
        public int DestrictedAreaId { get; set; }

        public virtual DestrictedArea DestrictedArea { get; set; }
        public virtual LivingPlace LivingPlace { get; set; }
    }
}
