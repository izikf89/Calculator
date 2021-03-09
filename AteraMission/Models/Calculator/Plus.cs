using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AteraMission.Models.Calculator
{
    public class Plus : Operator
    {
        public double Calculate(double left, double right) => left + right;
    }
}
