using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductUnitTest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp2Prosjekt.Controllers;
using WebApp2Prosjekt.Models;
using WebApp2Prosjekt.Models.ViewModels;
using WebApp2Prosjekt.Repositories;

namespace ControllerTest
{
    [TestClass]
    public class ClientControllerTest
    {
        Mock<IClientRepository> _repository;

        ClientController _controller;

        [TestInitialize]
        public void Setup()
        {
            _repository = new Mock<IClientRepository>();
        }

        [TestMethod]
        public void IndexGetsAllDevsTasksIntoView()
        {
            _repository.Setup(x => x.GetAllTasks(It.IsAny<string>())).Returns(new List<Tasks> {
                new Tasks { TasksId = 1, Title = "Hello", Description = "Bananas", Complete = false },
                new Tasks { TasksId = 2, Title = "Greetings", Description = "Bananas", Complete = false },
                new Tasks { TasksId = 3, Title = "Bye", Description = "Bananas", Complete = false }
            });

            _controller = new ClientController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.Index() as ViewResult;

            Assert.IsNotNull(res);
            _repository.VerifyAll();
            _repository.Verify(x => x.GetAllTasks(It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void SubmitTaskReturnsACreateTaskViewModel()
        {
            _repository.Setup(x => x.GetCreateTaskViewModel()).Returns(Task.FromResult(new CreateTaskViewModel()));
            
            _controller = new ClientController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.SubmitTask() as ViewResult;

            Assert.IsNotNull(res);
            _repository.VerifyAll();
            _repository.Verify(x => x.GetCreateTaskViewModel(), Times.Exactly(1));
            Assert.IsInstanceOfType(res.Model, typeof(Task<CreateTaskViewModel>));
        }

        [TestMethod]
        public void SubmitTaskPostDataUpdateError()
        {
            _repository.Setup(x => x.AddNewTask(It.IsAny<CreateTaskViewModel>(), It.IsAny<string>())).Throws(new Exception());

            _controller = new ClientController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.SubmitTask(new CreateTaskViewModel());

            Assert.IsNotNull(res);
            _repository.VerifyAll();
            _repository.Verify(x => x.AddNewTask(It.IsAny<CreateTaskViewModel>(), It.IsAny<string>()), Times.Exactly(1));
        }

        [TestMethod]
        public void SubmitTaskPostDataUpdateNoError()
        {
            _repository.Setup(x => x.AddNewTask(It.IsAny<CreateTaskViewModel>(), It.IsAny<string>())).Returns(Task.FromResult(new Tasks()));

            _controller = new ClientController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.SubmitTask(new CreateTaskViewModel());

            Assert.IsNotNull(res);
            _repository.VerifyAll();
            Assert.IsInstanceOfType(res, typeof(RedirectToActionResult));
        }
    }
}
