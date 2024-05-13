using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCVSWP.Data;
using UCVSWP.Models;
using UCVSWP.Services;
using UCVSWP.Services.Interfaces;

namespace UCVSWP.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
			_commentService = commentService;
        }

        // GET: Comments
        public IActionResult Index()
        {
			var comments = _commentService.GetAllComments();
			return View(comments);
		}

        // GET: Comments/Details/5
        public IActionResult Details(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			var comment = _commentService.GetCommentById(id.Value);

			if (comment == null)
			{
				return NotFound();
			}

			return View(comment);
		}

        // GET: Comments/Create
        public IActionResult Create()
        {
			var assignments = _commentService.GetAllAssignments();
			ViewData["AssignmentID"] = new SelectList(assignments, "AssignmentID", "AssignmentID");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CommentID,Content,Privacy,AssignmentID")] Comment comment)
        {
			if (ModelState.IsValid)
			{
				_commentService.AddComment(comment);
				return RedirectToAction(nameof(Index));
			}
			var assignments = _commentService.GetAllAssignments();
			ViewData["AssignmentID"] = new SelectList(assignments, "AssignmentID", "AssignmentID", comment.AssignmentID);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public IActionResult Edit(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			var comment = _commentService.GetCommentById(id.Value);

			if (comment == null)
			{
				return NotFound();
			}
			var assignments = _commentService.GetAllAssignments();
			ViewData["AssignmentID"] = new SelectList(assignments, "AssignmentID", "AssignmentID", comment.AssignmentID);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CommentID,Content,Privacy,AssignmentID")] Comment comment)
        {
			if (id != comment.CommentID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_commentService.UpdateComment(comment);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_commentService.CommentExists(comment.CommentID))
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
			var assignments = _commentService.GetAllAssignments();
			ViewData["AssignmentID"] = new SelectList(assignments, "AssignmentID", "AssignmentID", comment.AssignmentID);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public IActionResult Delete(int? id)
        {
			if (id == null)
			{
				return NotFound();
			}

			var comment = _commentService.GetCommentAndRelatedById(id.Value);

			if (comment == null)
			{
				return NotFound();
			}

			return View(comment);
		}

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
			var comment = _commentService.GetCommentById(id);

			if (_commentService != null)
			{
				_commentService.DeleteComment(id);
			}
			return RedirectToAction(nameof(Index));
		}
    }
}
