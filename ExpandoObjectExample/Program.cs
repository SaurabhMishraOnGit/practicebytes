using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpandoObjectExample
{
    /// <summary>
    /// The program demonstartes the creation of expando object
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            dynamic employee;

            employee = new ExpandoObject();
            employee.Name = "Saurabh Mishra";
            employee.Salary = 33000;
            employee.Email = "Saurabh_Mishra2@epam.com";          

            WritePerson(employee);
        }

        /// <summary>
        /// Print the employee details
        /// </summary>
        /// <param name="person"></param>
        private static void WritePerson(dynamic person)
        {
            Console.WriteLine("{0} has {1} salary and his email is {2}.",
                              person.Name, person.Salary, person.Email);

            Console.ReadLine();
        }

    }
}
