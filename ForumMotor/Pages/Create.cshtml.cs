using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ForumMotor.Data;
using ForumMotor.Models;

namespace ForumMotor.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ForumMotor.Data.ApplicationDbContext _context;

        public CreateModel(ForumMotor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Kategoria Kategoria { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.Kategoriak.Add(Kategoria);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
