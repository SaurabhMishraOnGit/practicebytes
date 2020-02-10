using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionBodiedMembers
{
    /// <summary>
    /// The class the defines the get and set accessors of indexers
    /// </summary>
    class ExpressionBodiedMembersForIndexers
    {
        public int Num1 = 100;
        public int Num2 = 33;

        public string[] Names = new string[5];
        public string this[int i]
        {
            get => Names[i];

            set => Names[i] = value;

        }
    }
}
