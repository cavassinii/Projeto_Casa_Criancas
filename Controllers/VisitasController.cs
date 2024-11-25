using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Projeto_Casa_Criancas.Models;

namespace Projeto_Casa_Criancas.Controllers
{
    [Authorize(Roles = "Admin,Assistente")]

    public class VisitasController : Controller
    {
        private readonly Contexto _context;

        public VisitasController(Contexto context)
        {
            _context = context;
        }

        // GET: Visitas

        public async Task<IActionResult> Index(int assistenteSocialID = 0, int alunoID = 0, DateOnly? dataInicio = null, DateOnly? dataFim = null)
        {
            List<Visita> listaVisitas = new List<Visita>();

            var filtro =
                         _context.Visita
                        .Include(a => a.assistenteSocial)
                        .Include(a => a.aluno)
                        .AsQueryable();

            if (assistenteSocialID != 0)
            {
                filtro = filtro.Where(a => a.assistenteSocialID == assistenteSocialID);
            }
            if(alunoID != 0)
            {
                filtro = filtro.Where(a => a.alunoID == alunoID);
            }
            if (dataInicio.HasValue)
            {
                filtro = filtro.Where(a => a.data >= dataInicio.Value);
            }
            if (dataFim.HasValue)
            {
                filtro = filtro.Where(a => a.data <= dataFim.Value);
            }
            listaVisitas = await filtro.ToListAsync();

            ViewData["assistenteSocialID"] = new SelectList(_context.AssistenteSocial, "Id", "nome", assistenteSocialID);
            ViewData["alunoID"] = new SelectList(_context.Aluno, "Id", "nome", alunoID);
            ViewData["dataInicio"] = dataInicio;
            ViewData["dataFim"] = dataFim;

            return View(listaVisitas);
        }


        // GET: Visitas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visita
                .Include(v => v.aluno)
                .Include(v => v.assistenteSocial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // GET: Visitas/Create
        public IActionResult Create()
        {
            ViewData["alunoID"] = new SelectList(_context.Aluno, "Id", "nome");
            ViewData["assistenteSocialID"] = new SelectList(_context.AssistenteSocial, "Id", "nome");
            return View();
        }

        // POST: Visitas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,alunoID,assistenteSocialID,data,status,situacaoFamiliar,acoesPreliminares,contextoExterno,contextoFamiliar,redeApoio,violacaoDireito,encaminhamento,compactacoes,escolarizacao,violenciaDomestica")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["alunoID"] = new SelectList(_context.Aluno, "Id", "nome", visita.alunoID);
            ViewData["assistenteSocialID"] = new SelectList(_context.AssistenteSocial, "Id", "nome", visita.assistenteSocialID);
            return View(visita);
        }

        // GET: Visitas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visita.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }
            ViewData["assistenteSocialID"] = new SelectList(_context.AssistenteSocial, "Id", "nome", visita.assistenteSocialID);
            return View(visita);
        }

        // POST: Visitas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,alunoID,assistenteSocialID,data,status,situacaoFamiliar,acoesPreliminares,contextoExterno,contextoFamiliar,redeApoio,violacaoDireito,encaminhamento,compactacoes,escolarizacao,violenciaDomestica")] Visita visita)
        {
            if (id != visita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaExists(visita.Id))
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
            ViewData["alunoID"] = new SelectList(_context.Aluno, "Id", "nome", visita.alunoID);
            ViewData["assistenteSocialID"] = new SelectList(_context.AssistenteSocial, "Id", "nome", visita.assistenteSocialID);
            return View(visita);
        }

        // GET: Visitas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visita
                .Include(v => v.aluno)
                .Include(v => v.assistenteSocial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // POST: Visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visita = await _context.Visita.FindAsync(id);
            if (visita != null)
            {
                _context.Visita.Remove(visita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaExists(int id)
        {
            return _context.Visita.Any(e => e.Id == id);
        }
    }
}
