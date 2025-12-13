using StudentManagementSystem.Models;
using System.Collections.Generic;

namespace StudentManagementSystem.Interfaces
{
    public interface IStudentService
    {
        void CreateStudent(string name, string surname, int classroomId);
        Student? GetStudentById(int id);
        List<Student> GetAllStudents();
        List<Student> GetStudentsByClassroom(int classroomId);
        void DeleteStudent(int id);
    }
}
