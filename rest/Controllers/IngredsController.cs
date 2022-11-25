using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rest.Data;
using rest.Models;

namespace rest.Controllers
{
    public class IngredsController : Controller
    {
        private readonly restContext _context;

        public IngredsController(restContext context)
        {
            _context = context;
        }

        // GET: Ingreds
        public async Task<IActionResult> Index()
        {
            var restContext = _context.Ingreds.Include(i => i.Unit);
            return View(await restContext.ToListAsync());
        }

        // GET: Ingreds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ingreds == null)
            {
                return NotFound();
            }

            var ingred = await _context.Ingreds
                .Include(i => i.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingred == null)
            {
                return NotFound();
            }

            return View(ingred);
        }

        // GET: Ingreds/Create
        public IActionResult Create()
        {
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id");
            return View();
        }

        // POST: Ingreds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UnitId,Kkal")] Ingred ingred)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingred);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", ingred.UnitId);
            return View(ingred);
        }

        // GET: Ingreds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ingreds == null)
            {
                return NotFound();
            }

            var ingred = await _context.Ingreds.FindAsync(id);
            if (ingred == null)
            {
                return NotFound();
            }
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", ingred.UnitId);
            return View(ingred);
        }

        // POST: Ingreds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UnitId,Kkal")] Ingred ingred)
        {
            if (id != ingred.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingred);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredExists(ingred.Id))
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
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Id", ingred.UnitId);
            return View(ingred);
        }

        // GET: Ingreds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ingreds == null)
            {
                return NotFound();
            }

            var ingred = await _context.Ingreds
                .Include(i => i.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingred == null)
            {
                return NotFound();
            }

            return View(ingred);
        }

        // POST: Ingreds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ingreds == null)
            {
                return Problem("Entity set 'restContext.Ingreds'  is null.");
            }
            var ingred = await _context.Ingreds.FindAsync(id);
            if (ingred != null)
            {
                _context.Ingreds.Remove(ingred);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredExists(int id)
        {
          return _context.Ingreds.Any(e => e.Id == id);
        }
    }
}
