using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestReferenceLibrary
{
    class Program
    {
        /// <summary>
        /// The entry point of the application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MyClass objMyClass = new MyClass(new MyService());            
        }
    }
}
