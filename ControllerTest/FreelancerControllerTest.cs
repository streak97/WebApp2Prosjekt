using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp2Prosjekt.Controllers;
using WebApp2Prosjekt.Repositories;

namespace ControllerTesting
{
    [TestClass]
    public class FreelancerControllerTest
    {
        Mock<IDeveloperRepository> _repository;

        FreelancerController _controller;

    }
}
