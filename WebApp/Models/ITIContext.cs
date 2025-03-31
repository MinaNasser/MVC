using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

public class ITIContext : IdentityDbContext<AppUser>
{
    public ITIContext()
    {
    }

    public ITIContext(DbContextOptions<ITIContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer("Server=.;Database=ITIWithCristen;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
    }

    public DbSet<Department> Department { get; set; }
    public DbSet<Employee> Employee { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //  ÕœÌœ «·„› «Õ «·√”«”Ì ·‹ IdentityUserLogin<string>
        modelBuilder.Entity<IdentityUserLogin<string>>()
            .HasKey(l => new { l.LoginProvider, l.ProviderKey });

        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    }
}
