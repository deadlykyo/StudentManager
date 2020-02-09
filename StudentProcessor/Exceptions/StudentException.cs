using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProcessor.Exceptions
{
    public class StudentException : Exception
    {
        public StudentException()
        {

        }

        public StudentException(string message) : base(message)
        {
            //Logic to handle exceptions
            Console.WriteLine("Error Message: " + message);
        }

        public StudentException(string message, Exception innerException) : base(message, innerException)
        {
            //Logic to handle exceptions
        }
    }
}
