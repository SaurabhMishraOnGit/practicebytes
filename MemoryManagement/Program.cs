using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    /// <summary>
    /// The Program demonstrates disposing of object in 2 ways
    /// 1. Through using keyword
    /// 2. By explicitly calling .Dispose() by the object.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Disposing the My class object through using keyword
                using (MyClass objMyClass = new MyClass())
                {
                    //Printing the 'myInteger'
                    Console.WriteLine(objMyClass.myInteger);
                }
            }
            finally
            {
                //Disposing the MyClass object in the finally keyword
                MyClass myClassSecondObject = new MyClass();
                myClassSecondObject.Dispose();

                Console.ReadLine();
            }         
        }
    }

    /// <summary>
    /// Class that implements the IDisposable interface
    /// </summary>
    class MyClass : IDisposable
    {
        public int myInteger = 88;
                
        public void Dispose()
        {
            Console.WriteLine("Disposing...");           

            //Asking the Garbage collector not to call Finalize mechanism.
            GC.SuppressFinalize(this);
        }
    }
}
