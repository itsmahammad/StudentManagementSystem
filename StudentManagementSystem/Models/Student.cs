using System;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        private static int _studentCounter = 0;

        public Student(string name, string surname)
        {
            Id = ++_studentCounter;
            Name = name;
            Surname = surname;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public static void InitializeCounter(List<Classroom> classrooms)
        {
            int maxId = 0;
            for (int i = 0; i < classrooms.Count; i++)
            {
                var students = classrooms[i].Students;
                for (int j = 0; j < students.Count; j++)
                {
                    if (students[j].Id > maxId)
                        maxId = students[j].Id;
                }
            }
            _studentCounter = maxId;
        }
    }
}
