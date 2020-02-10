using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace ExpandoObject
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic employee, manager;

            employee = new ExpandoObject();
            employee.Name = "John Smith";
            employee.Age = 33;

            manager = new ExpandoObject();
            manager.Name = "Allison Brown";
            manager.Age = 42;
            manager.TeamSize = 10;

            WritePerson(manager);
            WritePerson(employee);
        }
        private static void WritePerson(dynamic person)
        {
            Console.WriteLine("{0} is {1} years old.",
                              person.Name, person.Age);
            // The following statement causes an exception
            // if you pass the employee object.
            // Console.WriteLine("Manages {0} people", person.TeamSize);
        }
    }
}
