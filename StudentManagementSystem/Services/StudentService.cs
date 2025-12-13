using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StudentManagementSystem.Database;
using StudentManagementSystem.Exceptions;
using StudentManagementSystem.Helpers;
using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext context;

        public StudentService(AppDbContext context)
        {
            this.context = context;
        }

        public void CreateStudent(string name, string surname, int classroomId)
        {
            var classroom = context.Classrooms
               .Include(c => c.Students)
               .FirstOrDefault(c => c.Id == classroomId);

            if (classroom == null)
                throw new ClassroomNotFoundException($"Classroom with Id {classroomId} not found.");

            if (classroom.Type == Enums.ClassroomType.Backend && classroom.Students.Count >= 20 ||
                classroom.Type == Enums.ClassroomType.Frontend && classroom.Students.Count >= 15)
            {
                throw new Exception("Classroom limit reached.");
            }

            var student = new Student
            {
                Name = name,
                Surname = surname
            };

            classroom.Students.Add(student);
            context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = context.Students.Find(id);
            if (student == null)
                throw new StudentNotFoundException($"Student with Id {id} not found.");

            context.Students.Remove(student);
            context.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            return context.Students
                .Include(s => s.Classroom)
                .ToList();
        }

        public Student? GetStudentById(int id)
        {
            return context.Students.Find(id);
        }

        public List<Student> GetStudentsByClassroom(int classroomId)
        {
            var classroom = context.Classrooms
                .Include(c => c.Students)
                .FirstOrDefault(c => c.Id == classroomId);

            if (classroom == null)
                throw new ClassroomNotFoundException($"Classroom with Id {classroomId} not found.");

            return (List<Student>)classroom.Students;
        }
    }
}
