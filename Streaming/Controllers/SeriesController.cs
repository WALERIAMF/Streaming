﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Streaming;
using Streaming.Models;

namespace Streaming.Controllers
{
    public class SeriesController : Controller
    {
        private readonly Context _context;

        public SeriesController(Context context)
        {
            _context = context;
        }

        // GET: Series
        public async Task<IActionResult> Index()
        {
            var context = _context.Series.Include(s => s.Genero);
            return View(await context.ToListAsync());
        }

        // GET: Series/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series = await _context.Series
                .Include(s => s.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        // GET: Series/Create
        public IActionResult Create()
        {
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "Nome");
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Lancamento,Ativo,GeneroId")] Series series)
        {
            if (ModelState.IsValid)
            {
                _context.Add(series);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "Nome", series.GeneroId);
            return View(series);
        }

        // GET: Series/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series = await _context.Series.FindAsync(id);
            if (series == null)
            {
                return NotFound();
            }
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "Nome", series.GeneroId);
            return View(series);
        }

        // POST: Series/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Lancamento,Ativo,GeneroId")] Series series)
        {
            if (id != series.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(series);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriesExists(series.Id))
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
            ViewData["GeneroId"] = new SelectList(_context.Genero, "Id", "Nome", series.GeneroId);
            return View(series);
        }

        // GET: Series/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var series = await _context.Series
                .Include(s => s.Genero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var series = await _context.Series.FindAsync(id);
            _context.Series.Remove(series);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeriesExists(int id)
        {
            return _context.Series.Any(e => e.Id == id);
        }
    }
}
