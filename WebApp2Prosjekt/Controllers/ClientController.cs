using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private IClientRepository repository;

        public ClientController(IClientRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SubmitTask()
        {
            //TODO: get a createtaskviewmodel
            var ctvm = repository.GetCreateTaskViewModel();
            return View(ctvm);
        }

        [HttpPost]
        public IActionResult SubmitTask([Bind("Title, Description, SpecialityFieldId, DeveloperId")] CreateTaskViewModel ctvm)
        {
            try
            {
                //TODO: Add to repository
                var user = User.Identity.Name;
                repository.AddNewTask(ctvm, user).Wait();
                return RedirectToAction("Index");
            } catch
            {
                return View();
            }
        }

        public IActionResult PayForTask()
        {
            return View();
        }
    }
}