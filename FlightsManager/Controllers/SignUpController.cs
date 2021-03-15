using FlightsManager.Models;
using FlightsManager.Models.Data;
using FlightsManager.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult SignUpActionResult()
        {
            return View();
        }

        public IActionResult AdminSignUp() 
        {

            Employee e = new Employee();
            e.Id = 1;
            e.Name = "Petya";
            e.Family = "Licheva";
            e.PhoneNumber = "0877294385";
            e.Email = "petya.licheva2002@abv.bg";
            e.Egn = "0211154011";
            e.AddressId = 1;
            e.Username = "Admin";
            e.Password = HashPassword.GenerateSHA512("myPass_123!");
            e.RoleId = 1;
            SignUp(e);

            return View();
        }

        public void SignUp(Employee emp) 
        {
            Employee e = emp;
            FlightsManagerContext dbContext = new FlightsManagerContext();
            dbContext.Employees.Add(e);
            dbContext.SaveChanges();
        }
    }
}
