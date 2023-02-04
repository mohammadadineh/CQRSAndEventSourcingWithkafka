using Confluent.Kafka;
using CQRS.Core.Consumers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Post.Query.Domain.Repositories;
using Post.Query.Infrastructure.Consumers;
using Post.Query.Infrastructure.DataAccess;
using Post.Query.Infrastructure.Handlers;
using Post.Query.Infrastructure.Repositories;
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
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IEventHandler,Handlers.EventHandler>();
            services.Configure<ConsumerConfig>(configuration.GetSection(nameof(ConsumerConfig)));
            services.AddScoped<IEventConsumer, EventConsumer>();
            // Create database and table from code
            var dataContext = services.BuildServiceProvider().GetRequiredService<DataBaseContext>();


            dataContext.Database.EnsureCreated();
            return services;
        }
    }
}
