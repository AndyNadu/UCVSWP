using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UCVSWP.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UCVSWP.Tests
{
    [TestClass]
    public class AdminControllerTests
    {
        private Mock<UserManager<IdentityUser>> _userManagerMock;
        private Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private AdminController _controller;

        [TestInitialize]
        public void Setup()
        {
            var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            _userManagerMock = new Mock<UserManager<IdentityUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);

            var roleStoreMock = new Mock<IRoleStore<IdentityRole>>();
            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(roleStoreMock.Object, null, null, null, null);

            _controller = new AdminController(null, _userManagerMock.Object, _roleManagerMock.Object);
        }

        [TestMethod]
        public async Task Details_WithValidId_ReturnsViewResult()
        {
            // Arrange
            string id = "1";
            var user = new IdentityUser { Id = id }; // Mock the user data

            _userManagerMock.Setup(service => service.FindByIdAsync(id)).Returns(Task.FromResult(user));

            // Act
            var result = await _controller.Details(id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        // Add more tests for Edit, and Delete methods
    }
}
