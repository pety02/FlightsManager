using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Web.Employees
{
    public class SignUpEmployeeViewModel
    {
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [MinLength(8), MaxLength(20)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,20}$")]
        public string Password { get; set; }
        [Required]
        [MinLength(8), MaxLength(20)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,20}$")]
        [Compare(nameof(Password))]
        public string ReEnteredPassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Family { get; set; }
        [Required]
        public string Egn { get; set; }
        [Required]
        public int ContinentId { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string LivingArea { get; set; }
        [Required]
        public string DestrictedArea { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int Apartament { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
