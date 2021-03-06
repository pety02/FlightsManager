using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Web.Employees
{
    public class EmployeeViewModel
    {
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
    }
}
