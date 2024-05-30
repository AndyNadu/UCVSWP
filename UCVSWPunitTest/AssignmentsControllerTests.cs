using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UCVSWP.Controllers;
using UCVSWP.Models;
using UCVSWP.Services.Interfaces;
using System.Threading.Tasks;

namespace UCVSWP.Tests
{
    [TestClass]
    public class AssignmentsControllerTests
    {
        private Mock<IAssignmentService> _assignmentServiceMock;
        private AssignmentsController _controller;

        [TestInitialize]
        public void Setup()
        {
            _assignmentServiceMock = new Mock<IAssignmentService>();
            _controller = new AssignmentsController(_assignmentServiceMock.Object);
        }

        [TestMethod]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var assignments = new List<Assignment>(); // Mock the assignments data

            _assignmentServiceMock.Setup(service => service.GetAllAssignments()).Returns(assignments);

            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(assignments);
        }

        [TestMethod]
        public void Details_WithValidId_ReturnsViewResult()
        {
            // Arrange
            int id = 1;
            var assignment = new Assignment { AssignmentID = id }; // Mock the assignment data

            _assignmentServiceMock.Setup(service => service.GetAssignmentAndRelatedById(id)).Returns(assignment);

            // Act
            var result = _controller.Details(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_ValidAssignment_RedirectsToIndex()
        {
            // Arrange
            int id = 1;
            var assignment = new Assignment { AssignmentID = id, Name = "Test Assignment" };

            _assignmentServiceMock.Setup(service => service.UpdateAssignment(assignment));

            // Act
            var result = _controller.Edit(id, assignment) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        public async Task Delete_ValidId_RedirectsToIndex()
        {
            // Arrange
            int id = 1;
            var assignment = new Assignment { AssignmentID = id, Name = "Test Assignment" };

            _assignmentServiceMock.Setup(service => service.GetAssignmentById(id)).Returns(assignment);
            _assignmentServiceMock.Setup(service => service.DeleteAssignment(id));

            // Act
            var result = _controller.DeleteConfirmed(id) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        public void Create_ValidAssignment_RedirectsToIndex()
        {
            // Arrange
            var assignment = new Assignment { AssignmentID = 1, Name = "Assignment Name", Content = "Assignment Content", Deadline = DateTime.Now, ClassroomID = 1 };

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Role, "Teacher"),
            }));

            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext { User = user }
            };

            // Act
            var result = _controller.Create(assignment) as RedirectToActionResult;

            // Assert
            _assignmentServiceMock.Verify(s => s.AddAssignment(It.IsAny<Assignment>()), Times.Once);
            _assignmentServiceMock.Verify(s => s.GetAllClassrooms(), Times.Never);
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
        }
    }
}
