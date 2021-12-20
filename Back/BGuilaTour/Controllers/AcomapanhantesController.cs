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
    public class AcomapanhantesController : Controller
    {
        private readonly BGuilaTourBDContext _context;

        public AcomapanhantesController(BGuilaTourBDContext context)
        {
            _context = context;
        }

        // GET: Acomapanhantes
        public async Task<IActionResult> Index()
        {
            var bGuilaTourBDContext = _context.Acomapanhantes.Include(a => a.ResponsavelNavigation);
            return View(await bGuilaTourBDContext.ToListAsync());
        }

        // GET: Acomapanhantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acomapanhante = await _context.Acomapanhantes
                .Include(a => a.ResponsavelNavigation)
                .FirstOrDefaultAsync(m => m.IdAcompanhante == id);
            if (acomapanhante == null)
            {
                return NotFound();
            }

            return View(acomapanhante);
        }

        // GET: Acomapanhantes/Create
        public IActionResult Create()
        {
            ViewData["Responsavel"] = new SelectList(_context.Clientes, "IdCliente", "Cpf");
            return View();
        }

        // POST: Acomapanhantes/Create
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAcompanhante,Nome,DataNasc,Cpf,Responsavel")] Acomapanhante acomapanhante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acomapanhante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Responsavel"] = new SelectList(_context.Clientes, "IdCliente", "Cpf", acomapanhante.Responsavel);
            return View(acomapanhante);
        }

        // GET: Acomapanhantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acomapanhante = await _context.Acomapanhantes.FindAsync(id);
            if (acomapanhante == null)
            {
                return NotFound();
            }
            ViewData["Responsavel"] = new SelectList(_context.Clientes, "IdCliente", "Cpf", acomapanhante.Responsavel);
            return View(acomapanhante);
        }

        // POST: Acomapanhantes/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAcompanhante,Nome,DataNasc,Cpf,Responsavel")] Acomapanhante acomapanhante)
        {
            if (id != acomapanhante.IdAcompanhante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acomapanhante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcomapanhanteExists(acomapanhante.IdAcompanhante))
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
            ViewData["Responsavel"] = new SelectList(_context.Clientes, "IdCliente", "Cpf", acomapanhante.Responsavel);
            return View(acomapanhante);
        }

        // GET: Acomapanhantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acomapanhante = await _context.Acomapanhantes
                .Include(a => a.ResponsavelNavigation)
                .FirstOrDefaultAsync(m => m.IdAcompanhante == id);
            if (acomapanhante == null)
            {
                return NotFound();
            }

            return View(acomapanhante);
        }

        // POST: Acomapanhantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acomapanhante = await _context.Acomapanhantes.FindAsync(id);
            _context.Acomapanhantes.Remove(acomapanhante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcomapanhanteExists(int id)
        {
            return _context.Acomapanhantes.Any(e => e.IdAcompanhante == id);
        }
    }
}
