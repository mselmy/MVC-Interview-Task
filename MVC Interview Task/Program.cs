using BusinessLogicLayer.Models;
using DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using DataAccessLayer.UniteOfWork;
using Microsoft.EntityFrameworkCore;

namespace MVC_Interview_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //DBContext 
            //builder.Services.AddSingleton<StaticDataContext>();
            builder.Services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Repositories
            //builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            //builder.Services.AddScoped<ISubjectRepo, SubjectRepo>();
            builder.Services.AddScoped<IGenericRepo<Student>, GenericRepo<Student>>();
            builder.Services.AddScoped<IGenericRepo<Subject>, GenericRepo<Subject>>();
            builder.Services.AddScoped<IUnitOfWork, UOW>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Student}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
