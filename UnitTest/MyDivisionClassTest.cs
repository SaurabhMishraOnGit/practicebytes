using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestReferenceLibrary;

namespace UnitTest
{
    [TestClass]
    public class MyDivisionClassTest
    {
        [TestMethod]
        public void DivideOperationWithResultAsZeroTest()
        {
            MyDivisionClass ObjMath = new MyDivisionClass();
            int Result = ObjMath.Divide(10, 20);
            Assert.AreNotEqual(10, Result);
        }


        [TestMethod]
        public void DivideOperationWithResultGreaterThanZeroTest()
        {
            MyDivisionClass ObjMath = new MyDivisionClass();
            int Result = ObjMath.Divide(50, 10);
            Assert.AreEqual(5, Result);
        }
     
    }
}
