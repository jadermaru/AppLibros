using BackendLibreria.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendLibreria.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
