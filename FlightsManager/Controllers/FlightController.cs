﻿using FlightsManager.Models.Data;
using FlightsManager.Models.Web.Flights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsManager.Controllers
{
    public class FlightController : Controller
    {
        private const int PageSize = 10;
        private readonly FlightsManagerContext _context;
        public List<Tuple<int, List<string>>> passagerNames = new List<Tuple<int, List<string>>>();

        public FlightController()
        {
            _context = new FlightsManagerContext();
        }

        public async Task<IActionResult> AdminIndex(IndexFlightViewModel model)
        {
            model.Pager = new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<FlightViewModel> items = await _context.Flights.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new FlightViewModel()
            {
                Id = c.Id,
                LocationFromId = c.LocationFromId,
                LocationToId = c.LocationToId,
                TakeOffDateTime = c.TakeOffDateTime,
                LandingDateTime = c.LandingDateTime,
                PlaneId = c.PlaneId

            }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(_context.Flights.Count() / (double)PageSize);

            //////////////////// check for logged in employee -> admin
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = await (from emp in _context.Employees where 
                                                      emp.Id == employeeId select emp).ToListAsync();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    return View(model);
                }
                else if(employeeId != 1 && employeeId > 0)
                {
                    List<Employee> employees = await (from emp in _context.Employees 
                                                      where emp.Id == employeeId select emp).ToListAsync();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                return RedirectToAction(nameof(Index));
            }
            ///////////////////////////////////////////////////////////////
        }

        public async Task<IActionResult> Index(IndexFlightViewModel model)
        {
            model.Pager = new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<FlightViewModel> items = await _context.Flights.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new FlightViewModel()
            {
                Id = c.Id,
                LocationFromId = c.LocationFromId,
                LocationToId = c.LocationToId,
                TakeOffDateTime = c.TakeOffDateTime,
                LandingDateTime = c.LandingDateTime,
                PlaneId = c.PlaneId

            }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(_context.Flights.Count() / (double)PageSize);

            //////////////////// check for logged in employee -> admin 
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    Employee employee = _context.Employees.Find(employeeId);
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    return RedirectToAction(nameof(AdminIndex));
                }
                else if (employeeId != 1 && employeeId > 0)
                {
                    Employee employee = _context.Employees.Find(employeeId); ;
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = false;

                    return View(model);
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    return View(model);
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                return View(model);
            }
            ///////////////////////////////////////////////////////////////
        }

        public IActionResult Create()
        {
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                     where
                      emp.Id == employeeId
                                                     select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    AddFlightViewModel model = new AddFlightViewModel();

                    List<Plane> planes = (from p in _context.Planes select p).ToList();
                    ViewData["allPlanes"] = planes;

                    return View(model);
                }
                else if (employeeId != 1 && employeeId > 0)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                     where emp.Id == employeeId
                                                     select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                return RedirectToAction(nameof(Index));
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddFlightViewModel model)
        {
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                where
                 emp.Id == employeeId
                                                select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    if (ModelState.IsValid)
                    {
                        int id = _context.Flights.Max(f => f.Id);
                        Flight flight = new Flight
                        {
                            Id = id + 1,
                            LocationFromId = model.LocationFromId,
                            LocationToId = model.LocationToId,
                            TakeOffDateTime = model.TakeOffDateTime,
                            LandingDateTime = model.LandingDateTime,
                            PlaneId = model.PlaneId
                        };

                        _context.Flights.Add(flight);
                        await _context.SaveChangesAsync();

                        passagerNames.Add(new Tuple<int, List<string>>(flight.Id, new List<string>()));

                        return RedirectToAction(nameof(Index));
                    }

                    return View(model);
                }
                else if (employeeId != 1 && employeeId > 0)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                where emp.Id == employeeId
                                                select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                where
                 emp.Id == employeeId
                                                select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    if (id == null)
                    {
                        return NotFound();
                    }

                    Flight flight = await _context.Flights.FindAsync(id);

                    if (flight == null)
                    {
                        return NotFound();
                    }

                    EditFlightViewModel model = new EditFlightViewModel
                    {
                        LocationFromId = flight.LocationFromId,
                        LocationToId = flight.LocationToId,
                        TakeOffDateTime = flight.TakeOffDateTime,
                        LandingDateTime = flight.LandingDateTime,
                        PlaneId = flight.PlaneId
                    };

                    List<Plane> planes = (from p in _context.Planes select p).ToList();

                    ViewData["locationFrom"] = _context.Addresses.Find(flight.LocationFromId);
                    ViewData["locationTo"] = _context.Addresses.Find(flight.LocationToId);
                    ViewData["plane"] = _context.Planes.Find(flight.PlaneId);
                    ViewData["flight"] = _context.Flights.Find(flight.Id);
                    ViewData["allPlanes"] = planes;

                    return View(model);
                }
                else if (employeeId != 1 && employeeId > 0)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                where emp.Id == employeeId
                                                select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditFlightViewModel model)
        {
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                where
                 emp.Id == employeeId
                                                select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    if (ModelState.IsValid)
                    {
                        Flight flight = new Flight
                        {
                            Id = model.Id,
                            LocationFromId = model.LocationFromId,
                            LocationToId = model.LocationToId,
                            TakeOffDateTime = model.TakeOffDateTime,
                            LandingDateTime = model.LandingDateTime,
                            PlaneId = model.PlaneId
                        };

                        try
                        {
                            _context.Update(flight);
                            await _context.SaveChangesAsync();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!IsFlightExists(flight.Id))
                            {
                                return NotFound();
                            }
                            else
                            {
                                throw;
                            }
                        }

                        return RedirectToAction(nameof(Index));
                    }

                    return View(model);
                }
                else if (employeeId != 1 && employeeId > 0)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                where emp.Id == employeeId
                                                select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                where
                 emp.Id == employeeId
                                                select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    Flight flight = await _context.Flights.FindAsync(id);
                    _context.Flights.Remove(flight);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                else if (employeeId != 1 && employeeId > 0)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                where emp.Id == employeeId
                                                select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                where
                 emp.Id == employeeId
                                                select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    Flight flight = await _context.Flights.FindAsync(id);
                    var query1 = from r in _context.Reservations where r.Id == flight.Id select r;
                    List<Reservation> reservations = query1.ToList();
                    string passagersNames = "";
                    foreach (var item in reservations)
                    {
                        string del = " ";
                        foreach (var item2 in passagerNames)
                        {
                            if (item2.Item1.Equals(flight.Id))
                            {
                                List<string> names = item2.Item2;
                                for (int i = 0; i < names.Count; i++)
                                {
                                    
                                    passagersNames += del +  names[i];
                                    del = ", ";
                                }
                            }
                            
                        }
                    }

                    ViewData["passagers"] = passagersNames;

                    return Details(flight);
                }
                else if (employeeId != 1 && employeeId > 0)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                where emp.Id == employeeId
                                                select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = false;

                    Flight flight = await _context.Flights.FindAsync(id);
                    var query1 = from r in _context.Reservations where r.Id == flight.Id select r;
                    List<Reservation> reservations = query1.ToList();
                    string passagersNames = "";
                    foreach (var item in reservations)
                    {
                        Ticket ticket = _context.Tickets.Find(item.TicketId);
                        Flight _flight = _context.Flights.Find(ticket.FlightId);
                        var query2 = from rp in _context.ReservationPassagers where rp.ResrvationId == item.Id select rp;
                        List<ReservationPassager> reservationPassagers = query2.ToList();
                        string del = " ";
                        foreach (var item2 in reservationPassagers)
                        {
                            Passager p = _context.Passagers.Find(item2.PassagerId);
                            passagersNames += del + p.FirstName + " " + p.LastName;
                            del = ", ";
                        }
                    }

                    ViewData["passagers"] = passagersNames;

                    return Details(flight);
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    Flight flight = await _context.Flights.FindAsync(id);
                    var query1 = from r in _context.Reservations where r.Id == flight.Id select r;
                    List<Reservation> reservations = query1.ToList();
                    string passagersNames = "";
                    foreach (var item in reservations)
                    {
                        string del = " ";
                        foreach (var item2 in passagerNames)
                        {
                            if (item2.Item1.Equals(flight.Id))
                            {
                                List<string> names = item2.Item2;
                                for (int i = 0; i < names.Count; i++)
                                {

                                    passagersNames += del + names[i];
                                    del = ", ";
                                }
                            }

                        }
                    }

                    ViewData["passagers"] = passagersNames;

                    return Details(flight);
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                Flight flight = await _context.Flights.FindAsync(id);
                var query1 = from r in _context.Reservations where r.Id == flight.Id select r;
                List<Reservation> reservations = query1.ToList();
                string passagersNames = "";
                foreach (var item in reservations)
                {
                    string del = " ";
                    foreach (var item2 in passagerNames)
                    {
                        if (item2.Item1.Equals(flight.Id))
                        {
                            List<string> names = item2.Item2;
                            for (int i = 0; i < names.Count; i++)
                            {

                                passagersNames += del + names[i];
                                del = ", ";
                            }
                        }

                    }
                }

                ViewData["passagers"] = passagersNames;

                return Details(flight);
            }
        }

        [NonAction]
        public ViewResult Details(Flight model)
        {
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                where
                 emp.Id == employeeId
                                                select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    ViewData["Flight"] = model;

                    Address locFrom = _context.Addresses.Find(model.LocationFromId);
                    Country countrFrom = _context.Countries.Find(locFrom.CountryId);
                    LivingPlace lpFrom = _context.LivingPlaces.Find(locFrom.LivingPlaceId);
                    ViewData["LocationFrom"] = lpFrom.Name + ", " + countrFrom.Name;

                    Address locTo = _context.Addresses.Find(model.LocationToId);
                    Country countrTo = _context.Countries.Find(locTo.CountryId);
                    LivingPlace lpTo = _context.LivingPlaces.Find(locTo.LivingPlaceId);
                    ViewData["LocationTo"] = lpTo.Name + ", " + countrTo.Name;

                    return View();
                }
                else if (employeeId != 1 && employeeId > 0)
                {
                    List<Employee> employees = (from emp in _context.Employees
                                                where emp.Id == employeeId
                                                select emp).ToList();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = false;

                    ViewData["Flight"] = model;

                    Address locFrom = _context.Addresses.Find(model.LocationFromId);
                    Country countrFrom = _context.Countries.Find(locFrom.CountryId);
                    LivingPlace lpFrom = _context.LivingPlaces.Find(locFrom.LivingPlaceId);
                    ViewData["LocationFrom"] = lpFrom.Name + ", " + countrFrom.Name;

                    Address locTo = _context.Addresses.Find(model.LocationToId);
                    Country countrTo = _context.Countries.Find(locTo.CountryId);
                    LivingPlace lpTo = _context.LivingPlaces.Find(locTo.LivingPlaceId);
                    ViewData["LocationTo"] = lpTo.Name + ", " + countrTo.Name;

                    return View();
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    ViewData["Flight"] = model;

                    Address locFrom = _context.Addresses.Find(model.LocationFromId);
                    Country countrFrom = _context.Countries.Find(locFrom.CountryId);
                    LivingPlace lpFrom = _context.LivingPlaces.Find(locFrom.LivingPlaceId);
                    ViewData["LocationFrom"] = lpFrom.Name + ", " + countrFrom.Name;

                    Address locTo = _context.Addresses.Find(model.LocationToId);
                    Country countrTo = _context.Countries.Find(locTo.CountryId);
                    LivingPlace lpTo = _context.LivingPlaces.Find(locTo.LivingPlaceId);
                    ViewData["LocationTo"] = lpTo.Name + ", " + countrTo.Name;

                    return View();
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                ViewData["Flight"] = model;

                Address locFrom = _context.Addresses.Find(model.LocationFromId);
                Country countrFrom = _context.Countries.Find(locFrom.CountryId);
                LivingPlace lpFrom = _context.LivingPlaces.Find(locFrom.LivingPlaceId);
                ViewData["LocationFrom"] = lpFrom.Name + ", " + countrFrom.Name;

                Address locTo = _context.Addresses.Find(model.LocationToId);
                Country countrTo = _context.Countries.Find(locTo.CountryId);
                LivingPlace lpTo = _context.LivingPlaces.Find(locTo.LivingPlaceId);
                ViewData["LocationTo"] = lpTo.Name + ", " + countrTo.Name;

                return View();
            }
        }

        private bool IsFlightExists(int id)
        {
            bool isExists = _context.Flights.Any(e => e.Id == id);
            return isExists;
        }

        /*[NonAction]
        private async Task<bool> IsLoggedIn(int empId) 
        {
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("id", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                List<Employee> employees = await (from emp in _context.Employees where emp.Id == employeeId select emp).ToListAsync();
                Employee employee = employees[0];
                return true;
            }
            else
            {
                return false;
            }
        }*/
    }
}