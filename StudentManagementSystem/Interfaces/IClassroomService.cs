using StudentManagementSystem.Enums;
using StudentManagementSystem.Models;
using System.Collections.Generic;

namespace StudentManagementSystem.Interfaces
{
    public interface IClassroomService
    {
        Classroom CreateClassroom(string name, ClassroomType type);
        List<Classroom> GetAllClassrooms();
        Classroom GetById(int id);
    }
}
