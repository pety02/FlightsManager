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
        [RegularExpression("[a-z]{3,}[0-9]{1,}")]
        public string Username { get; set; }
        [Required]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,20}$")]
        public string Password { get; set; }
        [Required]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,20}$")]
        [Compare(nameof(Password))]
        public string ReEnteredPassword { get; set; }
        [Required]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
        public string Email { get; set; }
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]{1,}")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]{1,}")]
        public string Family { get; set; }
        [Required]
        [RegularExpression("[0-9]{10}")]
        public string Egn { get; set; }
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int ContinentId { get; set; }
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]{1,}")]
        public string Country { get; set; }
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]{1,}")]
        public string LivingArea { get; set; }
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]{1,}")]
        public string DestrictedArea { get; set; }
        [Required]
        [RegularExpression("[A-Z]{1}[a-z]{1,}")]
        public string Street { get; set; }
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int Number { get; set; }
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int Floor { get; set; }
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int Apartament { get; set; }
        [Required]
        [RegularExpression("((\\+359)|0)[0-9]{9}")]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression("[0-9]{1,}")]
        public int RoleId { get; set; }
    }
}
