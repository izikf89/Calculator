using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AteraMission.Models.Calculator
{
    class Number : Expression
    {
        public double value { get; set; }

        public Number(double value)
        {
            this.value = value;
        }
    }
}
