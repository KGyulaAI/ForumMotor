using ForumMotor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ForumMotor.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Kategoria> Kategoriak { get; set; }
        public DbSet<Topic> Topicok { get; set; }
        public DbSet<Bejegyzes> Bejegyzesek { get; set; }
    }
}
