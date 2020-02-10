using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestReferenceLibrary
{
    public class MyService:IMyService
    {
        /// <summary>
        /// The method that returns a string based on input 'num'
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string ReturnAorB(int? num)
        {     
            if(num == null)
            {
                throw new ArgumentNullException ("Value cannot be null");
            }

            if(num < 1)
            {
                throw new ArgumentException("The num is less than 1");
            }

            return (num < 51) ?  "A" : "B";           
        }
    }
}
