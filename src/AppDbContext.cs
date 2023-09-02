using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using VirtualDars.Demo.SQLInjection.Entities;
using static System.Reflection.Metadata.BlobBuilder;

namespace VirtualDars.Demo.SQLInjection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

    }
}
