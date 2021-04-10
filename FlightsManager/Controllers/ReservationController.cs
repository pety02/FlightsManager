using FlightsManager.Models.Data;
using FlightsManager.Models.Web.Reservation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using MimeKit;
using System;
using MailKit.Net.Smtp;
using System.Collections.Generic;
using System.Linq;
//using System.Net.Mail;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FlightsManager.Models.Web.Flights;
using System.Net.Mail;
using System.Net;

namespace FlightsManager.Controllers
{
    public class ReservationController : Controller
    {
        private const int PageSize = 10;
        private readonly FlightsManagerContext _context;
        private FlightController flightCtrl = new FlightController();

        public ReservationController() 
        {
            _context = new FlightsManagerContext();
        }

        public async Task<IActionResult> AdminIndex(IndexReservationViewModel model)
        {
            model.Pager = new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<ReservationViewModel> items = await _context.Reservations.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new ReservationViewModel()
            {
                Id = c.Id,
                ReservationDate = c.ReservationDate,
                TicketId = c.TicketId

            }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(_context.Reservations.Count() / (double)PageSize);

            //////////////////// check for logged in employee -> admin
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = await (from emp in _context.Employees
                                                      where
                       emp.Id == employeeId
                                                      select emp).ToListAsync();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    return View(model);
                }
                else if (employeeId != 1 && employeeId > 0)
                {
                    List<Employee> employees = await (from emp in _context.Employees
                                                      where emp.Id == employeeId
                                                      select emp).ToListAsync();
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
        public async Task<IActionResult> Index(IndexReservationViewModel model)
        {
            model.Pager = new PagerViewModel();
            model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

            List<ReservationViewModel> items = await _context.Reservations.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new ReservationViewModel()
            {
                Id = c.Id,
                ReservationDate = c.ReservationDate,
                TicketId = c.TicketId

            }).ToListAsync();

            model.Items = items;
            model.Pager.PagesCount = (int)Math.Ceiling(_context.Reservations.Count() / (double)PageSize);

            //////////////////// check for logged in employee -> admin
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = await (from emp in _context.Employees
                                                      where
                       emp.Id == employeeId
                                                      select emp).ToListAsync();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    return RedirectToAction(nameof(AdminIndex));
                }
                else if (employeeId != 1 && employeeId > 0)
                {
                    List<Employee> employees = await (from emp in _context.Employees
                                                      where emp.Id == employeeId
                                                      select emp).ToListAsync();
                    Employee employee = employees[0];
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

        public async Task<IActionResult> ReservationDateSortedAdminIndex(IndexReservationViewModel model) 
        {
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = await (from emp in _context.Employees
                                                      where
                       emp.Id == employeeId
                                                      select emp).ToListAsync();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    model.Pager = new PagerViewModel();
                    model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

                    List<ReservationViewModel> items = await _context.Reservations.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new ReservationViewModel()
                    {
                        Id = c.Id,
                        ReservationDate = c.ReservationDate,
                        TicketId = c.TicketId

                    }).OrderByDescending(it => it.ReservationDate).ToListAsync();
                    model.Items = items;

                    return View(model);
                }
                else if (employeeId != 1 && employeeId > 0)
                {
                    List<Employee> employees = await (from emp in _context.Employees
                                                      where emp.Id == employeeId
                                                      select emp).ToListAsync();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(ReservationDateSortedIndex));
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    return RedirectToAction(nameof(ReservationDateSortedIndex));
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                return RedirectToAction(nameof(ReservationDateSortedIndex));
            }
        }

        public async Task<IActionResult> ReservationDateSortedIndex (IndexReservationViewModel model) 
        {
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = await (from emp in _context.Employees
                                                      where
                       emp.Id == employeeId
                                                      select emp).ToListAsync();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;

                    return RedirectToAction(nameof(ReservationDateSortedAdminIndex));
                }
                else if (employeeId != 1 && employeeId > 0)
                {
                    List<Employee> employees = await (from emp in _context.Employees
                                                      where emp.Id == employeeId
                                                      select emp).ToListAsync();
                    Employee employee = employees[0];
                    ViewData["username"] = employee.Username;
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = false;

                    model.Pager = new PagerViewModel();
                    model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

                    List<ReservationViewModel> items = await _context.Reservations.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new ReservationViewModel()
                    {
                        Id = c.Id,
                        ReservationDate = c.ReservationDate,
                        TicketId = c.TicketId

                    }).OrderByDescending(it => it.ReservationDate).ToListAsync();
                    model.Items = items;

                    return View(model);
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    model.Pager = new PagerViewModel();
                    model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

                    List<ReservationViewModel> items = await _context.Reservations.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new ReservationViewModel()
                    {
                        Id = c.Id,
                        ReservationDate = c.ReservationDate,
                        TicketId = c.TicketId

                    }).OrderByDescending(it => it.ReservationDate).ToListAsync();
                    model.Items = items;

                    return View(model);
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                model.Pager = new PagerViewModel();
                model.Pager.CurrentPage = model.Pager.CurrentPage <= 0 ? 1 : model.Pager.CurrentPage;

                List<ReservationViewModel> items = await _context.Reservations.Skip((model.Pager.CurrentPage - 1) * PageSize).Take(PageSize).Select(c => new ReservationViewModel()
                {
                    Id = c.Id,
                    ReservationDate = c.ReservationDate,
                    TicketId = c.TicketId

                }).OrderByDescending(it => it.ReservationDate).ToListAsync();
                model.Items = items;

                return View(model);
            }
        }

        public IActionResult Create(int? id)
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

                    return RedirectToAction(nameof(AdminIndex));
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

                    Flight flight = _context.Flights.Find(id);
                    ViewData["resevationFlight"] = flight;

                    return View();
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    Flight flight = _context.Flights.Find(id);
                    ViewData["resevationFlight"] = flight;

                    return View();
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                Flight flight = _context.Flights.Find(id);
                ViewData["resevationFlight"] = flight;

                return View();
            } 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddReservationViewModel model) 
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

                    return RedirectToAction(nameof(AdminIndex));
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

                    if (ModelState.IsValid)
                    {
                        Ticket t = (from _t in _context.Tickets where _t.TicketTypeId == model.TicketTypeId select _t).First();
                        int rId = _context.Reservations.Max(r => r.Id);
                        Reservation _res = new Reservation()
                        {
                            Id = rId + 1,
                            ReservationDate = DateTime.Now,
                            TicketId = t.Id
                        };

                        _context.Reservations.Add(_res);
                        await _context.SaveChangesAsync();

                        int pId = _context.Passagers.Max(p => p.Id);
                        Passager _pass = new Passager()
                        {
                            Id = pId + 1,
                            FirstName = model.FirstName,
                            SecondName = model.SecondName,
                            LastName = model.LastName,
                            Egn = model.EGN,
                            PhoneNumber = model.PhoneNumber,
                            NationalityId = model.NationalityId
                        };

                        _context.Passagers.Add(_pass);
                        await _context.SaveChangesAsync();

                        int _flId = _context.Flights.Find(_context.Tickets.Find(_res.TicketId).FlightId).Id;
                        foreach (var item in flightCtrl.passagerNames)
                        {
                            if (item.Equals(new Tuple<int, List<string>>(_flId, new List<string>())))
                            {
                                item.Item2.Add(_pass.FirstName + " " + _pass.LastName);
                            }
                        }

                        int psId = _context.ReservationPassagers.Max(ps => ps.Id);
                        ReservationPassager _rp = new ReservationPassager()
                        {
                            Id = psId + 1,
                            PassagerId = _pass.Id,
                            ResrvationId = _res.Id
                        };

                        _context.ReservationPassagers.Add(_rp);
                        await _context.SaveChangesAsync();

                        // sends email
                        MimeMessage message = new MimeMessage();
                        MailboxAddress from = new MailboxAddress("Admin",
                        "petya.licheva2002@gmail.com");
                        message.From.Add(from);
                        string passFullName = _pass.FirstName + " " + _pass.LastName;
                        MailboxAddress to = new MailboxAddress(passFullName,
                        model.Email);
                        message.To.Add(to);

                        message.Subject = "About your flight reservation:";

                        string text = "Hello, " + passFullName + "!" + Environment.NewLine
                            + "Today (" + _res.ReservationDate + "), you made a reservation for a plane ticket for a flight with No "
                            + model.FlightId + ". Your ticket is with No "
                            + _res.TicketId + "." + Environment.NewLine + Environment.NewLine + "Personal Information:" + Environment.NewLine
                            + "First Name: " + _pass.FirstName + Environment.NewLine
                            + "Second Name: " + _pass.SecondName + Environment.NewLine
                            + "Last Name: " + _pass.LastName + Environment.NewLine
                            + "Personal Identification Number: " + _pass.Egn + Environment.NewLine
                            + "Phone Number: " + _pass.PhoneNumber + Environment.NewLine
                            + "Email: " + model.Email + Environment.NewLine
                            + Environment.NewLine + "If some of this data is incorrect or the person who made this reservation was not you,"
                            + " please contact us on email: petya.licheva2002@gmail.com" + Environment.NewLine + Environment.NewLine
                            + "Greetings from FlightManager's team!";

                        message.Body = new TextPart("plain")
                        {
                            Text = text
                        };
                        using (var client = new MailKit.Net.Smtp.SmtpClient())
                        {
                            client.Connect("smtp.gmail.com", 587, false);
                            client.Authenticate("petya.licheva2002@gmail.com", "myPass_Petya123");

                            client.Send(message);
                            await client.DisconnectAsync(true);
                        }
                        /////////////////////////////////////////////////////////////////

                        return RedirectToAction(nameof(Index));
                    }

                    return View(model);
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    if (ModelState.IsValid)
                    {
                        Ticket t = (from _t in _context.Tickets where _t.TicketTypeId == model.TicketTypeId select _t).First();
                        int rId = _context.Reservations.Max(r => r.Id);
                        Reservation _res = new Reservation()
                        {
                            Id = rId + 1,
                            ReservationDate = DateTime.Now,
                            TicketId = t.Id
                        };

                        _context.Reservations.Add(_res);
                        await _context.SaveChangesAsync();

                        int pId = _context.Passagers.Max(p => p.Id);
                        Passager _pass = new Passager()
                        {
                            Id = pId + 1,
                            FirstName = model.FirstName,
                            SecondName = model.SecondName,
                            LastName = model.LastName,
                            Egn = model.EGN,
                            PhoneNumber = model.PhoneNumber,
                            NationalityId = model.NationalityId
                        };

                        _context.Passagers.Add(_pass);
                        await _context.SaveChangesAsync();

                        int psId = _context.ReservationPassagers.Max(ps => ps.Id);
                        ReservationPassager _rp = new ReservationPassager()
                        {
                            Id = psId + 1,
                            PassagerId = _pass.Id,
                            ResrvationId = _res.Id
                        };

                        _context.ReservationPassagers.Add(_rp);
                        await _context.SaveChangesAsync();

                        // sends email
                        MimeMessage message = new MimeMessage();
                        MailboxAddress from = new MailboxAddress("Admin",
                        "petya.licheva2002@gmail.com");
                        message.From.Add(from);
                        string passFullName = _pass.FirstName + " " + _pass.LastName;
                        MailboxAddress to = new MailboxAddress(passFullName,
                        model.Email);
                        message.To.Add(to);

                        message.Subject = "About your flight reservation:";

                        string text = "Hello, " + passFullName + "!" + Environment.NewLine
                            + "Today (" + _res.ReservationDate + "), you made a reservation for a plane ticket for a flight with No "
                            + model.FlightId + ". Your ticket is with No "
                            + _res.TicketId + "." + Environment.NewLine + Environment.NewLine + "Personal Information:" + Environment.NewLine
                            + "First Name: " + _pass.FirstName + Environment.NewLine
                            + "Second Name: " + _pass.SecondName + Environment.NewLine
                            + "Last Name: " + _pass.LastName + Environment.NewLine
                            + "Personal Identification Number: " + _pass.Egn + Environment.NewLine
                            + "Phone Number: " + _pass.PhoneNumber + Environment.NewLine
                            + "Email: " + model.Email + Environment.NewLine
                            + Environment.NewLine + "If some of this data is incorrect or the person who made this reservation was not you,"
                            + " please contact us on email: petya.licheva2002@gmail.com" + Environment.NewLine + Environment.NewLine
                            + "Greetings from FlightManager's team!";

                        message.Body = new TextPart("plain")
                        {
                            Text = text
                        };
                        using (var client = new MailKit.Net.Smtp.SmtpClient())
                        {
                            client.Connect("smtp.gmail.com", 587, false);
                            client.Authenticate("petya.licheva2002@gmail.com", "myPass_Petya123");

                            client.Send(message);
                            await client.DisconnectAsync(true);
                        }
                        /////////////////////////////////////////////////////////////////

                        return RedirectToAction(nameof(Index));
                    }

                    return View(model);
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                if (ModelState.IsValid)
                {
                    Ticket t = (from _t in _context.Tickets where _t.TicketTypeId == model.TicketTypeId select _t).First();
                    int rId = _context.Reservations.Max(r => r.Id);
                    Reservation _res = new Reservation()
                    {
                        Id = rId + 1,
                        ReservationDate = DateTime.Now,
                        TicketId = t.Id
                    };

                    _context.Reservations.Add(_res);
                    await _context.SaveChangesAsync();

                    int pId = _context.Passagers.Max(p => p.Id);
                    Passager _pass = new Passager()
                    {
                        Id = pId + 1,
                        FirstName = model.FirstName,
                        SecondName = model.SecondName,
                        LastName = model.LastName,
                        Egn = model.EGN,
                        PhoneNumber = model.PhoneNumber,
                        NationalityId = model.NationalityId
                    };

                    _context.Passagers.Add(_pass);
                    await _context.SaveChangesAsync();

                    int psId = _context.ReservationPassagers.Max(ps => ps.Id);
                    ReservationPassager _rp = new ReservationPassager()
                    {
                        Id = psId + 1,
                        PassagerId = _pass.Id,
                        ResrvationId = _res.Id
                    };

                    _context.ReservationPassagers.Add(_rp);
                    await _context.SaveChangesAsync();

                    // sends email
                    MimeMessage message = new MimeMessage();
                    MailboxAddress from = new MailboxAddress("Admin",
                    "petya.licheva2002@gmail.com");
                    message.From.Add(from);
                    string passFullName = _pass.FirstName + " " + _pass.LastName;
                    MailboxAddress to = new MailboxAddress(passFullName,
                    model.Email);
                    message.To.Add(to);

                    message.Subject = "About your flight reservation:";

                    string text = "Hello, " + passFullName + "!" + Environment.NewLine
                        + "Today (" + _res.ReservationDate + "), you made a reservation for a plane ticket for a flight with No "
                        + model.FlightId +  ". Your ticket is with No "
                        + _res.TicketId + "." + Environment.NewLine + Environment.NewLine + "Personal Information:" + Environment.NewLine
                        + "First Name: " + _pass.FirstName + Environment.NewLine
                        + "Second Name: " + _pass.SecondName + Environment.NewLine
                        + "Last Name: " + _pass.LastName + Environment.NewLine
                        + "Personal Identification Number: " + _pass.Egn + Environment.NewLine
                        + "Phone Number: " + _pass.PhoneNumber + Environment.NewLine
                        + "Email: " + model.Email + Environment.NewLine
                        + Environment.NewLine + "If some of this data is incorrect or the person who made this reservation was not you,"
                        + " please contact us on email: petya.licheva2002@gmail.com" + Environment.NewLine + Environment.NewLine
                        + "Greetings from FlightManager's team!";

                    message.Body = new TextPart("plain")
                    {
                        Text = text
                    };
                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("petya.licheva2002@gmail.com", "myPass_Petya123");

                        client.Send(message);
                        await client.DisconnectAsync(true);
                    }
                    /////////////////////////////////////////////////////////////////

                    return RedirectToAction(nameof(Index));
                }

                return View(model);
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

                    Reservation reservation = await _context.Reservations.FindAsync(id);
                    ReservationPassager rp = (from r in _context.ReservationPassagers where r.ResrvationId == reservation.Id select r).First();
                    Passager p = (from pa in _context.Passagers where pa.Id == rp.PassagerId select pa).First();

                    _context.ReservationPassagers.Remove(rp);
                    await _context.SaveChangesAsync();

                    _context.Passagers.Remove(p);
                    await _context.SaveChangesAsync();

                    _context.Reservations.Remove(reservation);
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

                    Reservation reservation = _context.Reservations.Find(id);
                    return Details(reservation);
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

        [NonAction]
        public ViewResult Details(Reservation model)
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

                    ViewData["reservation"] = model;

                    ViewData["_resId"] = model.Id;
                    ViewData["_resDate"] = model.ReservationDate.ToShortDateString();

                    Ticket t = _context.Tickets.Find(model.TicketId);
                    Flight f = _context.Flights.Find(t.FlightId);
                    Plane p = _context.Planes.Find(f.PlaneId);
                    ReservationPassager rp = (from rpas in _context.ReservationPassagers where rpas.ResrvationId == model.Id select rpas).First();
                    Passager pass = _context.Passagers.Find(rp.PassagerId);
                    //Reservation_Confirmation rc = (from rcon in _context.ReservationConfirmations where rcon.ReservationId == model.Id select rcon).First();

                    ViewData["_locFrom"] = _context.LivingPlaces.Find(_context.Addresses.Find(f.LocationFromId).LivingPlaceId).Name + ", " + _context.Countries.Find(_context.Addresses.Find(f.LocationFromId).CountryId).Name;
                    ViewData["_locTo"] = _context.LivingPlaces.Find(_context.Addresses.Find(f.LocationToId).LivingPlaceId).Name + ", " + _context.Countries.Find(_context.Addresses.Find(f.LocationToId).CountryId).Name;
                    ViewData["_takeOffD"] = f.TakeOffDateTime.ToLongDateString();
                    ViewData["_landingD"] = f.LandingDateTime.ToLongDateString();
                    ViewData["_duration"] = (f.LandingDateTime - f.TakeOffDateTime).TotalMinutes + " mins.";
                    ViewData["_plType"] = _context.PlaneTypes.Find(p.PlaneTypeId).Name;
                    ViewData["_upn"] = p.UniquePlaneNumber;
                    ViewData["_pilot"] = _context.Employees.Find(p.PilotId).Name + " " + _context.Employees.Find(p.PilotId).Family;
                    ViewData["_fnm"] = pass.FirstName;
                    ViewData["_snm"] = pass.SecondName;
                    ViewData["_lnm"] = pass.LastName;
                    ViewData["_egn"] = pass.Egn;
                    ViewData["_nat"] = _context.Nationalities.Find(pass.NationalityId).Name;
                    ViewData["_phNum"] = pass.PhoneNumber;
                    //ViewData["_mail"] = rc.Email;
                    ViewData["_tickType"] = _context.TicketTypes.Find(t.TicketTypeId).Name;
                    ViewData["_tickPr"] = t.Price + " $";
                    ViewData["_tickCnt"] = 1;
                    ViewData["_totalPr"] = (1 * t.Price).ToString() + " $";

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

                    return View();
                }
                else
                {
                    ViewData["isLoggedIn"] = false;
                    ViewData["isAdmin"] = false;

                    return View();
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;

                return View();
            } 
        }
    }
}