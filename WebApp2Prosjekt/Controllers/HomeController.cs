using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp2Prosjekt.Models;

namespace WebApp2Prosjekt.Controllers
{
    /// <summary>
    /// Main controller
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Client"))
            {
                return RedirectToAction("Index", "Client");
            } else if (User.IsInRole("Freelancer"))
            {
                return RedirectToAction("Index", "Freelancer");
            } else if (User.IsInRole("Developer"))
            {
                return RedirectToAction("Index", "Developer");
            } else if (User.IsInRole("Administrator"))
            {
                return View("AdminIndex");
            }
            return View("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
