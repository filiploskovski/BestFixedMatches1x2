using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestFixedMatches1x2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Results()
        {
            return View();
        }

        public IActionResult BettingOdds()
        {
            return View();
        }

        public IActionResult VipTicketArchive()
        {
            return View();
        }
        public IActionResult VipTicketArchiveSingle(int id)
        {
            return View();
        }

        public IActionResult MonthlySubscriptionArchive()
        {
            return View();
        }
        public IActionResult FreeTipsArchive()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Advertise()
        {
            return View();
        }

        public IActionResult ToS()
        {
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
