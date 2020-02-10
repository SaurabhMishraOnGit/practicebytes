using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestReferenceLibrary;

namespace UnitTest
{
    /// <summary>
    /// Summary description for MyServiceTest
    /// </summary>
    [TestClass]
    public class MyServiceTest
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "Value cannot be null")]
        public void ArgumentNullExceptionTest()
        {
            MyService service = new MyService();
            service.ReturnAorB(null);          
        }


        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "The num is less than 1")]
        public void ArgumentExceptionTest()
        {
            MyService service = new MyService();
            service.ReturnAorB(-1);          
        }
    }
}
