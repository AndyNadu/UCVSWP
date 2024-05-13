using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using UCVSWP.Models;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IUserClassroomService _userClassroomService;
        private readonly UserManager<IdentityUser> _userManager;
        private static int classid = 0;
        public PeopleController(IUserClassroomService userClassroomService,UserManager<IdentityUser> userManager)
        {
            _userClassroomService = userClassroomService;
            _userManager = userManager;
        }
        public IActionResult Index(int clsid)
        {
            classid = clsid;
            var users = _userClassroomService.GetAllUsers(clsid);
            return View(users);
        }

		[Authorize(Roles = "Teacher")]
		public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(string id)
        {
            UserClassroom uc = new UserClassroom();
            var user = await _userManager.FindByEmailAsync(id);
            uc.UserId = user.Id;
            uc.ClassroomID = classid;
            _userClassroomService.AddUserClassroom(uc);

            return RedirectToAction(nameof(Index),new { clsid = classid });
        }
    }
}
