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
    public class FileUpLoadsController : Controller
    {
        private readonly POEOneContext _context;

        public FileUpLoadsController(POEOneContext context)
        {
            _context = context;
        }

        // GET: FileUpLoads
        public async Task<IActionResult> Index()
        {
            return View(await _context.FileUpLoad.ToListAsync());
        }

        // GET: FileUpLoads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileUpLoad = await _context.FileUpLoad
                .FirstOrDefaultAsync(m => m.Name == id);
            if (fileUpLoad == null)
            {
                return NotFound();
            }

            return View(fileUpLoad);
        }

        // GET: FileUpLoads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FileUpLoads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Size,LastModified")] FileUpLoad fileUpLoad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fileUpLoad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileUpLoad);
        }

        // GET: FileUpLoads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileUpLoad = await _context.FileUpLoad.FindAsync(id);
            if (fileUpLoad == null)
            {
                return NotFound();
            }
            return View(fileUpLoad);
        }

        // POST: FileUpLoads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Size,LastModified")] FileUpLoad fileUpLoad)
        {
            if (id != fileUpLoad.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileUpLoad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileUpLoadExists(fileUpLoad.Name))
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
            return View(fileUpLoad);
        }

        // GET: FileUpLoads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileUpLoad = await _context.FileUpLoad
                .FirstOrDefaultAsync(m => m.Name == id);
            if (fileUpLoad == null)
            {
                return NotFound();
            }

            return View(fileUpLoad);
        }

        // POST: FileUpLoads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var fileUpLoad = await _context.FileUpLoad.FindAsync(id);
            if (fileUpLoad != null)
            {
                _context.FileUpLoad.Remove(fileUpLoad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileUpLoadExists(string id)
        {
            return _context.FileUpLoad.Any(e => e.Name == id);
        }
    }
}
