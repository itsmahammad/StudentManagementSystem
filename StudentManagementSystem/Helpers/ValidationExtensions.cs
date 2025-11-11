using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Helpers
{
    public static class ValidationExtensions
    {
        public static bool IsValidName(string name)
        {
            return Char.IsUpper(name[0]) && !name.Any(Char.IsWhiteSpace) && name.Length >= 3;
        }

        public static bool IsValidSurname(string surname)
        {
            return Char.IsUpper(surname[0]) && !surname.Any(Char.IsWhiteSpace) && surname.Length >= 3;
        }

        public static bool IsValidClassroomName(string name)
        {
            return name.Length == 5
                && Char.IsUpper(name[0])
                && Char.IsUpper(name[1])
                && Char.IsDigit(name[2])
                && Char.IsDigit(name[3])
                && Char.IsDigit(name[4])
                && !name.Any(Char.IsWhiteSpace);
        }
    }
}
