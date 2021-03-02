﻿using System;
using System.Collections.Generic;

#nullable disable

namespace FlightsManager.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Planes = new HashSet<Plane>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
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
