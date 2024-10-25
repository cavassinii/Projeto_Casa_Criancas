using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Casa_Criancas.Models;

namespace Projeto_Casa_Criancas.Controllers
{
    public class AssistenteSociaisController : Controller
    {
        private readonly Contexto _context;

        public AssistenteSociaisController(Contexto context)
        {
            _context = context;
        }

        // GET: AssistenteSociais
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssistenteSocial.ToListAsync());
        }

        // GET: AssistenteSociais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistenteSocial = await _context.AssistenteSocial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assistenteSocial == null)
            {
                return NotFound();
            }

            return View(assistenteSocial);
        }

        // GET: AssistenteSociais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssistenteSociais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,cpf,endereco,celular")] AssistenteSocial assistenteSocial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assistenteSocial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assistenteSocial);
        }

        // GET: AssistenteSociais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistenteSocial = await _context.AssistenteSocial.FindAsync(id);
            if (assistenteSocial == null)
            {
                return NotFound();
            }
            return View(assistenteSocial);
        }

        // POST: AssistenteSociais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome,cpf,endereco,celular")] AssistenteSocial assistenteSocial)
        {
            if (id != assistenteSocial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assistenteSocial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssistenteSocialExists(assistenteSocial.Id))
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
            return View(assistenteSocial);
        }

        // GET: AssistenteSociais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assistenteSocial = await _context.AssistenteSocial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assistenteSocial == null)
            {
                return NotFound();
            }

            return View(assistenteSocial);
        }

        // POST: AssistenteSociais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assistenteSocial = await _context.AssistenteSocial.FindAsync(id);
            if (assistenteSocial != null)
            {
                _context.AssistenteSocial.Remove(assistenteSocial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssistenteSocialExists(int id)
        {
            return _context.AssistenteSocial.Any(e => e.Id == id);
        }
    }
}
