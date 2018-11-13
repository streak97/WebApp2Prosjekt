using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp2Prosjekt.Models.ViewModels;

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
            //TODO: get a createtaskviewmodel
            return View();
        }

        [HttpPost]
        public IActionResult SubmitTask([Bind("Title, Description, SpecialityFieldId, DeveloperId")] CreateTaskViewModel ctvm)
        {
            try
            {
                //TODO: Add to repository
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