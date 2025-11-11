using StudentManagementSystem.Enums;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public class Classroom
    {
        private static int _classroomCounter = 0;

        public Classroom(string name, ClassroomType type)
        {
            Id = ++_classroomCounter;
            Name = name;
            Type = type;
            Students = new List<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ClassroomType Type { get; set; }
        public List<Student> Students { get; set; }

        public static void InitializeCounter(List<Classroom> classrooms)
        {
            int maxId = 0;
            for (int i = 0; i < classrooms.Count; i++)
            {
                if (classrooms[i].Id > maxId)
                    maxId = classrooms[i].Id;
            }
            _classroomCounter = maxId;
        }
    }
}
