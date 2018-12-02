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
    /// Controller for Freelancer views
    /// </summary>
    [Authorize(Policy = "TaskAccess")]
    public class FreelancerController : Controller
    {
        private readonly IDeveloperRepository _repository;

        public FreelancerController(IDeveloperRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetDevelopersTasks(User.Identity.Name).Result);
        }

        public IActionResult FindTask()
        {
            return View(_repository.GetAvailableTasks());
        }
        public IActionResult ClaimTask(int taskId)
        {
            try
            {
                _repository.SetDeveloperTask(taskId, User.Identity.Name);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("FindTask");
            }
        }

        public IActionResult UpdateTask(int taskId)
        {
            return View(_repository.GetEditTaskViewModel(taskId));
        }

        [HttpPost]
        public IActionResult UpdateTask([Bind("TasksId, Title, Description, SpecialityFieldId, Complete, Lines")]EditTaskViewModel etvm)
        {
            try
            {
                _repository.UpdateTask(etvm);
                return RedirectToAction("Index");
            } catch
            {
                return View();
            }
        }

        //May be redundant
        public IActionResult GetPayed()
        {
            return View();
        }

        public IActionResult SeeProfile()
        {
            return View(_repository.GetEditProfileViewModel(User.Identity.Name).Result);
        }

        [HttpPost]
        public IActionResult SeeProfile([Bind("ProfileId, LinesWritten, WagePerLine, SpecialityFieldId")]EditProfileViewModel epvm)
        {
            try
            {
                _repository.UpdateProfile(epvm);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}