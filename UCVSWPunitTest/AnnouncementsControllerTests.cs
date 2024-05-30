using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UCVSWP.Controllers;
using UCVSWP.Models;
using UCVSWP.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace UCVSWP.Tests
{
    [TestClass]
    public class AnnouncementsControllerTests
    {
        private Mock<IAnnouncementService> _announcementServiceMock;
        private AnnouncementsController _controller;

        [TestInitialize]
        public void Setup()
        {
            _announcementServiceMock = new Mock<IAnnouncementService>();
            _controller = new AnnouncementsController(_announcementServiceMock.Object);
        }

        [TestMethod]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var announcements = new List<Announcement>(); // Mock the announcements data

            _announcementServiceMock.Setup(service => service.GetAllAnnouncements()).Returns(announcements);

            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Details_WithValidId_ReturnsViewResult()
        {
            // Arrange
            int id = 1;
            var announcement = new Announcement { AnnouncementID = id }; // Mock the announcement data

            _announcementServiceMock.Setup(service => service.GetAnnouncementById(id)).Returns(announcement);

            // Act
            var result = _controller.Details(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        // Add more tests for Create, Edit, and Delete methods
    }
}
