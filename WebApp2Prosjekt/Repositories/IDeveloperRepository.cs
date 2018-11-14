using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2Prosjekt.Models;
using WebApp2Prosjekt.Models.ViewModels;

namespace WebApp2Prosjekt.Repositories
{
    public interface IDeveloperRepository
    {
        List<Tasks> GetUnavailableTasks();
        List<Tasks> GetUnavailableBySpecialityTasks(string speciality);

        Task<List<Tasks>> GetDevelopersTasks(string username);

        List<Tasks> GetTasksForReview();

        void UpdateTask(CreateTaskViewModel ctvm);

        Task<EditProfileViewModel> GetEditProfileViewModel(string username);

        void UpdateProfile(EditProfileViewModel epvm);
    }
}
