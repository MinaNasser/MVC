// Context class for the ITI database
// This class is used to interact with the database using Entity Framework Core
// It is also used to configure the database using Fluent API

using Microsoft.EntityFrameworkCore;

using WebApp.Models;

public class ITIContext : DbContext
{
    public ITIContext()
    {
    }

    public ITIContext(DbContextOptions<ITIContext> options) : base(options)
    {
        // connection string


    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.
            UseSqlServer("Server =.; Database = ITIWithCristen; Trusted_Connection = True; TrustServerCertificate = True; MultipleActiveResultSets = true");
    }
    public DbSet<Department> Department { get; set; }
    public DbSet<Employee> Employee { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    }
}
// Data Source=.;Initial Catalog=ITIWithCristen;Integrated Security=True;Encrypt=False;Trust Server Certificate=True