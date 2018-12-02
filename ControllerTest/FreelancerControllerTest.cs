using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductUnitTest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApp2Prosjekt.Controllers;
using WebApp2Prosjekt.Models;
using WebApp2Prosjekt.Models.ViewModels;
using WebApp2Prosjekt.Repositories;

namespace ControllerTesting
{
    [TestClass]
    public class FreelancerControllerTest
    {
        Mock<IDeveloperRepository> _repository;

        FreelancerController _controller;

        [TestInitialize]
        public void Setup()
        {
            _repository = new Mock<IDeveloperRepository>();
        }

        [TestMethod]
        public void IndexReturnsListOfTasks()
        {
            _repository.Setup(x => x.GetDevelopersTasks(It.IsAny<string>())).Returns(Task.FromResult(new List<Tasks> {
                new Tasks { TasksId = 1, Title = "Hello", Description = "Bananas", Complete = false },
                new Tasks { TasksId = 2, Title = "Greetings", Description = "Bananas", Complete = false },
                new Tasks { TasksId = 3, Title = "Bye", Description = "Bananas", Complete = false }
            }));

            _controller = new FreelancerController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.Index() as ViewResult;

            Assert.IsNotNull(res);
            _repository.Verify(x => x.GetDevelopersTasks(It.IsAny<string>()), Times.Exactly(1));
            Assert.IsInstanceOfType(res.Model, typeof(List<Tasks>));
        }

        [TestMethod]
        public void FindTaskReturnsListOfTasks()
        {
            _repository.Setup(x => x.GetAvailableTasks()).Returns(new List<Tasks> {
                new Tasks { TasksId = 1, Title = "Hello", Description = "Bananas", Complete = false },
                new Tasks { TasksId = 2, Title = "Greetings", Description = "Bananas", Complete = false },
                new Tasks { TasksId = 3, Title = "Bye", Description = "Bananas", Complete = false }
            });

            _controller = new FreelancerController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.FindTask() as ViewResult;

            Assert.IsNotNull(res);
            _repository.Verify(x => x.GetAvailableTasks(), Times.Exactly(1));
            Assert.IsInstanceOfType(res.Model, typeof(List<Tasks>));
        }

        [TestMethod]
        public void ClaimTaskNoErrorRedirectToIndex()
        {
            _repository.Setup(x => x.SetDeveloperTask(It.IsAny<int>(), It.IsAny<string>()));

            _controller = new FreelancerController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.ClaimTask(2);

            Assert.IsNotNull(res);
            _repository.Verify(x => x.SetDeveloperTask(It.IsAny<int>(), It.IsAny<string>()), Times.Exactly(1));
            Assert.IsInstanceOfType(res, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void ClaimTaskErrorRedirectToFindTask()
        {
            _repository.Setup(x => x.SetDeveloperTask(It.IsAny<int>(), It.IsAny<string>())).Throws(new Exception());

            _controller = new FreelancerController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.ClaimTask(2);

            Assert.IsNotNull(res);
            _repository.Verify(x => x.SetDeveloperTask(It.IsAny<int>(), It.IsAny<string>()), Times.Exactly(1));
            Assert.AreEqual("FindTask", (res as ViewResult).ViewName);
        }

        [TestMethod]
        public void UpdateTaskEditViewModelCaller()
        {
            _repository.Setup(x => x.GetEditTaskViewModel(It.IsAny<int>())).Returns(new EditTaskViewModel());

            _controller = new FreelancerController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.UpdateTask(1) as ViewResult;

            Assert.IsNotNull(res);
            _repository.Verify(x => x.GetEditTaskViewModel(It.IsAny<int>()), Times.Exactly(1));
            Assert.IsInstanceOfType(res.Model, typeof(EditTaskViewModel));
        }

        [TestMethod]
        public void UpdateTaskPostDataNoError()
        {
            _repository.Setup(x => x.UpdateTask(It.IsAny<EditTaskViewModel>()));
            
            _controller = new FreelancerController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.UpdateTask(new EditTaskViewModel());

            Assert.IsNotNull(res);
            _repository.Verify(x => x.UpdateTask(It.IsAny<EditTaskViewModel>()), Times.Exactly(1));
            Assert.IsInstanceOfType(res, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void UpdateTaskPostDataError()
        {
            _repository.Setup(x => x.UpdateTask(It.IsAny<EditTaskViewModel>())).Throws(new Exception());
            
            _controller = new FreelancerController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.UpdateTask(new EditTaskViewModel());

            Assert.IsNotNull(res);
            _repository.Verify(x => x.UpdateTask(It.IsAny<EditTaskViewModel>()), Times.Exactly(1));
            Assert.AreEqual(null, (res as ViewResult).ViewName);
        }

        [TestMethod]
        public void SeeProfileGetEditProfileModel()
        {
            _repository.Setup(x => x.GetEditProfileViewModel(It.IsAny<string>())).Returns(Task.FromResult(new EditProfileViewModel()));
            
            _controller = new FreelancerController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.SeeProfile() as ViewResult;

            Assert.IsNotNull(res);
            _repository.Verify(x => x.GetEditProfileViewModel(It.IsAny<string>()), Times.Exactly(1));
            Assert.IsInstanceOfType(res.Model, typeof(EditProfileViewModel));
        }

        [TestMethod]
        public void UpdateProfilePostDataNoError()
        {
            _repository.Setup(x => x.UpdateProfile(It.IsAny<EditProfileViewModel>()));
            
            _controller = new FreelancerController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.SeeProfile(new EditProfileViewModel());

            Assert.IsNotNull(res);
            _repository.Verify(x => x.UpdateProfile(It.IsAny<EditProfileViewModel>()), Times.Exactly(1));
            Assert.IsInstanceOfType(res, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void UpdateProfilePostDataError()
        {
            _repository.Setup(x => x.UpdateProfile(It.IsAny<EditProfileViewModel>())).Throws(new Exception());

            _controller = new FreelancerController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.SeeProfile(new EditProfileViewModel());

            Assert.IsNotNull(res);
            _repository.Verify(x => x.UpdateProfile(It.IsAny<EditProfileViewModel>()), Times.Exactly(1));
            Assert.AreEqual(null, (res as ViewResult).ViewName);
        }

    }
}
