using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TechSupportData
{
    public class TechSupportDbContextFactory: IDesignTimeDbContextFactory<TechSupportDbContext>
    {
        public TechSupportDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<TechSupportDbContext>()
                .UseMySql(
                    $"Server={MySqlCredentials.Host};Database={MySqlCredentials.Database};User={MySqlCredentials.Username};Password={MySqlCredentials.Password};"
                );

            return new TechSupportDbContext(optionsBuilder.Options);
        }
    }
}