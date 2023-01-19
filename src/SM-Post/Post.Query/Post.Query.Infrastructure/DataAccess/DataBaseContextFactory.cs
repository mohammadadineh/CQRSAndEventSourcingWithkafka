using Microsoft.EntityFrameworkCore;

namespace Post.Query.Infrastructure.DataAccess
{
    internal class DataBaseContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        internal DataBaseContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public DataBaseContext CreateDbContext()
        {
            DbContextOptionsBuilder<DataBaseContext> optionsBuilder = new();
            _configureDbContext(optionsBuilder);

            return new DataBaseContext(optionsBuilder.Options);
        }
    }
}
