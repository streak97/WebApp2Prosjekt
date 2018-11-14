using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp2Prosjekt.Controllers
{
    /// <summary>
    /// Controller for Freelancer views
    /// </summary>
    [Authorize(Policy = "TaskAccess")]
    public class FreelancerController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FindTask()
        {
            return View();
        }

        public IActionResult CompleteTask()
        {
            return View();
        }

        public IActionResult GetPayed()
        {
            return View();
        }

        public IActionResult SeeProfile()
        {
            return View();
        }
    }
}