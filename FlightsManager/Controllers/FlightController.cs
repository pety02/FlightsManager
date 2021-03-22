using FlightsManager.Models.Data;
using FlightsManager.Models.Web.Flights;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Controllers
{
    public class FlightController : Controller
    {
        private const int PageSize = 10;
        private readonly FlightsManagerContext _context;

        public FlightController()
        {
            _context = new FlightsManagerContext();
        }

        // GET: Contacts
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

            return View(model);
        }

        public IActionResult Create()
        {
            AddFlightViewModel model = new AddFlightViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddFlightViewModel model)
        {
            if (ModelState.IsValid)
            {
                Flight flight = new Flight
                {
                    LocationFromId = model.LocationFromId,
                    LocationToId = model.LocationToId,
                    TakeOffDateTime = model.TakeOffDateTime,
                    LandingDateTime = model.LandingDateTime,
                    PlaneId = model.PlaneId
                };

                _context.Add(flight);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
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

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditFlightViewModel model)
        {
            if (!ModelState.IsValid)
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
                    if (!ContactExists(flight.Id))
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

        public async Task<IActionResult> Delete(int id)
        {
            Flight flight = await _context.Flights.FindAsync(id);
            _context.Flights.Remove(flight);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            Flight flight = await _context.Flights.FindAsync(id);
            return Details(flight);
        }

        [NonAction]
        public ViewResult Details(Flight model)
        {
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

        private bool ContactExists(int id)
        {
            return _context.Flights.Any(e => e.Id == id);
        }
    }
}