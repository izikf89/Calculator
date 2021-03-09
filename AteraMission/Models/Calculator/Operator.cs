using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AteraMission.Models.Calculator
{
    interface Operator : Expression
    {
        double Calculate(double left, double right);

    }
}
