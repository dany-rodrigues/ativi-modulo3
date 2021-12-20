using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BGuilaTour.Models;

namespace BGuilaTour.Controllers
{
    public class ExcursaosController : Controller
    {
        private readonly BGuilaTourBDContext _context;

        public ExcursaosController(BGuilaTourBDContext context)
        {
            _context = context;
        }

        // GET: Excursaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Excursaos.ToListAsync());
        }

        // GET: Excursaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excursao = await _context.Excursaos
                .FirstOrDefaultAsync(m => m.IdExcursao == id);
            if (excursao == null)
            {
                return NotFound();
            }

            return View(excursao);
        }

        // GET: Excursaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Excursaos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdExcursao,Descricao,Origem,Destino,DataIda,DataVolta,Valor")] Excursao excursao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(excursao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(excursao);
        }

        // GET: Excursaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excursao = await _context.Excursaos.FindAsync(id);
            if (excursao == null)
            {
                return NotFound();
            }
            return View(excursao);
        }

        // POST: Excursaos/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdExcursao,Descricao,Origem,Destino,DataIda,DataVolta,Valor")] Excursao excursao)
        {
            if (id != excursao.IdExcursao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(excursao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExcursaoExists(excursao.IdExcursao))
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
            return View(excursao);
        }

        // GET: Excursaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var excursao = await _context.Excursaos
                .FirstOrDefaultAsync(m => m.IdExcursao == id);
            if (excursao == null)
            {
                return NotFound();
            }

            return View(excursao);
        }

        // POST: Excursaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var excursao = await _context.Excursaos.FindAsync(id);
            _context.Excursaos.Remove(excursao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExcursaoExists(int id)
        {
            return _context.Excursaos.Any(e => e.IdExcursao == id);
        }
    }
}
