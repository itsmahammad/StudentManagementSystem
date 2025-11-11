using StudentManagementSystem.Models;
using System.Collections.Generic;

namespace StudentManagementSystem.Interfaces
{
    public interface IStudentService
    {
        Student CreateStudent(int classroomId, string name, string surname);
        void DeleteStudent(int studentId);
        List<Student> GetAllStudents();
        List<Student> GetByClassroom(int classroomId);
    }
}
