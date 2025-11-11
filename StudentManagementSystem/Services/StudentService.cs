using Newtonsoft.Json;
using StudentManagementSystem.Exceptions;
using StudentManagementSystem.Helpers;
using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private string _filePath = "Database\\db.json";
        private List<Classroom> _classrooms;

        public StudentService(List<Classroom> classrooms)
        {
            string json = File.Exists(_filePath) ? File.ReadAllText(_filePath) : "[]";
            _classrooms = JsonConvert.DeserializeObject<List<Classroom>>(json) ?? new List<Classroom>();

            Classroom.InitializeCounter(_classrooms);
            Student.InitializeCounter(_classrooms);
            _classrooms = classrooms;
        }

        public Student CreateStudent(int classroomId, string name, string surname)
        {
            if (!ValidationExtensions.IsValidName(name) || !ValidationExtensions.IsValidSurname(surname))
                throw new ArgumentException("Name and Surname should be at least 3 symbols and start with uppercase and do not contain whitespaces");

            Classroom targetClassroom = null;
            for (int i = 0; i < _classrooms.Count; i++)
            {
                if (_classrooms[i].Id == classroomId)
                {
                    targetClassroom = _classrooms[i];
                    break;
                }
            }

            if (targetClassroom == null)
                throw new ClassroomNotFoundException("Classroom not found.");

            int maxStudents = targetClassroom.Type == Enums.ClassroomType.Backend ? 20 : 15;
            if (targetClassroom.Students.Count >= maxStudents)
                throw new Exception("Classroom is full max for backend is 20 for frontend 15 .");

            Student newStudent = new Student(name, surname);
            targetClassroom.Students.Add(newStudent);

            SaveToFile();
            return newStudent;
        }

        public void DeleteStudent(int studentId)
        {
            bool removed = false;

            for (int i = 0; i < _classrooms.Count; i++)
            {
                var students = _classrooms[i].Students;
                for (int j = 0; j < students.Count; j++)
                {
                    if (students[j].Id == studentId)
                    {
                        students.RemoveAt(j);
                        removed = true;
                        break;
                    }
                }
                if (removed) break;
            }

            if (!removed)
                throw new StudentNotFoundException("Student not found.");

            SaveToFile();
        }

        public List<Student> GetAllStudents()
        {
            List<Student> allStudents = new List<Student>();
            for (int i = 0; i < _classrooms.Count; i++)
            {
                allStudents.AddRange(_classrooms[i].Students);
            }
            return allStudents;
        }

        public List<Student> GetByClassroom(int classroomId)
        {
            Classroom targetClassroom = null;
            for (int i = 0; i < _classrooms.Count; i++)
            {
                if (_classrooms[i].Id == classroomId)
                {
                    targetClassroom = _classrooms[i];
                    break;
                }
            }

            if (targetClassroom == null)
                throw new ClassroomNotFoundException("Classroom not found.");

            return targetClassroom.Students;
        }

        private void SaveToFile()
        {
            string json = JsonConvert.SerializeObject(_classrooms, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
