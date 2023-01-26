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
