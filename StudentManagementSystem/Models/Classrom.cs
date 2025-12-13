using StudentManagementSystem.Enums;
using System.Collections.Generic;

namespace StudentManagementSystem.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClassroomType Type { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
        public Classroom() { }
    }
}
