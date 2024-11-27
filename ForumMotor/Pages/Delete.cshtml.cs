using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ForumMotor.Data;
using ForumMotor.Models;

namespace ForumMotor.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ForumMotor.Data.ApplicationDbContext _context;

        public DeleteModel(ForumMotor.Data.ApplicationDbContext context)
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

            var kategoria = await _context.Kategoriak.FirstOrDefaultAsync(m => m.Id == id);

            if (kategoria == null)
            {
                return NotFound();
            }
            else
            {
                Kategoria = kategoria;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategoria = await _context.Kategoriak.FindAsync(id);
            if (kategoria != null)
            {
                Kategoria = kategoria;
                _context.Kategoriak.Remove(Kategoria);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
