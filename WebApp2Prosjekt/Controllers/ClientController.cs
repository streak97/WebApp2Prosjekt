using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp2Prosjekt.Models;
using WebApp2Prosjekt.Models.ViewModels;
using WebApp2Prosjekt.Repositories;

namespace WebApp2Prosjekt.Controllers
{
    /// <summary>
    /// Controller for client views
    /// </summary>
    [Authorize(Roles = "ClientAccess")]
    public class ClientController : Controller
    {
        private IClientRepository _repository;

        public ClientController(IClientRepository repository)
        {
            this._repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAllTasks(User.Identity.Name));
        }

        public IActionResult SubmitTask()
        {
            var ctvm = _repository.GetCreateTaskViewModel();
            return View(ctvm);
        }

        [HttpPost]
        public IActionResult SubmitTask([Bind("Title, Description, SpecialityFieldId, DeveloperId")] CreateTaskViewModel ctvm)
        {
            try
            {
                var user = User.Identity.Name;
                _repository.AddNewTask(ctvm, user).Wait();
                return RedirectToAction("Index");
            } catch
            {
                return View();
            }
        }

        //May be redundant
        public IActionResult PayForTask()
        {
            IEnumerable<Tasks> tasks = _repository.GetAllTasks(User.Identity.Name);
            return View(tasks);
        }
    }
}