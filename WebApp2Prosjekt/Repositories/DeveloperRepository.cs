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
    public class DeveloperRepository : IDeveloperRepository
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public DeveloperRepository(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<Tasks>> GetDevelopersTasks(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<EditProfileViewModel> GetEditProfileViewModel(string username)
        {
            throw new NotImplementedException();
        }

        public List<Tasks> GetTasksForReview()
        {
            throw new NotImplementedException();
        }

        public List<Tasks> GetUnavailableBySpecialityTasks(string speciality)
        {
            throw new NotImplementedException();
        }

        public List<Tasks> GetUnavailableTasks()
        {
            throw new NotImplementedException();
        }

        public void UpdateProfile(EditProfileViewModel epvm)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(CreateTaskViewModel ctvm)
        {
            throw new NotImplementedException();
        }

        private async Task AddProfile(string username)
        {
            var dev = await _userManager.FindByNameAsync(username);
            Profile p = new Profile { Owner = dev };

            _context.Profiles.Add(p);
            _context.SaveChanges();
        }
    }
}
