using StudentManagementSystem.Database;
using StudentManagementSystem.Enums;
using StudentManagementSystem.Exceptions;
using StudentManagementSystem.Interfaces;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();
        IClassroomService classroomService = new ClassroomService(context);
        IStudentService studentService = new StudentService(context);

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Classroom");
            Console.WriteLine("2. Create Student");
            Console.WriteLine("3. Show All Students");
            Console.WriteLine("4. Show Students in a Classroom");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Classroom Name (2 uppercase letters + 3 digits): ");
                        var className = Console.ReadLine()!;
                        Console.Write("Type (Backend/FrontEnd): ");
                        var typeInput = Console.ReadLine()!;
                        var type = Enum.Parse<ClassroomType>(typeInput, true);

                        classroomService.CreateClassroom(className, type);
                        Console.WriteLine("Classroom created!");
                        break;

                    case "2":
                        Console.Write("Student Name: ");
                        var studentName = Console.ReadLine()!;
                        Console.Write("Student Surname: ");
                        var studentSurname = Console.ReadLine()!;
                        Console.Write("Classroom Id: ");
                        var classroomId = int.Parse(Console.ReadLine()!);

                        studentService.CreateStudent(studentName, studentSurname, classroomId);
                        Console.WriteLine("Student created!");
                        break;

                    case "3":
                        var allStudents = studentService.GetAllStudents();
                        Console.WriteLine("\nAll Students:");
                        foreach (var s in allStudents)
                        {
                            Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Surname: {s.Surname}, ClassroomId: {s.ClassroomId}");
                        }
                        break;

                    case "4":
                        Console.Write("Classroom Id: ");
                        var classId = int.Parse(Console.ReadLine()!);
                        var studentsInClass = studentService.GetStudentsByClassroom(classId);
                        Console.WriteLine($"\nStudents in Classroom {classId}:");
                        foreach (var s in studentsInClass)
                        {
                            Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Surname: {s.Surname}");
                        }
                        break;

                    case "5":
                        Console.Write("Student Id to delete: ");
                        var studentId = int.Parse(Console.ReadLine()!);
                        studentService.DeleteStudent(studentId);
                        Console.WriteLine("Student deleted!");
                        break;

                    case "6":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
