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

namespace FlightsManager.Controllers
{
    public class ReservationController : Controller
    {
        private const int PageSize = 10;
        private readonly FlightsManagerContext _context;

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
            model.Pager.PagesCount = (int)Math.Ceiling(_context.Flights.Count() / (double)PageSize);

            //////////////////// check for logged in employee -> admin
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                if (employeeId == 1)
                {
                    List<Employee> employees = await(from emp in _context.Employees
                                                     where
                      emp.Id == employeeId
                                                     select emp).ToListAsync();
                    Employee employee = employees[0];
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = true;
                }
                else
                {
                    List<Employee> employees = await(from emp in _context.Employees
                                                     where emp.Id == employeeId
                                                     select emp).ToListAsync();
                    Employee employee = employees[0];
                    ViewData["isLoggedIn"] = true;
                    ViewData["isAdmin"] = false;
                }
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                ViewData["isAdmin"] = false;
            }
            ///////////////////////////////////////////////////////////////

            return View(model);
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
            model.Pager.PagesCount = (int)Math.Ceiling(_context.Flights.Count() / (double)PageSize);

            //////////////////// check for logged in employee -> admin
            byte[] empIdBytes = new byte[200];
            if (HttpContext.Session.TryGetValue("empId", out empIdBytes))
            {
                int employeeId = int.Parse(Encoding.UTF8.GetString(empIdBytes));
                List<Employee> employees = await (from emp in _context.Employees where emp.Id == employeeId select emp).ToListAsync();
                Employee employee = employees[0];
                ViewData["isLoggedIn"] = true;
                return RedirectToAction(nameof(AdminIndex));
            }
            else
            {
                ViewData["isLoggedIn"] = false;
                return View(model);
            }
            ///////////////////////////////////////////////////////////////
        }
        public IActionResult Create(int? id)
        {
            Flight flight = _context.Flights.Find(id);
            ViewData["resevationFlight"] = flight;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddReservationViewModel model) 
        {
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
                /*MimeMessage message = new MimeMessage();
                MailboxAddress from = new MailboxAddress("Admin",
                "petya.licheva2002@abv.bg");
                message.From.Add(from);
                MailboxAddress to = new MailboxAddress("User",
                model.Email);
                message.To.Add(to);
                message.Subject = "Information about your flight reservation:";
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = "<h1>Your reservation is accepted!</h1><p>For more information please contact us on petya.licheva2002@abv.bg!</p>";
                bodyBuilder.TextBody = "Your reservation is accepted! For more information please contact us on petya.licheva2002@abv.bg!";
                message.Body = bodyBuilder.ToMessageBody();
                SmtpClient client = new SmtpClient();
                client.Connect("localhost", 25, true);
                client.Authenticate("petya.licheva2002@abv.bg", "*Parola@021115_krm!");
                client.Send(message);
                client.Disconnect(true);
                client.Dispose();*/
                /////////////////////////////////////////////////////////////////

                /*int rcId = _context.ReservationConfirmations.Max(rc => rc.Id);
                Reservation_Confirmation _rc = new Reservation_Confirmation()
                {
                    Id = rcId + 1,
                    ReservationId = _res.Id,
                    Email = model.Email
                };

                _context.ReservationConfirmations.Add(_rc);
                await _context.SaveChangesAsync();*/

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Reservation reservation = await _context.Reservations.FindAsync(id);
            ReservationPassager rp = (from r in _context.ReservationPassagers where r.ResrvationId == reservation.Id select r).First();
            Passager p = (from pa in _context.Passagers where pa.Id == rp.PassagerId select pa).First();
            //Reservation_Confirmation rc = (from recon in _context.ReservationConfirmations where recon.ReservationId == reservation.Id select recon).First();

            _context.ReservationPassagers.Remove(rp);
            await _context.SaveChangesAsync();
           
            //_context.ReservationConfirmations.Remove(rc);
            //await _context.SaveChangesAsync();
            
            _context.Passagers.Remove(p);
            await _context.SaveChangesAsync();
            
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            Reservation reservation = _context.Reservations.Find(id);

            return Details(reservation);
        }

        [NonAction]
        public ViewResult Details(Reservation model)
        {
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

            return View();
        }
    }
}