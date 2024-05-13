using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCVSWP.Data;
using UCVSWP.Models;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentsController(IAssignmentService assignmentService)
        {
			_assignmentService = assignmentService;
        }

        // GET: Assignments
        public IActionResult Index()
        {
			var assignment = _assignmentService.GetAllAssignments();
			return View(assignment);
		}

        // GET: Assignments/Details/5
        public IActionResult Details(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			var assignment = _assignmentService.GetAssignmentAndRelatedById(id.Value);

			if (assignment == null)
			{
				return NotFound();
			}

			return View(assignment);
        }

		// GET: Assignments/Create
		[Authorize(Roles = "Teacher")]
		public IActionResult Create()
        {
			var classrooms = _assignmentService.GetAllClassrooms();
			ViewData["ClassroomID"] = new SelectList(classrooms, "ClassroomID", "Name");
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Teacher")]
		public IActionResult Create([Bind("AssignmentID,Name,Content,Deadline,ClassroomID")] Assignment assignment)
        {
			if (ModelState.IsValid)
			{
				_assignmentService.AddAssignment(assignment);
				return RedirectToAction(nameof(Index));
			}

			var classrooms = _assignmentService.GetAllClassrooms();
			ViewData["ClassroomID"] = new SelectList(classrooms, "ClassroomID", "Name", assignment.ClassroomID);
            return View(assignment);
        }

		// GET: Assignments/Edit/5
		[Authorize(Roles = "Teacher")]
		public IActionResult Edit(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			var assignment = _assignmentService.GetAssignmentById(id.Value);
			if (_assignmentService == null)
			{
				return NotFound();
			}
			var classrooms = _assignmentService.GetAllClassrooms();
			ViewData["ClassroomID"] = new SelectList(classrooms, "ClassroomID", "Name", assignment.ClassroomID);
            return View(assignment);
        }

		// POST: Assignments/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Teacher")]
		public IActionResult Edit(int id, [Bind("AssignmentID,Name,Content,Deadline,ClassroomID")] Assignment assignment)
        {
			if (id != assignment.AssignmentID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_assignmentService.UpdateAssignment(assignment);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (_assignmentService.AssignmentExists(id))
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
			var classrooms = _assignmentService.GetAllClassrooms();
			ViewData["ClassroomID"] = new SelectList(classrooms, "ClassroomID", "Name", assignment.ClassroomID);
            return View(assignment);
        }

		// GET: Assignments/Delete/5
		[Authorize(Roles = "Teacher")]
		public IActionResult Delete(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			var assignment = _assignmentService.GetAssignmentAndRelatedById(id.Value);

			if (assignment == null)
			{
				return NotFound();
			}

			return View(assignment);

		}

		// POST: Assignments/Delete/5
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Teacher")]
		public IActionResult DeleteConfirmed(int id)
        {
			var assignment = _assignmentService.GetAssignmentById(id);

			if (assignment != null)
			{
				_assignmentService.DeleteAssignment(id);
			}
			return RedirectToAction(nameof(Index));

		}
	}
}
