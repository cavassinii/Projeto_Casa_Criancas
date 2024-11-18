using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Casa_Criancas.Models;
using ProjetoMonitor = Projeto_Casa_Criancas.Models.Monitor;


namespace Projeto_Casa_Criancas.Controllers
{
    //[Authorize(Roles = "Admin,Assistente")]

    public class MonitoresController : Controller
    {
        private readonly Contexto _context;

        public MonitoresController(Contexto context)
        {
            _context = context;
        }

        // GET: Monitores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Monitor.ToListAsync());
        }

        // GET: Monitores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitor = await _context.Monitor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monitor == null)
            {
                return NotFound();
            }

            return View(monitor);
        }

        // GET: Monitores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monitores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,cpf,endereco,celular")] ProjetoMonitor monitor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monitor);
        }

        // GET: Monitores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitor = await _context.Monitor.FindAsync(id);
            if (monitor == null)
            {
                return NotFound();
            }
            return View(monitor);
        }

        public IActionResult FiltrarMonitor(string nome)
        {
            List<ProjetoMonitor> listaMonitores;

            if (!string.IsNullOrEmpty(nome))
            {
                listaMonitores = _context.Monitor
                    .Where(a => a.nome.Contains(nome))
                    .OrderBy(a => a.nome)
                    .ToList();
            }
            else
            {
                listaMonitores = _context.Monitor
                    .OrderBy(a => a.nome)
                    .ToList();
            }

            ViewData["Nome"] = nome;

            return View("Index", listaMonitores);
        }

        // POST: Monitores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome,cpf,endereco,celular")] ProjetoMonitor monitor)
        {
            if (id != monitor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monitor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonitorExists(monitor.Id))
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
            return View(monitor);
        }

        // GET: Monitores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitor = await _context.Monitor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monitor == null)
            {
                return NotFound();
            }

            return View(monitor);
        }

        // POST: Monitores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monitor = await _context.Monitor.FindAsync(id);
            if (monitor != null)
            {
                _context.Monitor.Remove(monitor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonitorExists(int id)
        {
            return _context.Monitor.Any(e => e.Id == id);
        }
    }
}
