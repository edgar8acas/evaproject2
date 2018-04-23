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
    public class ConvocatoriasController : Controller
    {
        private readonly Evaproject2Context _context;

        public ConvocatoriasController(Evaproject2Context context)
        {
            _context = context;
        }

        // GET: Convocatorias
        public async Task<IActionResult> Index()
        {
            var evaproject2Context = _context.Convocatoria.Include(c => c.Criterio);
            return View(await evaproject2Context.ToListAsync());
        }

        // GET: Convocatorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convocatoria = await _context.Convocatoria
                .Include(c => c.Criterio)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (convocatoria == null)
            {
                return NotFound();
            }

            return View(convocatoria);
        }

        // GET: Convocatorias/Create
        public IActionResult Create()
        {
            ViewData["CriterioID"] = new SelectList(_context.Set<Criterio>(), "ID", "ID");
            return View();
        }

        // POST: Convocatorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,FRegistro,FEnvio,FEvaluacion,FResultados,NoParticipantes,NoEvaluadores,CriterioID,RutaDescripcion,RutaResultados,FC,FM")] Convocatoria convocatoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convocatoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CriterioID"] = new SelectList(_context.Set<Criterio>(), "ID", "ID", convocatoria.CriterioID);
            return View(convocatoria);
        }

        // GET: Convocatorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convocatoria = await _context.Convocatoria.SingleOrDefaultAsync(m => m.ID == id);
            if (convocatoria == null)
            {
                return NotFound();
            }
            ViewData["CriterioID"] = new SelectList(_context.Set<Criterio>(), "ID", "ID", convocatoria.CriterioID);
            return View(convocatoria);
        }

        // POST: Convocatorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,FRegistro,FEnvio,FEvaluacion,FResultados,NoParticipantes,NoEvaluadores,CriterioID,RutaDescripcion,RutaResultados,FC,FM")] Convocatoria convocatoria)
        {
            if (id != convocatoria.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convocatoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConvocatoriaExists(convocatoria.ID))
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
            ViewData["CriterioID"] = new SelectList(_context.Set<Criterio>(), "ID", "ID", convocatoria.CriterioID);
            return View(convocatoria);
        }

        // GET: Convocatorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var convocatoria = await _context.Convocatoria
                .Include(c => c.Criterio)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (convocatoria == null)
            {
                return NotFound();
            }

            return View(convocatoria);
        }

        // POST: Convocatorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var convocatoria = await _context.Convocatoria.SingleOrDefaultAsync(m => m.ID == id);
            _context.Convocatoria.Remove(convocatoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConvocatoriaExists(int id)
        {
            return _context.Convocatoria.Any(e => e.ID == id);
        }
    }
}
