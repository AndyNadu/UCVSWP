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
    public class QuizsController : Controller
    {
        private readonly IQuizService _quizService;

        public QuizsController(IQuizService quizService)
        {
			_quizService = quizService;
        }

        // GET: Quizs
        public IActionResult Index()
        {
			var quizs = _quizService.GetAllQuizs();
			return View(quizs);
		}

        // GET: Quizs/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = _quizService.GetQuizAndRelatedById(id.Value);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // GET: Quizs/Create
        public IActionResult Create()
        {
			var classrooms = _quizService.GetAllClassrooms();
			ViewData["ClassroomID"] = new SelectList(classrooms, "ClassroomID", "ClassroomID");
            return View();
        }

        // POST: Quizs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("QuizID,Name,Content,Deadline,ClassroomID")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
               _quizService.AddQuiz(quiz);
                return RedirectToAction(nameof(Index));
            }
			var classrooms = _quizService.GetAllClassrooms();
			ViewData["ClassroomID"] = new SelectList(classrooms, "ClassroomID", "ClassroomID", quiz.ClassroomID);
            return View(quiz);
        }

        // GET: Quizs/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = _quizService.GetQuizById(id.Value);
            if (quiz == null)
            {
                return NotFound();
            }
			var classrooms = _quizService.GetAllClassrooms();
			ViewData["ClassroomID"] = new SelectList(classrooms, "ClassroomID", "ClassroomID", quiz.ClassroomID);
            return View(quiz);
        }

        // POST: Quizs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("QuizID,Name,Content,Deadline,ClassroomID")] Quiz quiz)
        {
            if (id != quiz.QuizID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _quizService.UpdateQuiz(quiz);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_quizService.QuizExists(id))
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
			var classrooms = _quizService.GetAllClassrooms();
			ViewData["ClassroomID"] = new SelectList(classrooms, "ClassroomID", "ClassroomID", quiz.ClassroomID);
            return View(quiz);
        }

        // GET: Quizs/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = _quizService.GetQuizAndRelatedById(id.Value);
            if (quiz == null)
            {
                return NotFound();
            }

            return View(quiz);
        }

        // POST: Quizs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
			    _quizService.DeleteQuiz(id);
			    return RedirectToAction(nameof(Index));
        }
    }
}
