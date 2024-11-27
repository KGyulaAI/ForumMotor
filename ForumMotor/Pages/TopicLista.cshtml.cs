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
    public class TopicListaModel : PageModel
    {
        private readonly ForumMotor.Data.ApplicationDbContext _context;

        public TopicListaModel(ForumMotor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int CategoryId { get; set; }

        public IList<Topic> Topic { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Topic = await _context.Topicok
                .Where(x => x.KategoriaId == CategoryId)
                .Include(t => t.Kategoria)
                .Include(t => t.User).ToListAsync();
        }
    }
}
