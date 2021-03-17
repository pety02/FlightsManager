using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Web.Employees
{
    public class LoginEmployeeViewModel
    {
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [MinLength(8), MaxLength(20)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,20}$")]
        public string Password { get; set; }

        /*[Display(Name = "Remember me")]
        public bool RememberMe { get; set; }*/
    }
}
