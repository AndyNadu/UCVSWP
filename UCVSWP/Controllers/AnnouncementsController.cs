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
	public class AnnouncementsController : Controller
	{
		private readonly IAnnouncementService _announcementService;

		public AnnouncementsController(IAnnouncementService announcementService)
		{
			_announcementService = announcementService;
		}

		// GET: Announcements
		public IActionResult Index()
		{
			var announcements = _announcementService.GetAllAnnouncements();
			return View(announcements);
		}

		// GET: Announcements/Details/5
		public IActionResult Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var announcement = _announcementService.GetAnnouncementById(id.Value);

			if (announcement == null)
			{
				return NotFound();
			}

			return View(announcement);
		}

		// GET: Announcements/Create
		public IActionResult Create()
		{
			var classrooms = _announcementService.GetAllClassrooms();
			ViewData["ClassroomID"] = new SelectList(classrooms, "ClassroomID", "Name");
			return View();
		}

		// POST: Announcements/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("AnnouncementID,Title,Content,ClassroomID")] Announcement announcement)
		{
			if (ModelState.IsValid)
			{
				_announcementService.AddAnnouncement(announcement);
				return RedirectToAction(nameof(Index));
			}
			var classrooms = _announcementService.GetAllClassrooms();
			ViewData["ClassroomID"] = new SelectList(classrooms, "ClassroomID", "Name", announcement.ClassroomID);
			return View(announcement);
		}

		// GET: Announcements/Edit/5
		public IActionResult Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var announcement = _announcementService.GetAnnouncementById(id.Value);

			if (announcement == null)
			{
				return NotFound();
			}
			var classrooms = _announcementService.GetAllClassrooms();	
			ViewData["ClassroomID"] = new SelectList(classrooms, "ClassroomID", "Name", announcement.ClassroomID);
			return View(announcement);
		}

		// POST: Announcements/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("AnnouncementID,Title,Content,ClassroomID")] Announcement announcement)
		{
			if (id != announcement.AnnouncementID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_announcementService.UpdateAnnouncement(announcement);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!_announcementService.AnnouncementExists(announcement.AnnouncementID))
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
			var classrooms = _announcementService.GetAllClassrooms();
			ViewData["ClassroomID"] = new SelectList(classrooms, "ClassroomID", "Name", announcement.ClassroomID);
			return View(announcement);
		}

		// GET: Announcements/Delete/5
		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var announcement = _announcementService.GetAnnouncementAndRelatedById(id.Value);

			if (announcement == null)
			{
				return NotFound();
			}

			return View(announcement);
		}

		// POST: Announcements/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var announcement = _announcementService.GetAnnouncementById(id);

			if (announcement != null)
			{
				_announcementService.DeleteAnnouncement(id);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}

