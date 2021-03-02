using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models
{
    public partial class Nationality
    {
        public Nationality()
        {
            Passagers = new HashSet<Passager>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Passager> Passagers { get; set; }
    }
}
