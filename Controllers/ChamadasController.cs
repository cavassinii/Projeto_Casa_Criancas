using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Casa_Criancas.Models;

namespace Projeto_Casa_Criancas.Controllers
{
    //[Authorize(Roles ="Monitor,Admin,Assistente")]

    public class ChamadasController : Controller
    {
        private readonly Contexto _context;

        public ChamadasController(Contexto context)
        {
            _context = context;
        }

        // GET: Chamadas
        public async Task<IActionResult> Index(int cursoID = 0, int monitorID = 0)
        {
            List<Turma> listaTurmas = new List<Turma>();

            var filtro = _context.Turma
                .Include(c => c.curso)
                .Include(m => m.monitor)
                .Include(p => p.professor)
                .AsQueryable();

            if (cursoID != 0)
            {
                filtro = filtro.Where(a => a.cursoID == cursoID);
            }
            if (monitorID != 0)
            {
                filtro = filtro.Where(a => a.monitorID == monitorID);
            }

            listaTurmas = await filtro.OrderBy(a => a.descricao).ToListAsync();

            ViewData["cursoID"] = new SelectList(_context.Curso, "Id", "nome", cursoID);
            ViewData["monitorID"] = new SelectList(_context.Monitor, "Id", "nome", monitorID);

            return View(listaTurmas);
        }

        // GET: Chamadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamada = await _context.Chamada
                .Include(c => c.matricula)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chamada == null)
            {
                return NotFound();
            }

            return View(chamada);
        }

        // GET: Chamadas/Create
        public IActionResult Create()
        {

            ViewData["matriculaID"] = new SelectList(_context.Matriculas, "Id", "Id");
            return View();
        }

        // POST: Chamadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,matriculaID,data,status")] Chamada chamada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chamada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["matriculaID"] = new SelectList(_context.Matriculas, "Id", "Id", chamada.matriculaID);
            return View(chamada);
        }

        // Método GET
        public async Task<IActionResult> EfetuarChamada(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }

            var matriculas = await _context.Matriculas
                .Where(m => m.turmaID == id)
                .Include(m => m.aluno)
                .ToListAsync();

            ViewBag.Turma = turma;
            return View(matriculas); 
        }


        // Método POST
        [HttpPost]
        public async Task<IActionResult> EfetuarChamada(int turmaID, Dictionary<int, int> matriculas)
        {
            if (matriculas != null && matriculas.Any())
            {
                foreach (var item in matriculas)
                {
                    var matriculaID = item.Key;

                    // O valor de 'item.Value' será 1 (Presente) ou 0 (Ocioso)
                    var status = item.Value == 1;  // Converte 1 para true (Presente) e 0 para false (Ocioso)

                    var chamada = new Chamada
                    {
                        matriculaID = matriculaID,
                        status = status,  // O status será true para "Presente" ou false para "Ocioso"
                        data = DateOnly.FromDateTime(DateTime.Now)
                    };

                    _context.Chamada.Add(chamada);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        // GET: Chamadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamada = await _context.Chamada
                .Include(c => c.matricula)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chamada == null)
            {
                return NotFound();
            }

            return View(chamada);
        }

        // POST: Chamadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chamada = await _context.Chamada.FindAsync(id);
            if (chamada != null)
            {
                _context.Chamada.Remove(chamada);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamadaExists(int id)
        {
            return _context.Chamada.Any(e => e.Id == id);
        }
    }
}
