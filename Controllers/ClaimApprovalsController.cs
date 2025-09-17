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
    public class ClaimApprovalsController : Controller
    {
        private readonly POEOneContext _context;

        public ClaimApprovalsController(POEOneContext context)
        {
            _context = context;
        }

        // GET: ClaimApprovals
        public async Task<IActionResult> Index()
        {
            var pOEOneContext = _context.ClaimApproval.Include(c => c.Lecturers);
            return View(await pOEOneContext.ToListAsync());
        }

        // GET: ClaimApprovals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimApproval = await _context.ClaimApproval
                .Include(c => c.Lecturers)
                .FirstOrDefaultAsync(m => m.ClaimApprovalId == id);
            if (claimApproval == null)
            {
                return NotFound();
            }

            return View(claimApproval);
        }

        // GET: ClaimApprovals/Create
        public IActionResult Create()
        {
            ViewData["LecturerID"] = new SelectList(_context.Set<Lecturer>(), "LecturerID", "LecturerID");
            return View();
        }

        // POST: ClaimApprovals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClaimApprovalId,Approver,ApprovalDate,Approve,LecturerID")] ClaimApproval claimApproval)
        {
            if (ModelState.IsValid)
            {
                _context.Add(claimApproval);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LecturerID"] = new SelectList(_context.Set<Lecturer>(), "LecturerID", "LecturerID", claimApproval.LecturerID);
            return View(claimApproval);
        }

        // GET: ClaimApprovals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimApproval = await _context.ClaimApproval.FindAsync(id);
            if (claimApproval == null)
            {
                return NotFound();
            }
            ViewData["LecturerID"] = new SelectList(_context.Set<Lecturer>(), "LecturerID", "LecturerID", claimApproval.LecturerID);
            return View(claimApproval);
        }

        // POST: ClaimApprovals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClaimApprovalId,Approver,ApprovalDate,Approve,LecturerID")] ClaimApproval claimApproval)
        {
            if (id != claimApproval.ClaimApprovalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claimApproval);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaimApprovalExists(claimApproval.ClaimApprovalId))
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
            ViewData["LecturerID"] = new SelectList(_context.Set<Lecturer>(), "LecturerID", "LecturerID", claimApproval.LecturerID);
            return View(claimApproval);
        }

        // GET: ClaimApprovals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claimApproval = await _context.ClaimApproval
                .Include(c => c.Lecturers)
                .FirstOrDefaultAsync(m => m.ClaimApprovalId == id);
            if (claimApproval == null)
            {
                return NotFound();
            }

            return View(claimApproval);
        }

        // POST: ClaimApprovals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var claimApproval = await _context.ClaimApproval.FindAsync(id);
            if (claimApproval != null)
            {
                _context.ClaimApproval.Remove(claimApproval);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClaimApprovalExists(int id)
        {
            return _context.ClaimApproval.Any(e => e.ClaimApprovalId == id);
        }
    }
}
