using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POEOne.Data;
using POEOne.Models;

namespace POEOne.Controllers
{
    public class StatusController : Controller
    {
        private readonly POEOneContext _context;

        public StatusController(POEOneContext context)
        {
            _context = context;
        }

        // GET: Status
        public async Task<IActionResult> Index()
        {
            var pOEOneContext = _context.Status.Include(s => s.ClaimApproval).Include(s => s.Lecturers);
            return View(await pOEOneContext.ToListAsync());
        }

        // GET: Status/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Status
                .Include(s => s.ClaimApproval)
                .Include(s => s.Lecturers)
                .FirstOrDefaultAsync(m => m.ClaimId == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // GET: Status/Create
        public IActionResult Create()
        {
            ViewData["ClaimApprovalId"] = new SelectList(_context.ClaimApproval, "ClaimApprovalId", "ClaimApprovalId");
            ViewData["LecturerID"] = new SelectList(_context.Lecturer, "LecturerID", "LecturerID");
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClaimId,LecturerID,ClaimApprovalId,Approve")] Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClaimApprovalId"] = new SelectList(_context.ClaimApproval, "ClaimApprovalId", "ClaimApprovalId", status.ClaimApprovalId);
            ViewData["LecturerID"] = new SelectList(_context.Lecturer, "LecturerID", "LecturerID", status.LecturerID);
            return View(status);
        }

        // GET: Status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            ViewData["ClaimApprovalId"] = new SelectList(_context.ClaimApproval, "ClaimApprovalId", "ClaimApprovalId", status.ClaimApprovalId);
            ViewData["LecturerID"] = new SelectList(_context.Lecturer, "LecturerID", "LecturerID", status.LecturerID);
            return View(status);
        }

        // POST: Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClaimId,LecturerID,ClaimApprovalId,Approve")] Status status)
        {
            if (id != status.ClaimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(status);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(status.ClaimId))
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
            ViewData["ClaimApprovalId"] = new SelectList(_context.ClaimApproval, "ClaimApprovalId", "ClaimApprovalId", status.ClaimApprovalId);
            ViewData["LecturerID"] = new SelectList(_context.Lecturer, "LecturerID", "LecturerID", status.LecturerID);
            return View(status);
        }

        // GET: Status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Status
                .Include(s => s.ClaimApproval)
                .Include(s => s.Lecturers)
                .FirstOrDefaultAsync(m => m.ClaimId == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var status = await _context.Status.FindAsync(id);
            if (status != null)
            {
                _context.Status.Remove(status);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusExists(int id)
        {
            return _context.Status.Any(e => e.ClaimId == id);
        }
    }
}
