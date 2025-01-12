using Microsoft.EntityFrameworkCore;

public class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext(options)
{
    public DbSet<Animal> Animals { get; set; }
}