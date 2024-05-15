using BusinessLogicLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Courses { get; set; }

        // Constructor to pass the options to the base class
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                                    b => b.MigrationsAssembly("MVC Interview Task"));
            }

        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship
            modelBuilder.Entity<StudentSubject>(e =>
            {
                e.HasKey(ss => new { ss.StudentId, ss.SubjectId });
            });

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);

            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);

            // Seed data for Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Ahmed", Date = new DateOnly(2000, 1, 1), Address = "Cairo" },
                new Student { Id = 2, Name = "Ali", Date = new DateOnly(2001, 2, 2), Address = "Mansoura" },
                new Student { Id = 3, Name = "Mohamed", Date = new DateOnly(2002, 3, 3), Address = "Tanta" },
                new Student { Id = 4, Name = "Nora", Date = new DateOnly(2003, 4, 4), Address = "Giza" }
            );

            // Seed data for Subjects
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "Arabic" },
                new Subject { Id = 2, Name = "English" },
                new Subject { Id = 3, Name = "Science" },
                new Subject { Id = 4, Name = "History" }
            );

            // Seed data for StudentSubjects
            modelBuilder.Entity<StudentSubject>().HasData(
                new StudentSubject { StudentId = 1, SubjectId = 1 },
                new StudentSubject { StudentId = 1, SubjectId = 2 },
                new StudentSubject { StudentId = 2, SubjectId = 3 },
                new StudentSubject { StudentId = 2, SubjectId = 4 },
                new StudentSubject { StudentId = 3, SubjectId = 1 },
                new StudentSubject { StudentId = 3, SubjectId = 3 },
                new StudentSubject { StudentId = 4, SubjectId = 2 },
                new StudentSubject { StudentId = 4, SubjectId = 4 }
            );
        }
    }
}
