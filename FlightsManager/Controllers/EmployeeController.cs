using FlightsManager.Models;
using FlightsManager.Models.Web.Employees;
using FlightsManager.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly FlightsManagerContext _context;

        public EmployeeController() 
        {
            _context = new FlightsManagerContext();
        }

        public IActionResult SignUpIndex(IndexEmployeeViewModel model)
        {
            return View(model);
        }

        public IActionResult LoginIndex(IndexEmployeeViewModel model)
        {
            return View(model);
        }

        public IActionResult SignUp() 
        {
            SignUpEmployeeViewModel model = new SignUpEmployeeViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpEmployeeViewModel model) 
        {
            if (ModelState.IsValid)
            {
                Employee emp = new Employee()
                {
                    Username = model.Username,
                    Password = HashPassword.GenerateSHA512(model.Password),
                    Email = model.Email,
                    Name = model.Name,
                    Family = model.Family,
                    Egn = model.Egn,
                    AddressId = model.AddressId,
                    PhoneNumber = model.PhoneNumber,
                    RoleId = model.RoleId
                };
                _context.Add(emp);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(SignUpIndex));
            }

            return View(model);
        }

        public IActionResult Login()
        {
            LoginEmployeeViewModel model = new LoginEmployeeViewModel();
            return View(model);
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginEmployeeViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var query = from emp in _context.Employees where emp.Username == model.Username && emp.Password == model.Password select emp;
                List<Employee> employees = await query.ToListAsync();
                return RedirectToAction(nameof(LoginIndex));
            }

            return View(model);
        }
    }
}