using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCVSWP.Data;
using UCVSWP.Models;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Controllers
{
	public class GradeAssignmentsController : Controller
	{
		private readonly IGradeAssignmentService _gradeAssignmentService;

		public GradeAssignmentsController(IGradeAssignmentService gradeAssignmentService)
		{
			_gradeAssignmentService = gradeAssignmentService;
		}

		// GET: GradeAssignments
		public IActionResult Index()
		{
			var gradeAssignment = _gradeAssignmentService.GetAllGradeAssignments();
			return View(gradeAssignment);
		}

		// GET: GradeAssignments/Details/5
		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var gradeAssignment = _gradeAssignmentService.GetGradeAssignmentAndRelatedById(id.Value);
			if (gradeAssignment == null)
			{
				return NotFound();
			}

			return View(gradeAssignment);
		}

		// GET: GradeAssignments/Create
		public IActionResult Create()
		{
			var assignments = _gradeAssignmentService.GetAllAssignments();
			var grades = _gradeAssignmentService.GetAllGrades();
			ViewData["AssignmentID"] = new SelectList(assignments, "AssignmentID", "AssignmentID");
			ViewData["GradeID"] = new SelectList(grades, "GradeID", "GradeID");
			return View();
		}

		// POST: GradeAssignments/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("GradeAssignmentID,GradeID,AssignmentID")] GradeAssignment gradeAssignment)
		{
			if (ModelState.IsValid)
			{
				_gradeAssignmentService.AddGradeAssignment(gradeAssignment);
				return RedirectToAction(nameof(Index));
			}
			var assignments = _gradeAssignmentService.GetAllAssignments();
			var grades = _gradeAssignmentService.GetAllGrades();
			ViewData["AssignmentID"] = new SelectList(assignments, "AssignmentID", "AssignmentID", gradeAssignment.AssignmentID);
			ViewData["GradeID"] = new SelectList(grades, "GradeID", "GradeID", gradeAssignment.GradeID);
			return View(gradeAssignment);
		}

		// GET: GradeAssignments/Edit/5
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var gradeAssignment = _gradeAssignmentService.GetGradeAssignmentById(id.Value);
			if (gradeAssignment == null)
			{
				return NotFound();
			}
			var assignments = _gradeAssignmentService.GetAllAssignments();
			var grades = _gradeAssignmentService.GetAllGrades();
			ViewData["AssignmentID"] = new SelectList(assignments, "AssignmentID", "AssignmentID", gradeAssignment.AssignmentID);
			ViewData["GradeID"] = new SelectList(grades, "GradeID", "GradeID", gradeAssignment.GradeID);
			return View(gradeAssignment);
		}

		// POST: GradeAssignments/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("GradeAssignmentID,GradeID,AssignmentID")] GradeAssignment gradeAssignment)
		{
			if (id != gradeAssignment.GradeAssignmentID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_gradeAssignmentService.UpdateGradeAssignment(gradeAssignment);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_gradeAssignmentService.GradeAssignmentExists(id))
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
			var assignments = _gradeAssignmentService.GetAllAssignments();
			var grades = _gradeAssignmentService.GetAllGrades();
			ViewData["AssignmentID"] = new SelectList(assignments, "AssignmentID", "AssignmentID", gradeAssignment.AssignmentID);
			ViewData["GradeID"] = new SelectList(grades, "GradeID", "GradeID", gradeAssignment.GradeID);
			return View(gradeAssignment);
		}

		// GET: GradeAssignments/Delete/5
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var gradeAssignment = _gradeAssignmentService.GetGradeAssignmentAndRelatedById(id.Value);
			if (gradeAssignment == null)
			{
				return NotFound();
			}

			return View(gradeAssignment);
		}

		// POST: GradeAssignments/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			_gradeAssignmentService.DeleteGradeAssignment(id);
			return RedirectToAction(nameof(Index));
		}
	}
}