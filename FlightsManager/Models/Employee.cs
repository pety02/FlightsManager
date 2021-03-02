using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace FlightsManager.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Planes = new HashSet<Plane>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^((?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9]) | (?=.*?[A - Z])(?=.*?[a - z])(?=.*?[^a - zA - Z0 - 9]) | (?=.*?[A - Z])(?=.*?[0 - 9])(?=.*?[^a - zA - Z0 - 9]) | (?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[^a - zA - Z0 - 9])).{8,}$")]
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Egn { get; set; }
        public int AddressId { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }

        public virtual EmployeeRole Role { get; set; }
        public virtual ICollection<Plane> Planes { get; set; }
    }
}
