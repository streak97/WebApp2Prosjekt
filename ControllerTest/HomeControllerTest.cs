using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductUnitTest;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp2Prosjekt.Controllers;

namespace ControllerTesting
{
    [TestClass]
    public class HomeControllerTest
    {
        Mock<UserManager<IdentityUser>> _userManager;

        HomeController _controller;

        [TestInitialize]
        public void Setup()
        {
            _userManager = MockHelper.MockUserManager<IdentityUser>();
        }

        [TestMethod]
        public void RoleRedirectInIndex()
        {
            _controller = new HomeController()
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = (ViewResult)_controller.Index();

            Assert.IsNotNull(res, "No view returned");
            Assert.AreEqual("Index", res.ViewName, "Wrong view returned");
        }

        //TODO: Test redirect of roles, missing mock

        [TestMethod]
        public void ReturnAboutView()
        {
            _controller = new HomeController()
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = (ViewResult)_controller.About();

            Assert.IsNotNull(res, "No view returned");
        }

        [TestMethod]
        public void ReturnContactView()
        {
            _controller = new HomeController()
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = (ViewResult)_controller.Contact();

            Assert.IsNotNull(res, "No view returned");
        }

        [TestMethod]
        public void ReturnPrivacyView()
        {
            _controller = new HomeController()
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = (ViewResult)_controller.Privacy();

            Assert.IsNotNull(res, "No view returned");
        }

        [TestMethod]
        public void ReturnErrorView()
        {
            _controller = new HomeController()
            {
                ControllerContext = MockHelper.FakeControllerContext(false)
            };

            var res = (ViewResult)_controller.Error();

            Assert.IsNotNull(res, "No view returned");
        }
    }
}
