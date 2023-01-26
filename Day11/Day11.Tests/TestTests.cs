using Day11.Framework;

namespace Day11.Tests
{
    internal class TestTests
    {
        [Test]
        public void Constructor_InitialisesAll()
        {
            var sut = new Test(23, 2, 3);

            Assert.Multiple(() =>
            {
                Assert.That(sut.Divisor, Is.EqualTo(23));
                Assert.That(sut.TargetIfTrue, Is.EqualTo(2));
                Assert.That(sut.TargetIfFalse, Is.EqualTo(3));
            });
        }

        [Test]
        public void IsPass_Returns_True_If_Divisible_By_Divisor()
        {
            var sut = new Test(17, 2, 3);

            Assert.Multiple(() =>
            {
                Assert.That(sut.IsPass(119), Is.True);
                Assert.That(sut.IsPass(118), Is.False);
            });
        }
    }
}
