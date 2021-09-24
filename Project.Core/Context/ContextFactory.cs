
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Project.Core.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(@"data source=NGOCHOI;Initial Catalog=Assignmentcmc;Integrated Security=True;");
            return new DataContext(optionsBuilder.Options);
        }
    }
}
