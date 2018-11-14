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
        private UserManager<IdentityUser> _manager;

        public ClientRepository(UserManager<IdentityUser> manager, ApplicationDbContext context)
        {
            _manager = manager;
            _context = context;
        }

        public async Task AddNewTask(CreateTaskViewModel ctvm, string username)
        {
            var clientUser = await _manager.FindByNameAsync(username);
            Tasks task = new Tasks();
            if (ctvm.DeveloperId != "")
            {
                var devUser = await _manager.FindByIdAsync(ctvm.DeveloperId);
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

        public CreateTaskViewModel GetCreateTaskViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
