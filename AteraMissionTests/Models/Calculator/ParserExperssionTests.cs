using Microsoft.VisualStudio.TestTools.UnitTesting;
using AteraMission.Models.Calculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace AteraMission.Models.Calculator.Tests
{
    [TestClass()]
    public class ParserExperssionTests
    {
        [TestMethod()]
        public void ParserTestSimpale()
        {
            string exp = "1+1";
            double expected = 2;

            double res = ParserExperssion.Parser(exp);

            Assert.AreEqual(expected, res, $"Test ParserTestSimpale failed, exp: '{exp}', expected: '{expected}', result: '{res}'.");
        }

        [TestMethod()]
        public void ParserTestAdvenced()
        {
            string exp = "10.3 + 2.5 * 2 - 2*4.5/3";
            double expected = 12.3;

            double res = ParserExperssion.Parser(exp);

            Assert.AreEqual(expected, res, $"Test ParserTestAdvenced failed, exp: '{exp}', expected: '{expected}', result: '{res}'.");
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidInputException), "Test ParserTestInvalidInputException failed, InvalidInputException not throw when  experssion 'r + 2' parse.")]
        public void ParserTestInvalidInputException()
        {
            string exp = "r + 2";

            ParserExperssion.Parser(exp);
        }
    }
}