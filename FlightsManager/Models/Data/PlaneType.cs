using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models
{
    public partial class PlaneType
    {
        public PlaneType()
        {
            Planes = new HashSet<Plane>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Plane> Planes { get; set; }
    }
}
