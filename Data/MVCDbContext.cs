using CodebaseProject.Models.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace CodebaseProject.Data
{
    public class MVCDbContext : DbContext
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
             
    }
        public DbSet<Book> BooksInfo { get; set; }
    }
}
 