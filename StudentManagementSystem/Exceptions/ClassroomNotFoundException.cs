using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Exceptions
{
    public class ClassroomNotFoundException : Exception
    {
        public ClassroomNotFoundException() {}
        public ClassroomNotFoundException(string? message) : base(message)
        {
        }
        public ClassroomNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
