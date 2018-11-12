using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp2Prosjekt.Controllers
{
    /// <summary>
    /// Controller for Freelancer views
    /// </summary>
    public class FreelancerController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}