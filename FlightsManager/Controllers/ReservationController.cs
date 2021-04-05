using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Reservations", "Home");
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
