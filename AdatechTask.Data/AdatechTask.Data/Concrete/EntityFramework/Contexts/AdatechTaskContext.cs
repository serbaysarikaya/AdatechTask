using AdatechTask.Data.Concrete.EntityFramework.Mappings;
using AdatechTask.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace AdatechTask.Data.Concrete.EntityFramework.Contexts
{
    public class AdatechTaskContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public AdatechTaskContext(DbContextOptions<AdatechTaskContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(connectionString: @"Data Source=DESKTOP-UO2Q254;Initial Catalog=AdatechTaskDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMap());
        }
    }
}
