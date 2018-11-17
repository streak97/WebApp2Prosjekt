using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp2Prosjekt.Repositories;

namespace WebApp2Prosjekt.Controllers
{
    /// <summary>
    /// Controller for Freelancer views
    /// </summary>
    [Authorize(Policy = "TaskAccess")]
    public class FreelancerController : Controller
    {
        private IDeveloperRepository _repository;

        public FreelancerController(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FindTask()
        {
            return View();
        }

        public IActionResult UpdateTask()
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