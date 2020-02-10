using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionBodiedMembers
{   
    /// <summary>
    /// The class that demonstrates property getter and setter with expression body separately
    /// </summary>
    class ExpressionBodiedProperties
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value ?? "";
        }
    }
}
