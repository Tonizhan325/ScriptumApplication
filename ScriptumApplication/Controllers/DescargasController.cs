using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptumApplication.Data;
using ScriptumApplication.Models;

namespace ScriptumApplication.Controllers
{
    public class DescargasController : Controller
    {
        private readonly ScriptumContexto _context;

        public DescargasController(ScriptumContexto context)
        {
            _context = context;
        }

        // GET: Descargas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Descargas.ToListAsync());
        }

        // GET: Descargas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descarga = await _context.Descargas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (descarga == null)
            {
                return NotFound();
            }

            return View(descarga);
        }

        // GET: Descargas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Descargas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,IdLibro,FechaDescarga,Ip")] Descarga descarga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(descarga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(descarga);
        }

        // GET: Descargas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descarga = await _context.Descargas.FindAsync(id);
            if (descarga == null)
            {
                return NotFound();
            }
            return View(descarga);
        }

        // POST: Descargas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUsuario,IdLibro,FechaDescarga,Ip")] Descarga descarga)
        {
            if (id != descarga.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(descarga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescargaExists(descarga.Id))
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
            return View(descarga);
        }

        // GET: Descargas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descarga = await _context.Descargas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (descarga == null)
            {
                return NotFound();
            }

            return View(descarga);
        }

        // POST: Descargas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var descarga = await _context.Descargas.FindAsync(id);
            if (descarga != null)
            {
                _context.Descargas.Remove(descarga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescargaExists(int id)
        {
            return _context.Descargas.Any(e => e.Id == id);
        }
    }
}
