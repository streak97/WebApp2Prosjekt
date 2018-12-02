using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public void CompleteTask(Tasks task)
        {
            var t = _context.Tasks.Where(x => x.TasksId == task.TasksId).FirstOrDefault();

            t.Complete = task.Complete;

            _context.Profiles.Where(x => x.Owner == t.Freelancer).SingleOrDefault().LinesWritten += task.Lines;

            _context.SaveChanges();
        }

        public async Task<List<Tasks>> GetDevelopersTasks(string username)
        {
            var dev = await _userManager.FindByNameAsync(username);

            List<Tasks> list = _context.Tasks.Where(x => x.Freelancer.Id == dev.Id ).ToList();

            return list;
        }

        public async Task<EditProfileViewModel> GetEditProfileViewModel(string username)
        {
            var dev = await _userManager.FindByNameAsync(username);

            if (!_context.Profiles.Any(x => x.Owner.Id == dev.Id))
            {
                await AddProfile(username);
            }

            Profile p = _context.Profiles.Where(x => x.Owner.Id == dev.Id).SingleOrDefault() ?? throw new ArgumentException();

            EditProfileViewModel epvm = new EditProfileViewModel
            {
                OwnerUserName = dev.UserName,
                ProfileId = p.ProfileId,
                LinesWritten = p.LinesWritten,
                WagePerLine = p.WagePerLine,
                SpecialityFieldId = p.SpecialityField.SpecialityFieldId
            };

            epvm.SpecialityFields = _context.SpecialityFields.ToList();

            return epvm;
        }

        public EditTaskViewModel GetEditTaskViewModel(int taskId)
        {
            var task = _context.Tasks.Where(x => x.TasksId == taskId).FirstOrDefault();

            EditTaskViewModel etvm = new EditTaskViewModel
            {
                TasksId = task.TasksId,
                Title = task.Title,
                Description = task.Description,
                SpecialityFieldId = task.SpecialityFieldId,
                Complete = task.Complete,
                Lines = task.Lines
            };

            return etvm;
        }

        public List<Tasks> GetTasksForReview()
        {
            return _context.Tasks.Where(x => x.Lines > 0).ToList();
        }

        public List<Tasks> GetAvailableBySpecialityTasks(int specialityId)
        {
            return _context.Tasks.Where(x => x.SpecialityFieldId == specialityId && x.Freelancer == null).ToList();
        }

        public List<Tasks> GetAvailableTasks()
        {
            return _context.Tasks.Where(x => x.Freelancer == null).Include(x => x.SpecialityField).ToList();
        }

        public void SetDeveloperTask(int taskId, string devName)
        {
            var task = _context.Tasks.First(x => x.TasksId == taskId);

            task.Freelancer = _context.Users.First(x => x.UserName == devName);

            _context.SaveChanges();

        }

        public void UpdateProfile(EditProfileViewModel epvm)
        {
            var profile = _context.Profiles.Where(x => x.ProfileId == epvm.ProfileId).SingleOrDefault();

            profile.LinesWritten = epvm.LinesWritten;
            profile.WagePerLine = epvm.WagePerLine;
            profile.SpecialityFieldId = epvm.SpecialityFieldId;

            _context.SaveChanges();
        }

        public void UpdateTask(EditTaskViewModel etvm)
        {
            var task = _context.Tasks.Where(x => x.TasksId == etvm.TasksId).FirstOrDefault();

            task.Title = etvm.Title;
            task.Description = etvm.Description;
            
            task.Lines = etvm.Lines;

            _context.SaveChanges();

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
