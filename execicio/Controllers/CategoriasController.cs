using execicio.Data;
using execicio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace execicio.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ExecicioContext _context;

        public CategoriasController(ExecicioContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.categoria.ToListAsync());
        }

        // GET: categoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.categoria
                .FirstOrDefaultAsync(m => m.id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: categoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: categoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?Linkid=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        // GET: categoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: categoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?Linkid=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,descricao")] Categoria categoria)
        {
            if (id != categoria.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.id))
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
            return View(categoria);
        }

        // GET: categoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.categoria == null)
            {
                return NotFound();
            }

            var categoria = await _context.categoria
                .FirstOrDefaultAsync(m => m.id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.categoria == null)
            {
                return Problem("Entity set 'execicioContext.Categoria'  is null.");
            }
            var categoria = await _context.categoria.FindAsync(id);
            if (categoria != null)
            {
                _context.categoria.Remove(categoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return _context.categoria.Any(e => e.id == id);
        }
    }
}
