namespace Day10.Tests
{
    public class Tests
    {
        [TestCase(3)]
        [TestCase(-5)]
        public void AddInstruction_InitialisesCorrectly(int value)
        {
            var inst = new AddInstruction(Registers.X, value);

            Assert.Multiple(() =>
            {
                Assert.That(inst.Register, Is.EqualTo(Registers.X));
                Assert.That(inst.Value, Is.EqualTo(value));
            });
        }
    }
}