﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AteraMission.Models.Calculator
{
    public class Div : Operator
    {
        public double Calculate(double left, double right) => left / right;
    }
}
