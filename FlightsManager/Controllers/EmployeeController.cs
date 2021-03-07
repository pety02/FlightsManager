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

        public IActionResult SignUpForm() 
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
                Country lastCountry = _context.Countries.Last();
                Country countr = new Country()
                {
                    Id = lastCountry.Id + 1,
                    Name = model.Country,
                    ContinentId = model.ContinentId
                };
                _context.Countries.Add(countr);
                _context.SaveChanges();
                LivingPlace lastLivingPlace = _context.LivingPlaces.Last();
                LivingPlace lP = new LivingPlace()
                {
                    Id = lastLivingPlace.Id + 1,
                    Name = model.LivingArea
                };
                _context.LivingPlaces.Add(lP);
                _context.SaveChanges();
                DestrictedArea lastDestrictedArea = _context.DestrictedAreas.Last();
                DestrictedArea dA = new DestrictedArea()
                {
                    Id = lastDestrictedArea.Id + 1,
                    Name = model.DestrictedArea
                };
                _context.DestrictedAreas.Add(dA);
                _context.SaveChanges();
                Street lastStreet = _context.Streets.Last();
                Street str = new Street() 
                { 
                    Id = lastStreet.Id + 1,
                    Name = model.Street
                };
                _context.Streets.Add(str);
                _context.SaveChanges();
                Address lastAddress = _context.Addresses.Last();
                Address addr = new Address()
                {
                    Id = lastAddress.Id + 1,
                    ContitnetId = model.ContinentId,
                    CountryId = countr.Id,
                    LivingPlaceId = lP.Id,
                    DestrictedAreaId = dA.Id,
                    StreetId = str.Id,
                    Number = model.Number,
                    Floor = model.Floor,
                    Apartament = model.Apartament,
                    AddressTypeId = 1
                };
                _context.Addresses.Add(addr);
                _context.SaveChanges();
                Employee lastEmployee = _context.Employees.Last();
                Employee emp = new Employee()
                {
                    Id = lastEmployee.Id + 1,
                    Username = model.Username,
                    Password = HashPassword.GenerateSHA512(model.Password),
                    Email = model.Email,
                    Name = model.Name,
                    Family = model.Family,
                    Egn = model.Egn,
                    AddressId = addr.Id,
                    PhoneNumber = model.PhoneNumber,
                    RoleId = model.RoleId
                };
                _context.Add(emp);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(SignUp));
            }

            return View(model);
        }

        public IActionResult SignUp(IndexEmployeeViewModel model)
        {
            return View(model);
        }

        public IActionResult LoginForm()
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
                Employee employee = employees[0];
                EmployeeViewModel empViewModel = new EmployeeViewModel()
                { 
                    Id = employee.Id,
                    Name = employee.Name,
                    Family = employee.Family,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    Username = employee.Username,
                    Password = employee.Password,
                    AddressId = employee.AddressId,
                    RoleId = employee.RoleId
                };
                IndexEmployeeViewModel indexEVM = turnEmployeeViewModelToIntexEmployeeViewModel(empViewModel);
                return Login(indexEVM);

                //return RedirectToAction(nameof(Login));
            }

            return View(model);
        }

        public IActionResult Login(IndexEmployeeViewModel model)
        {

            return View(model);
        }

        private IndexEmployeeViewModel turnEmployeeViewModelToIntexEmployeeViewModel(EmployeeViewModel evm) 
        {
            List<EmployeeViewModel> evms = new List<EmployeeViewModel>();
            evms.Add(evm);
            return new IndexEmployeeViewModel()
            {
                Items = evms
            };
        }
    }
}