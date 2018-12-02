using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp2Prosjekt.Models;
using WebApp2Prosjekt.Repositories;

namespace WebApp2Prosjekt.Controllers
{
    /// <summary>
    /// Controller for developer views
    /// </summary>
    [Authorize(Policy = "DeveloperAccess")]
    public class DeveloperController : Controller
    {
        private readonly IDeveloperRepository _repository;

        public DeveloperController(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ReviewTasks()
        {
            return View(_repository.GetTasksForReview());
        }

        [HttpPost]
        public IActionResult ReviewTasks([Bind("TasksId, Complete, Lines")]Tasks t)
        {
            try
            {
                _repository.CompleteTask(t);
                return RedirectToAction("ReviewTasks");
            }
            catch
            {
                return View();
            }
        }
    }
}