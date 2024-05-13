using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCVSWP.Data;
using UCVSWP.Models;

namespace UCVSWP.Controllers
{
    public class FilesController : Controller
    {
        private readonly UCVSWPContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FilesController(UCVSWPContext context, UserManager<IdentityUser> usermanager)
        {
            _context = context;
            _userManager = usermanager;
        }

        // GET: Files
        public async Task<IActionResult> Index()
        {
            return _context.File != null ?
                View(await _context.File.Include(f => f.Assignment).Include(f => f.User).ToListAsync()) :
                Problem("Entity set 'UCVSWPContext.File'  is null.");
        }

        // GET: Files/Details/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.File == null)
            {
                return NotFound();
            }

            var @file = await _context.File
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@file == null)
            {
                return NotFound();
            }

            return View(@file);
        }

        // GET: Files/Create
        public IActionResult Create()
        {
            // populate the list of Assignments
            ViewBag.Assignments = new SelectList(_context.Assignment, "AssignmentID", "Name");
            return View();
        }

        // POST: Files/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile uploadedFile, Models.File file)
        {
            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                byte[] fileBytes;
                using (var stream = new MemoryStream())
                {
                    await uploadedFile.CopyToAsync(stream);
                    fileBytes = stream.ToArray();
                }

                file.FileName = uploadedFile.FileName;
                file.Attachment = fileBytes;

                var cusr = await _userManager.GetUserAsync(User);
                if (cusr == null)
                {
                    return View();
                }
                file.UserId = cusr.Id;

                // make sure AssignmentID is set
                if (file.AssignmentID == null)
                {
                    ModelState.AddModelError("AssignmentID", "Assignment is required");
                    ViewBag.Assignments = new SelectList(_context.Assignment, "AssignmentID", "Name");
                    return View(file);
                }

                _context.Add(file);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(file);
        }


        public async Task<IActionResult> Download(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var file = await _context.File
                .FirstOrDefaultAsync(m => m.ID == id);
            if (file == null)
            {
                return NotFound();
            }

            return File(file.Attachment, "application/pdf"); // Force download
        }




        // GET: Files/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.File == null)
            {
                return NotFound();
            }

            var @file = await _context.File.FindAsync(id);
            if (@file == null)
            {
                return NotFound();
            }
            return View(@file);
        }

        // POST: Files/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ID,Attachment")] Models.File @file)
        {
            if (id != @file.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@file);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileExists(@file.ID))
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
            return View(@file);
        }

        // GET: Files/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.File == null)
            {
                return NotFound();
            }

            var @file = await _context.File
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@file == null)
            {
                return NotFound();
            }

            return View(@file);
        }

        // POST: Files/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.File == null)
            {
                return Problem("Entity set 'UCVSWPContext.File'  is null.");
            }
            var @file = await _context.File.FindAsync(id);
            if (@file != null)
            {
                _context.File.Remove(@file);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileExists(int? id)
        {
          return (_context.File?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
