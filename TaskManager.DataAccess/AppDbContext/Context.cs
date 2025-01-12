using Microsoft.EntityFrameworkCore;
using TaskManager.Entities.Concrete;

namespace TaskManager.DataAccess.AppDbContext;

public class Context : DbContext
{
    public DbSet<Job> Jobs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Server=SULEYMAN\SQLEXPRESS;Database=TaskManager;TrustServerCertificate=True;Integrated Security=True");
    }
}
