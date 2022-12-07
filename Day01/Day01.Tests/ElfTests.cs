namespace Day01.Tests
{
    public class ElfTests
    {
        [Test]
        public void NumberOfFoodItems_Returns_NumberOfItems()
        {
            var elf = new Elf(new[] { 234, 415, 123, 4, 23, 3 });
            Assert.That(elf.NumberOfFoodItems, Is.EqualTo(6));
        }

        [Test]
        public void Sum_ReturnsSum_OfAllCalories()
        {
            var elf = new Elf(new[] { 1, 2, 3, 5 });
            Assert.That(elf.TotalCalories, Is.EqualTo(11));
        }

        [Test]
        public void Can_Initialise_With_String_Array()
        {
            var elf = new Elf(new [] { "1", "2", "3", "4"});
            Assert.That(elf.TotalCalories, Is.EqualTo(10));
        }
    }
}