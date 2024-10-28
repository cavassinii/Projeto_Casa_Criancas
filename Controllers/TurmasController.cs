﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Casa_Criancas.Models;

namespace Projeto_Casa_Criancas.Controllers
{
    public class TurmasController : Controller
    {
        private readonly Contexto _context;

        public TurmasController(Contexto context)
        {
            _context = context;
        }

        // GET: Turmas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Turma.Include(t => t.curso).Include(t => t.monitor).Include(t => t.professor);
            return View(await contexto.ToListAsync());
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
            ViewData["cursoID"] = new SelectList(_context.Curso, "Id", "nome");
            ViewData["monitorID"] = new SelectList(_context.Monitor, "Id", "nome");
            ViewData["professorID"] = new SelectList(_context.Professor, "Id", "nome");
            return View();
        }

        // POST: Turmas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,cursoID,monitorID,professorID,descricao,dataHora")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["cursoID"] = new SelectList(_context.Curso, "Id", "nome", turma.cursoID);
            ViewData["monitorID"] = new SelectList(_context.Monitor, "Id", "nome", turma.monitorID);
            ViewData["professorID"] = new SelectList(_context.Professor, "Id", "nome", turma.professorID);
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
