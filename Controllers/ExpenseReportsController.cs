﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExpenseDiary.Models;

namespace ExpenseDiary.Controllers
{
    public class ExpenseReportsController : Controller
    {
        private readonly ExpenseDBContext _context;

        public ExpenseReportsController(ExpenseDBContext context)
        {
            _context = context;
        }

        // GET: ExpenseReports
        public async Task<IActionResult> Index()
        {
              return _context.Expenses != null ? 
                          View(await _context.Expenses.ToListAsync()) :
                          Problem("Entity set 'ExpenseDBContext.Expenses'  is null.");
        }

        // GET: ExpenseReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }

            var expenseReport = await _context.Expenses
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (expenseReport == null)
            {
                return NotFound();
            }

            return View(expenseReport);
        }

        // GET: ExpenseReports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenseReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,Amount,ExpenseDate,Category")] ExpenseReport expenseReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseReport);
        }

        // GET: ExpenseReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }

            var expenseReport = await _context.Expenses.FindAsync(id);
            if (expenseReport == null)
            {
                return NotFound();
            }
            return View(expenseReport);
        }

        // POST: ExpenseReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,Amount,ExpenseDate,Category")] ExpenseReport expenseReport)
        {
            if (id != expenseReport.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseReportExists(expenseReport.ItemId))
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
            return View(expenseReport);
        }

        // GET: ExpenseReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Expenses == null)
            {
                return NotFound();
            }

            var expenseReport = await _context.Expenses
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (expenseReport == null)
            {
                return NotFound();
            }

            return View(expenseReport);
        }

        // POST: ExpenseReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Expenses == null)
            {
                return Problem("Entity set 'ExpenseDBContext.Expenses'  is null.");
            }
            var expenseReport = await _context.Expenses.FindAsync(id);
            if (expenseReport != null)
            {
                _context.Expenses.Remove(expenseReport);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseReportExists(int id)
        {
          return (_context.Expenses?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
    }
}
