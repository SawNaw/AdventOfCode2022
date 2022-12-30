using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Tests
{
    public class ForestTests
    {
        [Fact]
        public void Constructor_CreatesForest_FromFile()
        {
            var forest = new Forest(@"testinput.txt");

            // Check a few tree heights
            Assert.Equal(3, forest.TreeAt(0, 0).Height);
            Assert.Equal(5, forest.TreeAt(1, 1).Height);
            Assert.Equal(5, forest.TreeAt(1, 2).Height);
            Assert.Equal(4, forest.TreeAt(3, 3).Height);
            Assert.Equal(9, forest.TreeAt(3, 4).Height);
            Assert.Equal(9, forest.TreeAt(4, 3).Height);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(0, 3)]
        [InlineData(0, 4)]
        [InlineData(1, 0)]
        [InlineData(2, 0)]
        [InlineData(3, 0)]
        [InlineData(4, 0)]
        [InlineData(4, 1)]
        [InlineData(4, 2)]
        [InlineData(4, 3)]
        [InlineData(4, 4)]
        [InlineData(1, 4)]
        [InlineData(2, 4)]
        [InlineData(3, 4)]
        public void IsVisible_ReturnsTrue_ForAllTrees_On_Edges(int x, int y)
        {
            var forest = new Forest(@"testinput.txt");

            Assert.True(forest.IsVisibleFromLeft(x, y));
            Assert.True(forest.IsVisibleFromRight(x, y));
            Assert.True(forest.IsVisibleFromTop(x, y));
            Assert.True(forest.IsVisibleFromBottom(x, y));
            Assert.True(forest.IsVisibleFromAnyDirection(x, y));
        }
    }
}
