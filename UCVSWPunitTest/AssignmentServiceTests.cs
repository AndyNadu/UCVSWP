using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;
using UCVSWP.Services;

namespace UCVSWP.Tests.Services
{
    [TestClass]
    public class AssignmentServiceTests
    {
        private AssignmentService _service;
        private Mock<IAssignmentRepository> _repositoryMock;

        [TestInitialize]
        public void Initialize()
        {
            // Initialize mock objects
            _repositoryMock = new Mock<IAssignmentRepository>();
            _service = new AssignmentService(_repositoryMock.Object);
        }

        [TestMethod]
        public void GetAllAssignments_ReturnsAllAssignments()
        {
            // Arrange
            var assignments = new List<Assignment>()
            {
                new Assignment { AssignmentID = 1, Name = "Assignment 1" },
                new Assignment { AssignmentID = 2, Name = "Assignment 2" },
                new Assignment { AssignmentID = 3, Name = "Assignment 3" }
            };
            _repositoryMock.Setup(r => r.GetAll()).Returns(assignments);

            // Act
            var result = _service.GetAllAssignments();

            // Assert
            Assert.AreEqual(assignments.Count, result.Count);
            Assert.IsTrue(assignments.SequenceEqual(result));
        }

        [TestMethod]
        public void GetAssignmentById_ReturnsCorrectAssignment()
        {
            // Arrange
            var assignmentId = 1;
            var assignment = new Assignment { AssignmentID = assignmentId, Name = "Assignment 1" };
            _repositoryMock.Setup(r => r.GetById(assignmentId)).Returns(assignment);

            // Act
            var result = _service.GetAssignmentById(assignmentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(assignmentId, result.AssignmentID);
            Assert.AreEqual("Assignment 1", result.Name);
        }

        [TestMethod]
        public void AddAssignment_CallsRepositoryCreateAndSave()
        {
            // Arrange
            var assignment = new Assignment();

            // Act
            _service.AddAssignment(assignment);

            // Assert
            _repositoryMock.Verify(r => r.Create(assignment), Times.Once);
            _repositoryMock.Verify(r => r.Save(), Times.Once);
        }

        // Add more test methods as needed for other methods in AssignmentService

        // Cleanup or additional methods if necessary
        [TestMethod]
        public void AssignmentExists_ReturnsTrueWhenAssignmentExists()
        {
            // Arrange
            var assignmentId = 1;
            _repositoryMock.Setup(r => r.AssignmentExists(assignmentId)).Returns(true);

            // Act
            var result = _service.AssignmentExists(assignmentId);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AssignmentExists_ReturnsFalseWhenAssignmentDoesNotExist()
        {
            // Arrange
            var assignmentId = 1;
            _repositoryMock.Setup(r => r.AssignmentExists(assignmentId)).Returns(false);

            // Act
            var result = _service.AssignmentExists(assignmentId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateAssignment_CallsRepositoryUpdateAndSave()
        {
            // Arrange
            var assignment = new Assignment();

            // Act
            _service.UpdateAssignment(assignment);

            // Assert
            _repositoryMock.Verify(r => r.Update(assignment), Times.Once);
            _repositoryMock.Verify(r => r.Save(), Times.Once);
        }

        [TestMethod]
        public void DeleteAssignment_CallsRepositoryDeleteAndSave()
        {
            // Arrange
            var assignmentId = 1;
            var assignment = new Assignment { AssignmentID = assignmentId };
            _repositoryMock.Setup(r => r.GetById(assignmentId)).Returns(assignment);

            // Act
            _service.DeleteAssignment(assignmentId);

            // Assert
            _repositoryMock.Verify(r => r.Delete(assignment), Times.Once);
            _repositoryMock.Verify(r => r.Save(), Times.Once);
        }

        [TestMethod]
        public void DeleteAssignment_DoesNotCallRepositoryDeleteAndSaveWhenAssignmentDoesNotExist()
        {
            // Arrange
            var assignmentId = 1;
            _repositoryMock.Setup(r => r.GetById(assignmentId)).Returns((Assignment)null);

            // Act
            _service.DeleteAssignment(assignmentId);

            // Assert
            _repositoryMock.Verify(r => r.Delete(It.IsAny<Assignment>()), Times.Never);
            _repositoryMock.Verify(r => r.Save(), Times.Never);
        }

    }
}
