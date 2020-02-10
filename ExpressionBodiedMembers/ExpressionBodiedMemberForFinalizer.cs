using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionBodiedMembers
{
    /// <summary>
    /// Defining a finalizer with expression body
    /// </summary>
    class ExpressionBodiedMemberForFinalizer
    {
        ~ExpressionBodiedMemberForFinalizer() => Console.WriteLine("Expression-bodied finalizer");
    }
}
