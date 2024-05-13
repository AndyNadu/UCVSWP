using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCVSWP.Data;
using UCVSWP.Models;
using UCVSWP.Services;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Controllers
{
    public class ClassroomsController : Controller
    {
        private readonly IClassroomService _classroomService;
        private readonly IAnnouncementService _announcementService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserClassroomService _userClassroomService;

        public ClassroomsController(IClassroomService classroomService, IAnnouncementService announcementService, UserManager<IdentityUser> userManager, IUserClassroomService userClassroomService)
        {
			_classroomService = classroomService;
            _announcementService = announcementService;
            _userManager = userManager;
            _userClassroomService = userClassroomService;
        }

        // GET: Classrooms
        [Authorize]
        public IActionResult Index()
        {
            var classrooms = _userClassroomService.GetAllClasses(User.FindFirstValue(ClaimTypes.NameIdentifier));
			return View(classrooms);
		}

        // GET: Classrooms/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = _classroomService.GetClassroomById(id.Value);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // GET: Classrooms/Create
        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classrooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create([Bind("ClassroomID,Name,Description")] Classroom classroom)
        {
            if (ModelState.IsValid)
            {
                _classroomService.AddClassroom(classroom);
                var userClassroom = new UserClassroom();
                userClassroom.ClassroomID = classroom.ClassroomID;
                userClassroom.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _userClassroomService.AddUserClassroom(userClassroom);
                return RedirectToAction(nameof(Index));
			}
            return View(classroom);
        }

		// GET: Classrooms/Edit/5
		[Authorize(Roles = "Teacher")]
		public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = _classroomService.GetClassroomById(id.Value);
            if (classroom == null)
            {
                return NotFound();
            }
            return View(classroom);
        }

        // POST: Classrooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Teacher")]
		public IActionResult Edit(int id, [Bind("ClassroomID,Name,Description")] Classroom classroom)
        {
            if (id != classroom.ClassroomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _classroomService.UpdateClassroom(classroom);
				}
                catch (DbUpdateConcurrencyException)
                {
                    if (!_classroomService.ClassroomExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(classroom);
        }

		// GET: Classrooms/Delete/5
		[Authorize(Roles = "Teacher")]
		public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classroom = _classroomService.GetClassroomById(id.Value);
            if (classroom == null)
            {
                return NotFound();
            }

            return View(classroom);
        }

        // POST: Classrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _classroomService.DeleteClassroom(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
