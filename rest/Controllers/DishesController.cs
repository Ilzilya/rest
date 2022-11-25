using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using rest.Data;
using rest.Models;

namespace rest.Controllers
{
    public class DishesController : Controller
    {
        private readonly restContext _context;

        public DishesController(restContext context)
        {
            _context = context;
        }

        // GET: Dishes
        public async Task<IActionResult> Index()
        {
            var restContext = _context.Dishes.Include(i => i.Category).Include(i=> i.Ingreds).ThenInclude(c=>c!.Ingred).ThenInclude(i=>i.Unit);
            return View(await restContext.ToListAsync());
        }

        // GET: Dishes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dishes == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // GET: Dishes/Create
        public IActionResult Create()
        {
            ViewBag.Ingreds = _context.Ingreds.ToList();
            ViewBag.Unit = _context.Units.ToList();
            SelectList categories = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.Categories = categories;
            return View();
        }

        // POST: Dishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Name,Description,Kkal,Cook_tech,Price,Menu,Img,Portion,Weight,Category")] Dish dish)
        public async Task<IActionResult> Create(Dish dish, int[] selectedIng, double[] Amt)
        { _context.Add(dish);
            await _context.SaveChangesAsync();
            if (selectedIng != null)
            {
                var vib = _context.IngredOnDish.Where(co => selectedIng.Contains(co.IngredId));//инг которые выбраны
                foreach (var c in vib)
                {
                    IngredOnDish ingondish = new IngredOnDish { Amt = Amt[c.IngredId - 1], DishId = dish.Id, IngredId = c.IngredId };
                    _context.IngredOnDish.Add(ingondish);
                    await _context.SaveChangesAsync();
                }
            }
           
                return RedirectToAction(nameof(Index));
            
            return View(dish);
        }

        // GET: Dishes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dishes == null)
            {
                return NotFound();
            }
            var dish1 = _context.Dishes.Include(i => i.Category).Include(i => i.Ingreds).ThenInclude(c => c!.Ingred).ThenInclude(i => i.Unit).Where(i => i.Id == id);
            var dish = (dish1.ToList())[0];
            if (dish == null)
            {
                return NotFound();
            }
            if (dish != null)
            {
                // Создаем список команд для передачи в представление
                
                SelectList teams = new SelectList(_context.Categories, "Id", "Name", dish.CategoryId);
                var result = from ingred in _context.IngredOnDish.Where(p => p.DishId == id) 
                             select new Ingred
                             { Id = ingred.Ingred.Id, Name = ingred.Ingred.Name, UnitId = ingred.Ingred.UnitId, Unit = ingred.Ingred.Unit, Kkal = ingred.Ingred.Kkal, Dishes = ingred.Ingred.Dishes };
                ViewBag.Teams = teams;
                ViewBag.Ingreds = _context.Ingreds.ToList();
                ViewBag.IngredOnDish = result.ToList();
                ViewBag.Unit= _context.Units.ToList();
                return View(dish);
            }
            return View(dish);
        }

        // POST: Dishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Kkal,Cook_tech,Price,Menu,Img,Portion,Weight,CategoryId")] Dish dish, int[] selectedIng, double[] Amt)
        {
            if (id != dish.Id)
            {
                return NotFound();
            }
                try
                {
                IngredOnDish ing=null;
                if (selectedIng != null)
                {
                    //получаем выбранные 
                    foreach (var c in _context.IngredOnDish.Where(co => !selectedIng.Contains(co.IngredId) && co.DishId==id))
                    {
                        _context.IngredOnDish.Remove(c);//удаляем из таблицы
                    }
                    var vib = _context.IngredOnDish.Where(co => selectedIng.Contains(co.IngredId));//инг которые выбраны
                    foreach (var c in vib)
                    {
                        
                        var d = _context.IngredOnDish.Where(p => p.IngredId == c.IngredId && p.DishId == id);//инг которые есть в таб
                        if (d.IsNullOrEmpty())//если инг нет то добавляем в табл
                        {
                            IngredOnDish ingondish = new IngredOnDish { Amt = Amt[c.IngredId - 1], DishId=id, IngredId=c.IngredId };
                            _context.IngredOnDish.Add(ingondish);
                        }
                        else if (c.Amt != Amt[c.IngredId-1]) { 
                            ing = _context.IngredOnDish.Find(c.Id);
                            ing.Amt = Amt[c.IngredId-1];
                        }
                    }
                }
                if (ing != null) _context.Update(ing);
                _context.Update(dish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishExists(dish.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            return View(dish);
        }

        // GET: Dishes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dishes == null)
            {
                return NotFound();
            }

            var dish = await _context.Dishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // POST: Dishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dishes == null)
            {
                return Problem("Entity set 'restContext.Dishes'  is null.");
            }
            var dish = await _context.Dishes.FindAsync(id);
            if (dish != null)
            {
                _context.Dishes.Remove(dish);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DishExists(int id)
        {
          return _context.Dishes.Any(e => e.Id == id);
        }
    }
}
