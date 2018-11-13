using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2Prosjekt.Models.ViewModels;

namespace WebApp2Prosjekt.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public Task AddNewTask(CreateTaskViewModel ctvm, string username)
        {
            throw new NotImplementedException();
        }

        public void EditTask(CreateTaskViewModel ctvm)
        {
            throw new NotImplementedException();
        }

        public CreateTaskViewModel GetCreateTaskViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
