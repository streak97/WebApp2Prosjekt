using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp2Prosjekt.Controllers
{
    /// <summary>
    /// Controller for client views
    /// </summary>
    [Authorize(Roles = "ClientAccess")]
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubmitTask()
        {
            return View();
        }
    }
}