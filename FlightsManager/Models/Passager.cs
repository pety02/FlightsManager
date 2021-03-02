using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models
{
    public partial class Passager
    {
        public Passager()
        {
            ReservationPassagers = new HashSet<ReservationPassager>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Egn { get; set; }
        public string PhoneNumber { get; set; }
        public int NationalityId { get; set; }

        public virtual Nationality Nationality { get; set; }
        public virtual ICollection<ReservationPassager> ReservationPassagers { get; set; }
    }
}
