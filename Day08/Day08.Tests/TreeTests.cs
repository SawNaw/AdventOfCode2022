using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day08.Trees;

namespace Day08.Tests
{
    public class TreeTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-99)]
        [InlineData(10)]
        [InlineData(199)]
        public void Invalid_Heights_Throw(int height)
        {
            Assert.Throws<ArgumentException>(() => new Tree(height));
        }
    }
}
