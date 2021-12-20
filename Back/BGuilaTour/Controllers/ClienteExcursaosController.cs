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
    public class ClienteExcursaosController : Controller
    {
        private readonly BGuilaTourBDContext _context;

        public ClienteExcursaosController(BGuilaTourBDContext context)
        {
            _context = context;
        }

        // GET: ClienteExcursaos
        public async Task<IActionResult> Index()
        {
            var bGuilaTourBDContext = _context.ClienteExcursaos.Include(c => c.NClienteNavigation).Include(c => c.NExcursaoNavigation);
            return View(await bGuilaTourBDContext.ToListAsync());
        }

        // GET: ClienteExcursaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteExcursao = await _context.ClienteExcursaos
                .Include(c => c.NClienteNavigation)
                .Include(c => c.NExcursaoNavigation)
                .FirstOrDefaultAsync(m => m.IdClieEx == id);
            if (clienteExcursao == null)
            {
                return NotFound();
            }

            return View(clienteExcursao);
        }

        // GET: ClienteExcursaos/Create
        public IActionResult Create()
        {
            ViewData["NCliente"] = new SelectList(_context.Clientes, "IdCliente", "Cpf");
            ViewData["NExcursao"] = new SelectList(_context.Excursaos, "IdExcursao", "Destino");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClieEx,NCliente,NExcursao")] ClienteExcursao clienteExcursao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteExcursao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NCliente"] = new SelectList(_context.Clientes, "IdCliente", "Cpf", clienteExcursao.NCliente);
            ViewData["NExcursao"] = new SelectList(_context.Excursaos, "IdExcursao", "Destino", clienteExcursao.NExcursao);
            return View(clienteExcursao);
        }

        // GET: ClienteExcursaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteExcursao = await _context.ClienteExcursaos.FindAsync(id);
            if (clienteExcursao == null)
            {
                return NotFound();
            }
            ViewData["NCliente"] = new SelectList(_context.Clientes, "IdCliente", "Cpf", clienteExcursao.NCliente);
            ViewData["NExcursao"] = new SelectList(_context.Excursaos, "IdExcursao", "Destino", clienteExcursao.NExcursao);
            return View(clienteExcursao);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClieEx,NCliente,NExcursao")] ClienteExcursao clienteExcursao)
        {
            if (id != clienteExcursao.IdClieEx)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteExcursao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExcursaoExists(clienteExcursao.IdClieEx))
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
            ViewData["NCliente"] = new SelectList(_context.Clientes, "IdCliente", "Cpf", clienteExcursao.NCliente);
            ViewData["NExcursao"] = new SelectList(_context.Excursaos, "IdExcursao", "Destino", clienteExcursao.NExcursao);
            return View(clienteExcursao);
        }

        // GET: ClienteExcursaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteExcursao = await _context.ClienteExcursaos
                .Include(c => c.NClienteNavigation)
                .Include(c => c.NExcursaoNavigation)
                .FirstOrDefaultAsync(m => m.IdClieEx == id);
            if (clienteExcursao == null)
            {
                return NotFound();
            }

            return View(clienteExcursao);
        }

        // POST: ClienteExcursaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteExcursao = await _context.ClienteExcursaos.FindAsync(id);
            _context.ClienteExcursaos.Remove(clienteExcursao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExcursaoExists(int id)
        {
            return _context.ClienteExcursaos.Any(e => e.IdClieEx == id);
        }
    }
}
