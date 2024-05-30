using Microsoft.VisualStudio.TestTools.UnitTesting;
using UCVSWP.Models;
using UCVSWP.Repositories.Interfaces;
using UCVSWP.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UCVSWP.Tests
{
    [TestClass]
    public class ClassroomServiceTests
    {
        private Mock<IClassroomRepository> _mockRepo;
        private ClassroomService _classroomService;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepo = new Mock<IClassroomRepository>();
            _classroomService = new ClassroomService(_mockRepo.Object);
        }

        [TestMethod]
        public void AddClassroom_Should_Call_Repository_Methods()
        {
            // Arrange
            var classroom = new Classroom();

            // Act
            _classroomService.AddClassroom(classroom);

            // Assert
            _mockRepo.Verify(x => x.Create(classroom), Times.Once);
            _mockRepo.Verify(x => x.Save(), Times.Once);
        }

        [TestMethod]
        public void ClassroomExists_Should_Call_Repository_Method()
        {
            // Arrange
            int classroomId = 1;

            // Act
            _classroomService.ClassroomExists(classroomId);

            // Assert
            _mockRepo.Verify(x => x.ClassroomExists(classroomId), Times.Once);
        }

        [TestMethod]
        public void DeleteClassroom_Should_Call_Repository_Methods()
        {
            // Arrange
            int classroomId = 1;
            var classroom = new Classroom();
            _mockRepo.Setup(x => x.GetById(classroomId)).Returns(classroom);

            // Act
            _classroomService.DeleteClassroom(classroomId);

            // Assert
            _mockRepo.Verify(x => x.GetById(classroomId), Times.Once);
            _mockRepo.Verify(x => x.Delete(classroom), Times.Once);
            _mockRepo.Verify(x => x.Save(), Times.Once);
        }

        [TestMethod]
        public void GetAllClassrooms_Should_Call_Repository_Method()
        {
            // Arrange
            // Act
            _classroomService.GetAllClassrooms();

            // Assert
            _mockRepo.Verify(x => x.GetAll(), Times.Once);
        }

        [TestMethod]
        public void GetClassroomById_Should_Call_Repository_Method()
        {
            // Arrange
            int classroomId = 1;

            // Act
            _classroomService.GetClassroomById(classroomId);

            // Assert
            _mockRepo.Verify(x => x.GetById(classroomId), Times.Once);
        }

        [TestMethod]
        public void UpdateClassroom_Should_Call_Repository_Methods()
        {
            // Arrange
            var classroom = new Classroom();

            // Act
            _classroomService.UpdateClassroom(classroom);

            // Assert
            _mockRepo.Verify(x => x.Update(classroom), Times.Once);
            _mockRepo.Verify(x => x.Save(), Times.Once);
        }
    }
}
