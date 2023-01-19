using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Post.Query.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Query.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddQueryInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            Action<DbContextOptionsBuilder> configureDbContext = (o => o.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("SqlServer")));
            services.AddDbContext<DataBaseContext>(configureDbContext);
            services.AddSingleton(new DataBaseContextFactory(configureDbContext));
            // Create database and table from code
            var dataContext = services.BuildServiceProvider().GetRequiredService<DataBaseContext>();


            dataContext.Database.EnsureCreated();
            return services;
        }
    }
}
