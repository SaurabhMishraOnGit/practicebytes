using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestReferenceLibrary
{
    /// <summary>
    /// The class that performs calculation
    /// </summary>
    public class MyDivisionClass
    {
        /// <summary>
        /// The method that performs division
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Divide(int a, int b)
        {
            int result = a / b;

            return result;
        }
    }
}
