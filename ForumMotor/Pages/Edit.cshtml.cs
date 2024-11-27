﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ForumMotor.Data;
using ForumMotor.Models;

namespace ForumMotor.Pages
{
    public class EditModel : PageModel
    {
        private readonly ForumMotor.Data.ApplicationDbContext _context;

        public EditModel(ForumMotor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Kategoria Kategoria { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoria =  await _context.Kategoriak.FirstOrDefaultAsync(m => m.Id == id);
            if (kategoria == null)
            {
                return NotFound();
            }
            Kategoria = kategoria;
           ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Kategoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategoriaExists(Kategoria.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool KategoriaExists(int id)
        {
            return _context.Kategoriak.Any(e => e.Id == id);
        }
    }
}