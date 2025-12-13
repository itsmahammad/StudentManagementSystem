using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StudentManagementSystem.Database;
using StudentManagementSystem.Enums;
using StudentManagementSystem.Exceptions;
using StudentManagementSystem.Helpers;
using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class ClassroomService : IClassroomService
    {
        public readonly AppDbContext context;

        public ClassroomService(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateClassroom(string name, ClassroomType type)
        {
            var classroom = new Classroom
            {
                Name = name,
                Type = type
            };
            context.Classrooms.Add(classroom);
            context.SaveChanges();
        }

        public List<Classroom> GetAllClassrooms()
        {
            return context.Classrooms
               .Include(c => c.Students)
               .ToList();
        }

        public Classroom? GetClassroomById(int id)
        {
            return context.Classrooms
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
