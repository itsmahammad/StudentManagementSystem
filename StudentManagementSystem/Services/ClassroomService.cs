using Newtonsoft.Json;
using StudentManagementSystem.Enums;
using StudentManagementSystem.Exceptions;
using StudentManagementSystem.Helpers;
using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;


namespace StudentManagementSystem.Services
{
    public class ClassroomService : IClassroomService
    {
        private string _filePath = "Database\\db.json";
        private List<Classroom> _classrooms;

        public ClassroomService()
        {
            string json = File.Exists(_filePath) ? File.ReadAllText(_filePath) : "[]";
            _classrooms = JsonConvert.DeserializeObject<List<Classroom>>(json) ?? new List<Classroom>();

            Classroom.InitializeCounter(_classrooms);
            Student.InitializeCounter(_classrooms);
        }

        public Classroom CreateClassroom(string name, ClassroomType type)
        {
            if (!ValidationExtensions.IsValidClassroomName(name))
                throw new ArgumentException("Classroom must start with 2 Uppercase letters and end with 3 digits");

            for (int i = 0; i < _classrooms.Count; i++)
            {
                if (_classrooms[i].Name == name)
                    throw new Exception("Classroom name already exists.");
            }

            Classroom newClassroom = new Classroom(name, type);
            _classrooms.Add(newClassroom);
            SaveToFile();
            return newClassroom;
        }

        public List<Classroom> GetAllClassrooms()
        {
            return _classrooms;
        }

        public Classroom GetById(int id)
        {
            for (int i = 0; i < _classrooms.Count; i++)
            {
                if (_classrooms[i].Id == id)
                    return _classrooms[i];
            }
            throw new ClassroomNotFoundException($"Classroom with ID {id} was not found.");
        }

        private void SaveToFile()
        {
            string json = JsonConvert.SerializeObject(_classrooms, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
