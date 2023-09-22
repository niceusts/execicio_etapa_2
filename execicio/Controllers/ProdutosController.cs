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
    public class ProdutosController : Controller
    {
        private readonly ExecicioContext _context;

        public ProdutosController(ExecicioContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var produtoComCategoria = await _context.produto
                .Include(v => v.categoria).ToListAsync();
            return View(produtoComCategoria);
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.produto == null)
            {
                return NotFound();
            }

            var produto = await _context.produto
                .FirstOrDefaultAsync(m => m.id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            // Obtenha a lista de matrículas de vendedores disponíveis no banco de dados
            var listaDeMatriculas = _context.vendedor.Select(v => new SelectListItem
            {
                Value = v.matricula_aluno,
                Text = v.matricula_aluno
            }).ToList();// Obtenha a lista de matrículas de vendedores disponíveis no banco de dados

            // Adicione a lista de matrículas à ViewBag
            ViewBag.ListaDeMatriculas = listaDeMatriculas;

            var ListaDeCategorias = _context.categoria.Select(v => new SelectListItem
            {
                Value = v.id.ToString(),
                Text = v.nome
            }).ToList();

            // Adicione a lista de matrículas à ViewBag
            ViewBag.ListaDeCategorias = ListaDeCategorias;

            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,descricao,id_categoria,foto,matricula_vendedor,data_cadastro")] Produto produto)
        {

            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var ListaDeCategorias = _context.categoria.Select(v => new SelectListItem
            {
                Value = v.id.ToString(),
                Text = v.nome
            }).ToList();

            ViewBag.listaCategorias = ListaDeCategorias;   
            // Se o modelo não for válido, recupere a lista de matrículas novamente
            var listaDeMatriculas = _context.vendedor.Select(v => new SelectListItem
            {
                Value = v.matricula_aluno,
                Text = v.matricula_aluno
            }).ToList();

            // Adicione a lista de matrículas à ViewBag para reexibir no formulário
            ViewBag.ListaDeMatriculas = listaDeMatriculas;

            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.produto == null)
            {
                return NotFound();
            }

            var produto = await _context.produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,descricao,id_categoria,foto,matricula_vendedor,data_cadastro")] Produto produto)
        {
            if (id != produto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.id))
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
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.produto == null)
            {
                return NotFound();
            }

            var produto = await _context.produto
                .FirstOrDefaultAsync(m => m.id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.produto == null)
            {
                return Problem("Entity set 'ExecicioContext.Produto'  is null.");
            }
            var produto = await _context.produto.FindAsync(id);
            if (produto != null)
            {
                _context.produto.Remove(produto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
          return _context.produto.Any(e => e.id == id);
        }
    }
}
