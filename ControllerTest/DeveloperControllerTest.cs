using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductUnitTest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WebApp2Prosjekt.Controllers;
using WebApp2Prosjekt.Models;
using WebApp2Prosjekt.Repositories;

namespace ControllerTesting
{
    [TestClass]
    public class DeveloperControllerTest
    {
        Mock<IDeveloperRepository> _repository;
        Mock<UserManager<IdentityUser>> _userManager;

        DeveloperController _controller;

        [TestInitialize]
        public void Setup()
        {
            _userManager = MockHelper.MockUserManager<IdentityUser>();
            _repository = new Mock<IDeveloperRepository>();
        }

        [TestMethod]
        public void ReturnIndexView()
        {
            _controller = new DeveloperController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = (ViewResult)_controller.Index();

            Assert.IsNotNull(res, "No view returned");
        }

        [TestMethod]
        public void ReviewTasksReturnTasks()
        {
            _repository.Setup(x => x.GetTasksForReview()).Returns(new List<Tasks> {
                new Tasks { TasksId = 1, Title = "Hello", Description = "Bananas", Complete = false },
                new Tasks { TasksId = 2, Title = "Greetings", Description = "Bananas", Complete = false },
                new Tasks { TasksId = 3, Title = "Bye", Description = "Bananas", Complete = false }
            });

            _controller = new DeveloperController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.ReviewTasks() as ViewResult;

            Assert.IsNotNull(res);
            CollectionAssert.AllItemsAreInstancesOfType((ICollection)res.ViewData.Model, typeof(Tasks), "Not tasks");
            _repository.Verify(x => x.GetTasksForReview(), Times.Exactly(1));
        }

        [TestMethod]
        public void ReviewTasksPostDataUpdateNoError()
        {
            _repository.Setup(x => x.CompleteTask(It.IsAny<Tasks>())).Throws(new Exception());

            _controller = new DeveloperController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.ReviewTasks(new Tasks());

            Assert.IsNotNull(res);
            _repository.VerifyAll();
            _repository.Verify(x => x.CompleteTask(It.IsAny<Tasks>()), Times.Exactly(1));
        }

        [TestMethod]
        public void ReviewTasksPostDataUpdateError()
        {
            _repository.Setup(x => x.CompleteTask(It.IsAny<Tasks>()));

            _controller = new DeveloperController(_repository.Object)
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = _controller.ReviewTasks(new Tasks());

            Assert.IsNotNull(res);
            _repository.VerifyAll();
            Assert.IsInstanceOfType(res, typeof(RedirectToActionResult));
        }
    }
}
