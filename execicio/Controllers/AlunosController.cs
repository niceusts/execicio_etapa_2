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
    public class AlunosController : Controller
    {
        private readonly ExecicioContext _context;

        public AlunosController(ExecicioContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
              return View(await _context.aluno.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.aluno == null)
            {
                return NotFound();
            }

            var aluno = await _context.aluno
                .FirstOrDefaultAsync(m => m.matricula == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("matricula,nome,data_nascimemento,email,tipo_logradouro,nome_logradouro,numero,bairro,cidade,uf,cep,telefone,cpf")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.aluno == null)
            {
                return NotFound();
            }

            var aluno = await _context.aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("matricula,nome,data_nascimemento,email,tipo_logradouro,nome_logradouro,numero,bairro,cidade,uf,cep,telefone,cpf")] Aluno aluno)
        {
            if (id != aluno.matricula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.matricula))
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
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.aluno == null)
            {
                return NotFound();
            }

            var aluno = await _context.aluno
                .FirstOrDefaultAsync(m => m.matricula == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.aluno == null)
            {
                return Problem("Entity set 'ExecicioContext.aluno'  is null.");
            }
            var aluno = await _context.aluno.FindAsync(id);
            if (aluno != null)
            {
                _context.aluno.Remove(aluno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(string id)
        {
          return _context.aluno.Any(e => e.matricula == id);
        }
    }
}
