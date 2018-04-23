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
    public class InscripcionesController : Controller
    {
        private readonly Evaproject2Context _context;

        public InscripcionesController(Evaproject2Context context)
        {
            _context = context;
        }

        // GET: Inscripciones
        public async Task<IActionResult> Index()
        {
            var evaproject2Context = _context.Inscripcion.Include(i => i.Convocatoria);
            return View(await evaproject2Context.ToListAsync());
        }

        // GET: Inscripciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion
                .Include(i => i.Convocatoria)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // GET: Inscripciones/Create
        public IActionResult Create()
        {
            ViewData["ConvocatoriaID"] = new SelectList(_context.Convocatoria, "ID", "ID");
            return View();
        }

        // POST: Inscripciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ConvocatoriaID,ParticipanteID,TipoInscripcion,PdfProyecto,FC,FM")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConvocatoriaID"] = new SelectList(_context.Convocatoria, "ID", "ID", inscripcion.ConvocatoriaID);
            return View(inscripcion);
        }

        // GET: Inscripciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion.SingleOrDefaultAsync(m => m.ID == id);
            if (inscripcion == null)
            {
                return NotFound();
            }
            ViewData["ConvocatoriaID"] = new SelectList(_context.Convocatoria, "ID", "ID", inscripcion.ConvocatoriaID);
            return View(inscripcion);
        }

        // POST: Inscripciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ConvocatoriaID,ParticipanteID,TipoInscripcion,PdfProyecto,FC,FM")] Inscripcion inscripcion)
        {
            if (id != inscripcion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscripcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscripcionExists(inscripcion.ID))
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
            ViewData["ConvocatoriaID"] = new SelectList(_context.Convocatoria, "ID", "ID", inscripcion.ConvocatoriaID);
            return View(inscripcion);
        }

        // GET: Inscripciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripcion
                .Include(i => i.Convocatoria)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            return View(inscripcion);
        }

        // POST: Inscripciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscripcion = await _context.Inscripcion.SingleOrDefaultAsync(m => m.ID == id);
            _context.Inscripcion.Remove(inscripcion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscripcionExists(int id)
        {
            return _context.Inscripcion.Any(e => e.ID == id);
        }
    }
}
