using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApp2Prosjekt.Controllers
{
    /// <summary>
    /// Controller for developer views
    /// </summary>
    public class DeveloperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}