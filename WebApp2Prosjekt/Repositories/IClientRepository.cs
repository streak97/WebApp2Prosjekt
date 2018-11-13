using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2Prosjekt.Models.ViewModels;

namespace WebApp2Prosjekt.Repositories
{
    public interface IClientRepository
    {
        Task AddNewTask(CreateTaskViewModel ctvm, string username);
        CreateTaskViewModel GetCreateTaskViewModel();
        void EditTask(CreateTaskViewModel ctvm);
    }
}
