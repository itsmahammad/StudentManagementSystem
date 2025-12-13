using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;
namespace StudentManagementSystem.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=KOMPUDAKTER\\SQLEXPRESS;" +
                "Initial Catalog=StudentManagementDb;" +
                "Integrated Security=True;" +
                "TrustServerCertificate=True;"
            );
        }

    }
}
