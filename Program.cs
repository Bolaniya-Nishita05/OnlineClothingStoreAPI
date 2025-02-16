
using FluentValidation.AspNetCore;
using OnlineClothingStoreAPI.Data;
using System.Reflection;

namespace OnlineClothingStoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddScoped<BrandRepository>();
            builder.Services.AddScoped<CategoryRepository>();
            builder.Services.AddScoped<OrderRepository>();
            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<FavouriteRepository>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy => policy.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.WebHost.UseUrls("http://*:5053", "https://*:5054");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Apply CORS policy
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }

}
