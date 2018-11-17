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
        List<Tasks> GetAvailableTasks();
        List<Tasks> GetAvailableBySpecialityTasks(int specialityId);

        Task<List<Tasks>> GetDevelopersTasks(string username);

        List<Tasks> GetTasksForReview();

        void UpdateTask(EditTaskViewModel ctvm);

        void CompleteTask(Tasks task);

        Task<EditProfileViewModel> GetEditProfileViewModel(string username);

        void UpdateProfile(EditProfileViewModel epvm);

        EditTaskViewModel GetEditTaskViewModel(int taskId);

        void SetDeveloperTask(int taskId, string devName);
    }
}
