using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using execicio.Data;
using execicio.Models;

namespace execicio.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ExecicioContext _context;

        public VendedoresController(ExecicioContext context)
        {
            _context = context;
        }

        // GET: Vendedores
        public async Task<IActionResult> Index()
        {
            var vendedoresComAlunos = await _context.vendedor
                .Include(v => v.aluno).ToListAsync();
            return View(vendedoresComAlunos);
        }

        // GET: Vendedores/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.vendedor == null)
            {
                return NotFound();
            }

            var vendedor = await _context.vendedor
                .FirstOrDefaultAsync(m => m.matricula_aluno == id);
            if (vendedor == null)
            {
                return NotFound();
            }

          

            return View(vendedor);
        }

        // GET: Vendedores/Create
        public IActionResult Create()
        {
            var listaDeMatriculas = _context.vendedor.Select(v => new SelectListItem
            {
                Value = v.matricula_aluno,
                Text = v.matricula_aluno
            }).ToList();

            ViewBag.ListaDeMatriculas = listaDeMatriculas;

            return View();
        }

        // POST: Vendedores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("matricula_aluno,habilitado_desde,leiloes_criados,impedido")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var listaDeMatriculas = _context.vendedor.Select(v => new SelectListItem
            {
                Value = v.matricula_aluno,
                Text = v.matricula_aluno
            }).ToList();

            ViewBag.ListaDeMatriculas = listaDeMatriculas;

            return View(vendedor);
        }

        // GET: Vendedores/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.vendedor == null)
            {
                return NotFound();
            }

            var vendedor = await _context.vendedor.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            return View(vendedor);
        }

        // POST: Vendedores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("matricula_aluno,habilitado_desde,leiloes_criados,impedido")] Vendedor vendedor)
        {
            if (id != vendedor.matricula_aluno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedorExists(vendedor.matricula_aluno))
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
            return View(vendedor);
        }

        // GET: Vendedores/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.vendedor == null)
            {
                return NotFound();
            }

            var vendedor = await _context.vendedor
                .FirstOrDefaultAsync(m => m.matricula_aluno == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        // POST: Vendedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.vendedor == null)
            {
                return Problem("Entity set 'ExecicioContext.Vendedor'  is null.");
            }
            var vendedor = await _context.vendedor.FindAsync(id);
            if (vendedor != null)
            {
                _context.vendedor.Remove(vendedor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorExists(string id)
        {
          return _context.vendedor.Any(e => e.matricula_aluno == id);
        }
    }
}
