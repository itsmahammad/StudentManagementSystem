using StudentManagementSystem.Enums;
using StudentManagementSystem.Models;
using System.Collections.Generic;

namespace StudentManagementSystem.Interfaces
{
    public interface IClassroomService
    {
        void CreateClassroom(string name, ClassroomType type);
        Classroom? GetClassroomById(int id);
        List<Classroom> GetAllClassrooms();
    }
}
