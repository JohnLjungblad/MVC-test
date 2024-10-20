using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Mobile>().ToTable("Mobiles");
        modelBuilder.Entity<Computer>().ToTable("Computers");
        modelBuilder.Entity<Tablet>().ToTable("Tablets");

        // Had to explicity tell Entity to ignore Device even tho its Abstract
        modelBuilder.Ignore<Device>();
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Mobile> Mobiles { get; set; }
    public DbSet<Computer> Computers { get; set; }
    public DbSet<Tablet> Tablets { get; set; }
    public DbSet<Department> Departments { get; set; }

}