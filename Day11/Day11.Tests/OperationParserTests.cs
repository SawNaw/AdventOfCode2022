using Day11.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11.Tests
{
    internal class OperationParserTests
    {
        [TestCase(2, 4)]
        [TestCase(9, 81)]
        public void GetFromLine_Parses_OldTimesOld_Correctly(int input, int expected)
        {
            var result = OperationParser.GetFromline("  Operation: new = old * old");
            Assert.Multiple(() =>
            {
                Assert.That(result(input), Is.EqualTo(expected));
                Assert.That(result(input), Is.EqualTo(expected));
            });
        }

        [TestCase(2, 3, 6)]
        [TestCase(5, 7, 35)]
        public void GetFromLine_Parses_Multiplications_Correctly(int original, int multiplier, int expected)
        {
            var result = OperationParser.GetFromline($"  Operation: new = old * {multiplier}");
            Assert.That(result(original), Is.EqualTo(expected));
        }

        [TestCase(2, 3, 5)]
        [TestCase(5, 7, 12)]
        public void GetFromLine_Parses_Additions_Correctly(int original, int operand, int expected)
        {
            var result = OperationParser.GetFromline($"  Operation: new = old + {operand}");
            Assert.That(result(original), Is.EqualTo(expected));
        }
    }
}
