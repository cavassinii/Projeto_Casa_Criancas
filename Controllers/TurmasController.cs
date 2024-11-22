using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Casa_Criancas.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Projeto_Casa_Criancas.Controllers
{
    //[Authorize(Roles = "Admin,Assistente")]

    public class TurmasController : Controller
    {
        private readonly Contexto _context;

        public TurmasController(Contexto context)
        {
            _context = context;
        }


        // GET: Turmas/Index
        public async Task<IActionResult> Index(string descricao, int? cursoID, int? monitorID, int? professorID)
        {
            // Filtra as turmas conforme os parâmetros recebidos
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

            // Preenche as listas para os filtros no ViewBag
            ViewBag.cursoID = new SelectList(await _context.Curso.ToListAsync(), "Id", "nome", cursoID);
            ViewBag.monitorID = new SelectList(await _context.Monitor.ToListAsync(), "Id", "nome", monitorID);
            ViewBag.professorID = new SelectList(await _context.Professor.ToListAsync(), "Id", "nome", professorID);

            return View(await turmas.ToListAsync());
        }


        // GET: Turmas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma
                .Include(t => t.curso)
                .Include(t => t.monitor)
                .Include(t => t.professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // GET: Turmas/Create
        public IActionResult Create()
        {
            // Obtendo os horários formatados no formato desejado
            var horarios = _context.HorarioDasAulas
                .Select(h => new
                {
                    h.Id,
                    HorarioDescricao = $"{h.DiaDaSemana} - {h.HoraInicio} às {h.HoraFim}"
                }).ToList();

            // Preenchendo os SelectLists
            ViewData["cursoID"] = new SelectList(_context.Curso, "Id", "nome");
            ViewData["monitorID"] = new SelectList(_context.Monitor, "Id", "nome");
            ViewData["professorID"] = new SelectList(_context.Professor, "Id", "nome");

            // Adicionando a lista de horários formatados na ViewData
            ViewData["horarioDasAulasID"] = new SelectList(horarios, "Id", "HorarioDescricao");

            return View();
        }


        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,cursoID,monitorID,professorID,descricao,horarioDasAulasID")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Adicionando a turma ao contexto
                    _context.Add(turma);
                    await _context.SaveChangesAsync();

                    // Redireciona para a página de index
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Caso ocorra algum erro ao salvar, você pode registrar ou logar a exceção
                    // Por exemplo: _logger.LogError(ex, "Erro ao salvar a turma.");

                    // Se der erro, pode exibir uma mensagem de erro
                    ModelState.AddModelError(string.Empty, "Ocorreu um erro ao salvar a turma. Tente novamente.");
                }
            }

            // Se não for válido, repopula os campos de seleção
            var horarios = _context.HorarioDasAulas
                .Select(h => new
                {
                    h.Id,
                    HorarioDescricao = $"{h.DiaDaSemana} - {h.HoraInicio} às {h.HoraFim}"
                }).ToList();

            // Repopula as listas com os dados atuais
            ViewData["cursoID"] = new SelectList(_context.Curso, "Id", "nome", turma.cursoID);
            ViewData["monitorID"] = new SelectList(_context.Monitor, "Id", "nome", turma.monitorID);
            ViewData["professorID"] = new SelectList(_context.Professor, "Id", "nome", turma.professorID);
            ViewData["horarioDasAulasID"] = new SelectList(horarios, "Id", "HorarioDescricao", turma.horarioDasAulasID);

            // Retorna a view com a turma que contém erros
            return View(turma);
        }



        // GET: Turmas/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["cursoID"] = new SelectList(_context.Curso, "Id", "nome", turma.cursoID);
            ViewData["monitorID"] = new SelectList(_context.Monitor, "Id", "nome", turma.monitorID);
            ViewData["professorID"] = new SelectList(_context.Professor, "Id", "nome", turma.professorID);
            return View(turma);
        }

        


        // POST: Turmas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,cursoID,monitorID,professorID,descricao,dataHora")] Turma turma)
        {
            if (id != turma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurmaExists(turma.Id))
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
            ViewData["cursoID"] = new SelectList(_context.Curso, "Id", "nome", turma.cursoID);
            ViewData["monitorID"] = new SelectList(_context.Monitor, "Id", "nome", turma.monitorID);
            ViewData["professorID"] = new SelectList(_context.Professor, "Id", "nome", turma.professorID);
            return View(turma);
        }

        // GET: Turmas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turma
                .Include(t => t.curso)
                .Include(t => t.monitor)
                .Include(t => t.professor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        // POST: Turmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turma = await _context.Turma.FindAsync(id);
            if (turma != null)
            {
                _context.Turma.Remove(turma);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurmaExists(int id)
        {
            return _context.Turma.Any(e => e.Id == id);
        }
    }

}
