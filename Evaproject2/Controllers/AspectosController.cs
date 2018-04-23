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
    public class AspectosController : Controller
    {
        private readonly Evaproject2Context _context;

        public AspectosController(Evaproject2Context context)
        {
            _context = context;
        }

        // GET: Aspectos
        public async Task<IActionResult> Index()
        {
            var evaproject2Context = _context.Aspecto.Include(a => a.Criterio);
            return View(await evaproject2Context.ToListAsync());
        }

        // GET: Aspectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspecto = await _context.Aspecto
                .Include(a => a.Criterio)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (aspecto == null)
            {
                return NotFound();
            }

            return View(aspecto);
        }

        // GET: Aspectos/Create
        public IActionResult Create()
        {
            ViewData["CriterioID"] = new SelectList(_context.Set<Criterio>(), "ID", "ID");
            return View();
        }

        // POST: Aspectos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descripcion,Valor,Calificacion,CriterioID,FC,FM")] Aspecto aspecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CriterioID"] = new SelectList(_context.Set<Criterio>(), "ID", "ID", aspecto.CriterioID);
            return View(aspecto);
        }

        // GET: Aspectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspecto = await _context.Aspecto.SingleOrDefaultAsync(m => m.ID == id);
            if (aspecto == null)
            {
                return NotFound();
            }
            ViewData["CriterioID"] = new SelectList(_context.Set<Criterio>(), "ID", "ID", aspecto.CriterioID);
            return View(aspecto);
        }

        // POST: Aspectos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descripcion,Valor,Calificacion,CriterioID,FC,FM")] Aspecto aspecto)
        {
            if (id != aspecto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aspecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspectoExists(aspecto.ID))
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
            ViewData["CriterioID"] = new SelectList(_context.Set<Criterio>(), "ID", "ID", aspecto.CriterioID);
            return View(aspecto);
        }

        // GET: Aspectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspecto = await _context.Aspecto
                .Include(a => a.Criterio)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (aspecto == null)
            {
                return NotFound();
            }

            return View(aspecto);
        }

        // POST: Aspectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aspecto = await _context.Aspecto.SingleOrDefaultAsync(m => m.ID == id);
            _context.Aspecto.Remove(aspecto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspectoExists(int id)
        {
            return _context.Aspecto.Any(e => e.ID == id);
        }
    }
}
