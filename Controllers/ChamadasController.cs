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
    [Authorize(Roles ="Monitor,Admin,Assistente")]

    public class ChamadasController : Controller
    {
        private readonly Contexto _context;

        public ChamadasController(Contexto context)
        {
            _context = context;
        }

        // GET: Chamadas
        public async Task<IActionResult> Index(string descricao, int? cursoID, int? monitorID, int? professorID)
        {
            var turmas = _context.Turma
                .Include(t => t.curso)
                .Include(t => t.monitor)
                .Include(t => t.professor)
                .Include(t => t.horarioDasAulas)
                .AsQueryable();

            if (!string.IsNullOrEmpty(descricao))
            {
                turmas = turmas.Where(t => t.descricao.Contains(descricao));
            }
            if (cursoID.HasValue)
            {
                turmas = turmas.Where(t => t.cursoID == cursoID);
            }
            if (monitorID.HasValue)
            {
                turmas = turmas.Where(t => t.monitorID == monitorID);
            }
            if (professorID.HasValue)
            {
                turmas = turmas.Where(t => t.professorID == professorID);
            }

            DateOnly dataHoje = DateOnly.FromDateTime(DateTime.Now);
            turmas = turmas.Where(t => !_context.Matriculas
                .Any(m => m.turmaID == t.Id && m.data == dataHoje));

            var turmasComHorarios = await turmas.ToListAsync();

            ViewBag.cursoID = new SelectList(await _context.Curso.ToListAsync(), "Id", "nome", cursoID);
            ViewBag.monitorID = new SelectList(await _context.Monitor.ToListAsync(), "Id", "nome", monitorID);
            ViewBag.professorID = new SelectList(await _context.Professor.ToListAsync(), "Id", "nome", professorID);

            return View(turmasComHorarios);
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

                    var status = item.Value == 1;  

                    var chamada = new Chamada
                    {
                        matriculaID = matriculaID,
                        status = status,  
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
