using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Claims;
using System.Threading;
using UCVSWP.Controllers;
using UCVSWP.Models;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Tests
{
    [TestClass]
    public class PeopleControllerTests
    {
        private Mock<IUserClassroomService> _userClassroomServiceMock;
        private Mock<UserManager<IdentityUser>> _userManagerMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _userClassroomServiceMock = new Mock<IUserClassroomService>();

            var userStoreMock = new Mock<IUserStore<IdentityUser>>();
            _userManagerMock = new Mock<UserManager<IdentityUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);
        }

        [TestMethod]
        public async Task Add_ValidEmail_RedirectsToIndex()
        {
            // Arrange
            var email = "test@test.com";
            var user = new IdentityUser { Email = email, UserName = email, Id = "1" };
            _userManagerMock.Setup(um => um.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);

            var controller = new PeopleController(_userClassroomServiceMock.Object, _userManagerMock.Object);
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Role, "Teacher") }));
            controller.ControllerContext = new ControllerContext { HttpContext = new DefaultHttpContext { User = claimsPrincipal } };

            // Act
            var result = await controller.Add(email) as RedirectToActionResult;

            // Assert
            _userManagerMock.Verify(um => um.FindByEmailAsync(It.IsAny<string>()), Times.Once);
            _userClassroomServiceMock.Verify(ucs => ucs.AddUserClassroom(It.IsAny<UserClassroom>()), Times.Once);
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
        }
    }
}
