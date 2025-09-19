using AustCseApp.Data;
using AustCseApp.Data.Helpers;
using AustCseApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AustCseApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //quiz related
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<AustCseApp.Services.GptQuizService>();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add Email service
            builder.Services.Configure<SmtpOptions>(builder.Configuration.GetSection("Smtp"));
            builder.Services.AddTransient<IEmailSender, SmtpEmailSender>();

            // Database Configuration
            var dbConnectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(dbConnectionString));

            var app = builder.Build();

            // Seed the database with initial data
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await dbContext.Database.MigrateAsync();
                await DbInitializer.SeedAsync(dbContext);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
