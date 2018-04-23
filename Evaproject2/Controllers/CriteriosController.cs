using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Evaproject2.Models;

namespace Evaproject2.Controllers
{
    public class CriteriosController : Controller
    {
        private readonly Evaproject2Context _context;

        public CriteriosController(Evaproject2Context context)
        {
            _context = context;
        }

        // GET: Criterios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Criterio.ToListAsync());
        }

        // GET: Criterios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criterio = await _context.Criterio
                .SingleOrDefaultAsync(m => m.ID == id);
            if (criterio == null)
            {
                return NotFound();
            }

            return View(criterio);
        }

        // GET: Criterios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Criterios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Calificacion,FC,FM")] Criterio criterio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(criterio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(criterio);
        }

        // GET: Criterios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criterio = await _context.Criterio.SingleOrDefaultAsync(m => m.ID == id);
            if (criterio == null)
            {
                return NotFound();
            }
            return View(criterio);
        }

        // POST: Criterios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Calificacion,FC,FM")] Criterio criterio)
        {
            if (id != criterio.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(criterio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CriterioExists(criterio.ID))
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
            return View(criterio);
        }

        // GET: Criterios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var criterio = await _context.Criterio
                .SingleOrDefaultAsync(m => m.ID == id);
            if (criterio == null)
            {
                return NotFound();
            }

            return View(criterio);
        }

        // POST: Criterios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var criterio = await _context.Criterio.SingleOrDefaultAsync(m => m.ID == id);
            _context.Criterio.Remove(criterio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CriterioExists(int id)
        {
            return _context.Criterio.Any(e => e.ID == id);
        }
    }
}
