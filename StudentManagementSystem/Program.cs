using StudentManagementSystem.Enums;
using StudentManagementSystem.Services;


namespace StudentManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var classroomService = new ClassroomService();
            var studentService = new StudentService(classroomService.GetAllClassrooms());


            bool running = true;

            while (running)
            {

                Console.WriteLine("1. Create Classroom");
                Console.WriteLine("2. Create Student");
                Console.WriteLine("3. Show All Students");
                Console.WriteLine("4. Show Students By Classroom");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        Console.Write("Enter classroom name: ");
                        string cName = Console.ReadLine();

                        Console.Write("Enter type (Backend/Frontend): ");
                        string cTypeInput = Console.ReadLine();

                        try
                        {
                            ClassroomType cType = (ClassroomType)Enum.Parse(typeof(ClassroomType), cTypeInput, true);
                            var classroom = classroomService.CreateClassroom(cName, cType);
                            Console.WriteLine($"Classroom created: {classroom.Name} ({classroom.Type})");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "2":

                        try
                        {
                            Console.Write("Enter classroom ID: ");
                            int classroomId = int.Parse(Console.ReadLine());

                            Console.Write("Enter student name: ");
                            string sName = Console.ReadLine();

                            Console.Write("Enter student surname: ");
                            string sSurname = Console.ReadLine();

                            var student = studentService.CreateStudent(classroomId, sName, sSurname);
                            Console.WriteLine($"Student created: {student.Name} {student.Surname} (ID: {student.Id})");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "3":

                        var allStudents = studentService.GetAllStudents();
                        if (allStudents.Count == 0)
                        {
                            Console.WriteLine("No students found.");
                        }
                        else
                        {
                            foreach (var s in allStudents)
                            {
                                Console.WriteLine($"{s.Id}: {s.Name} {s.Surname}");
                            }
                        }
                        break;

                    case "4":

                        try
                        {
                            Console.Write("Enter classroom ID: ");
                            int classId = int.Parse(Console.ReadLine());
                            var studentsInClass = studentService.GetByClassroom(classId);

                            if (studentsInClass.Count == 0)
                                Console.WriteLine("No students in this classroom.");
                            else
                                foreach (var s in studentsInClass)
                                    Console.WriteLine($"{s.Id}: {s.Name} {s.Surname}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "5":

                        try
                        {
                            Console.Write("Enter student ID to delete: ");
                            int studentId = int.Parse(Console.ReadLine());
                            studentService.DeleteStudent(studentId);
                            Console.WriteLine("Student deleted successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "6":

                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }


        }
    }
}
