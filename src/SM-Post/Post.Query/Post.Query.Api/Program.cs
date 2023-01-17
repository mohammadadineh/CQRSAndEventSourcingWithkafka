
using Microsoft.EntityFrameworkCore;
using Post.Query.Infrastructure.DataAccess;

namespace Post.Query.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Action<DbContextOptionsBuilder> configureDbContext = (o => o.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
            builder.Services.AddDbContext<DataBaseContext>(configureDbContext);
            builder.Services.AddSingleton(new DataBaseContextFactory(configureDbContext));
            // Create database and table from code
            var dataContext=builder.Services.BuildServiceProvider().GetRequiredService<DataBaseContext>();

            var d= dataContext.Database.CanConnect();
            
            dataContext.Database.EnsureCreated(); 

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}