using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class ITIContextFactory : IDesignTimeDbContextFactory<ITIContext>
    {
        public ITIContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ITIContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=ITIWithCristen; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true");

            return new ITIContext(optionsBuilder.Options);
        }
    }
}
