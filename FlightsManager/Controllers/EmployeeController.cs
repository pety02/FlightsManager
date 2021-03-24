using FlightsManager.Models.Data;
using FlightsManager.Models.Web.Employees;
using FlightsManager.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public IActionResult SignUpForm()
        {
            SignUpEmployeeViewModel model = new SignUpEmployeeViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpEmployeeViewModel model)
        {
            Employee newEmployee = null;
            Country newCountry = null;
            LivingPlace newLivingPlace = null;
            DestrictedArea newDestrictedArea = null;
            Street newStreet = null;
            Address newAddress = null;
            CountryLivingPlace newCountryLivingPlace = null;
            LivingPlaceDestrictedArea newLivingPlaceDestrictedArea = null;
            DestrictedAreaStreet newDestrictedAreaStreet = null;

            if (ModelState.IsValid)
            {
                using (var _context = new FlightsManagerContext())
                {
                    int id = _context.Countries.Max(c => c.Id);
                    newCountry = new Country()
                    {
                        Id = id + 1,
                        Name = model.Country,
                        ContinentId = model.ContinentId
                    };
                    _context.Countries.Add(newCountry);
                    _context.SaveChanges();
                }
                using (var _context = new FlightsManagerContext())
                {
                    int id = _context.LivingPlaces.Max(l => l.Id);
                    newLivingPlace = new LivingPlace()
                    {
                        Id = id + 1,
                        Name = model.LivingArea
                    };
                    _context.LivingPlaces.Add(newLivingPlace);
                    _context.SaveChanges();
                }
                using (var _context = new FlightsManagerContext())
                {
                    int id = _context.DestrictedAreas.Max(d => d.Id);
                    newDestrictedArea = new DestrictedArea()
                    {
                        Id = id + 1,
                        Name = model.DestrictedArea
                    };
                    _context.DestrictedAreas.Add(newDestrictedArea);
                    _context.SaveChanges();
                }
                using (var _context = new FlightsManagerContext())
                {
                    int id = _context.Streets.Max(s => s.Id);
                    newStreet = new Street()
                    {
                        Id = id + 1,
                        Name = model.Street
                    };
                    _context.Streets.Add(newStreet);
                    _context.SaveChanges();
                }
                using (var _context = new FlightsManagerContext())
                {
                    int id = _context.Addresses.Max(a => a.Id);
                    newAddress = new Address()
                    {
                        Id = id + 1,
                        ContitnetId = model.ContinentId,
                        CountryId = newCountry.Id,
                        LivingPlaceId = newLivingPlace.Id,
                        DestrictedAreaId = newDestrictedArea.Id,
                        StreetId = newStreet.Id,
                        Number = model.Number,
                        Floor = model.Floor,
                        Apartament = model.Apartament,
                        AddressTypeId = 1
                    };
                    _context.Addresses.Add(newAddress);
                    _context.SaveChanges();
                }
                using (var _context = new FlightsManagerContext())
                {
                    int id = _context.CountryLivingPlaces.Max(e => e.Id);
                    newCountryLivingPlace = new CountryLivingPlace()
                    {
                        Id = id + 1,
                        CountryId = newCountry.Id,
                        LivingPlaceId = newLivingPlace.Id
                    };
                    _context.CountryLivingPlaces.Add(newCountryLivingPlace);
                    _context.SaveChanges();
                }
                using (var _context = new FlightsManagerContext())
                {
                    int id = _context.LivingPlaceDestrictedAreas.Max(e => e.Id);
                    newLivingPlaceDestrictedArea = new LivingPlaceDestrictedArea()
                    {
                        Id = id + 1,
                        LivingPlaceId = newLivingPlace.Id,
                        DestrictedAreaId = newDestrictedArea.Id
                    };
                    _context.LivingPlaceDestrictedAreas.Add(newLivingPlaceDestrictedArea);
                    _context.SaveChanges();
                }
                using (var _context = new FlightsManagerContext())
                {
                    int id = _context.DestrictedAreaStreets.Max(e => e.Id);
                    newDestrictedAreaStreet = new DestrictedAreaStreet()
                    {
                        Id = id + 1,
                        DestrictedAreaId = newDestrictedArea.Id,
                        StreetId = newStreet.Id
                    };
                    _context.DestrictedAreaStreets.Add(newDestrictedAreaStreet);
                    _context.SaveChanges();
                }
                using (var _context = new FlightsManagerContext())
                {
                    int id = _context.Employees.Max(e => e.Id);
                    newEmployee = new Employee()
                    {
                        Id = id + 1,
                        Username = model.Username,
                        Password = HashPassword.GenerateSHA512(model.Password),
                        Email = model.Email,
                        Name = model.Name,
                        Family = model.Family,
                        Egn = model.Egn,
                        AddressId = newAddress.Id,
                        PhoneNumber = model.PhoneNumber,
                        RoleId = 2
                    };
                    _context.Employees.Add(newEmployee);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(LoginForm));
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult LoginForm()
        {
            LoginEmployeeViewModel model = new LoginEmployeeViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string hashedPass = HashPassword.GenerateSHA512(model.Password);
                var query = from emp in _context.Employees where emp.Username == model.Username && emp.Password == hashedPass select emp;
                List<Employee> employees = await query.ToListAsync();
                Employee employee = employees[0];

                if (employee != null)
                {
                    HttpContext.Session.Set("empId", Encoding.UTF8.GetBytes(employee.Id.ToString()));
                    if (employee.Id == 1)
                    {
                        return RedirectToAction("AdminIndex", "Flight");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Flight");
                    }
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
 
        public IActionResult LogOut()
        {
            int empId = -1;
            HttpContext.Session.Set("empId", Encoding.UTF8.GetBytes(empId.ToString()));
            return RedirectToAction(nameof(LoginForm));
        } 
    }
}