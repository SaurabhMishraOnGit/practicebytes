using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestReferenceLibrary
{
    /// <summary>
    /// The class that consumes MyService
    /// The MyService is injected through constructor
    /// </summary>
    public class MyClass
    {
        IMyService _myService;

        /// <summary>
        /// Constructor injection of 'MyService' type.
        /// </summary>
        /// <param name="myService"></param>
        public MyClass(IMyService myService)
        {
            _myService = myService;            
        }

        /// <summary>
        /// The method that returns the value of num
        /// </summary>
        private void WhatItReturns()
        {
           string output = _myService.ReturnAorB(10);
        }
    }
}
