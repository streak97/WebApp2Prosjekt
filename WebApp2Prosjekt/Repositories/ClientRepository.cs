using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2Prosjekt.Data;
using WebApp2Prosjekt.Models;
using WebApp2Prosjekt.Models.ViewModels;

namespace WebApp2Prosjekt.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public ClientRepository(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task AddNewTask(CreateTaskViewModel ctvm, string username)
        {
            var clientUser = await _userManager.FindByNameAsync(username);
            Tasks task = new Tasks();
            if (ctvm.DeveloperId != "")
            {
                var devUser = await _userManager.FindByIdAsync(ctvm.DeveloperId);
                task.Freelancer = devUser ?? throw new ArgumentException();
            }

            task.Client = clientUser ?? throw new ArgumentException();

            task.Title = ctvm.Title;
            task.Description = ctvm.Description;
            if(ctvm.SpecialityFieldId != 0)
            {
                task.SpecialityFieldId = ctvm.SpecialityFieldId;
            }

            _context.Tasks.Add(task);

            _context.SaveChanges();

        }

        public void EditTask(CreateTaskViewModel ctvm)
        {
            throw new NotImplementedException();
        }

        public List<Tasks> GetAllTasks(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateTaskViewModel> GetCreateTaskViewModel()
        {
            CreateTaskViewModel ctvm = new CreateTaskViewModel();

            ctvm.SpecialityFields = _context.SpecialityFields.ToList();
            ctvm.Developers = (List<IdentityUser>)await _userManager.GetUsersInRoleAsync("Freelancer");
            ctvm.Developers.AddRange((List<IdentityUser>)await _userManager.GetUsersInRoleAsync("Developer"));

            return ctvm;
        }
    }
}
