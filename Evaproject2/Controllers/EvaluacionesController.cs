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
    public class EvaluacionesController : Controller
    {
        private readonly Evaproject2Context _context;

        public EvaluacionesController(Evaproject2Context context)
        {
            _context = context;
        }

        // GET: Evaluaciones
        public async Task<IActionResult> Index()
        {
            var evaproject2Context = _context.Evaluacion.Include(e => e.Criterio);
            return View(await evaproject2Context.ToListAsync());
        }

        // GET: Evaluaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluacion
                .Include(e => e.Criterio)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            return View(evaluacion);
        }

        // GET: Evaluaciones/Create
        public IActionResult Create()
        {
            ViewData["CriterioID"] = new SelectList(_context.Criterio, "ID", "ID");
            return View();
        }

        // POST: Evaluaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CriterioID,EvaluadorID,InscripcionID,FC,FM")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(evaluacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CriterioID"] = new SelectList(_context.Criterio, "ID", "ID", evaluacion.CriterioID);
            return View(evaluacion);
        }

        // GET: Evaluaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluacion.SingleOrDefaultAsync(m => m.ID == id);
            if (evaluacion == null)
            {
                return NotFound();
            }
            ViewData["CriterioID"] = new SelectList(_context.Criterio, "ID", "ID", evaluacion.CriterioID);
            return View(evaluacion);
        }

        // POST: Evaluaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CriterioID,EvaluadorID,InscripcionID,FC,FM")] Evaluacion evaluacion)
        {
            if (id != evaluacion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evaluacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EvaluacionExists(evaluacion.ID))
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
            ViewData["CriterioID"] = new SelectList(_context.Criterio, "ID", "ID", evaluacion.CriterioID);
            return View(evaluacion);
        }

        // GET: Evaluaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluacion = await _context.Evaluacion
                .Include(e => e.Criterio)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (evaluacion == null)
            {
                return NotFound();
            }

            return View(evaluacion);
        }

        // POST: Evaluaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluacion = await _context.Evaluacion.SingleOrDefaultAsync(m => m.ID == id);
            _context.Evaluacion.Remove(evaluacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluacionExists(int id)
        {
            return _context.Evaluacion.Any(e => e.ID == id);
        }
    }
}
