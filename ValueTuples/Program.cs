using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTuples
{
    class Program
    {
        /// <summary>
        /// The entry point of the application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Deconstruction of Value tuple
            var (EmpId, FirstName, LastName) = GetUserDetails();

            //Printing of values
            Console.WriteLine("*User Details*");

            Console.WriteLine("Id:{0}", EmpId);

            Console.WriteLine("Name:{0}", FirstName);

            Console.WriteLine("Location:{0}", LastName);

            Console.ReadLine();
        }

        /// <summary>
        /// The Value tuple with three types
        /// </summary>
        public static (int, string, string) GetUserDetails()
        {
            return (559201, "Saurabh", "Mishra");
        }
    }
}
