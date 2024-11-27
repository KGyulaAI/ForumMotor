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
    public class PostListModel : PageModel
    {
        private readonly ForumMotor.Data.ApplicationDbContext _context;

        public PostListModel(ForumMotor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Bejegyzes> Bejegyzes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Bejegyzes = await _context.Bejegyzesek
                .Include(b => b.Topic)
                .Include(b => b.User).ToListAsync();
        }
    }
}
