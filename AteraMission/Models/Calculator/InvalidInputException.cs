using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AteraMission.Models.Calculator
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base("Invalid input") { }
    }
}
