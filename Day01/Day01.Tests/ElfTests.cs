namespace Day01.Tests
{
    public class ElfTests
    {
        [Test]
        public void Can_Initialise_With_String_Array()
        {
            var elf = new Elf(new [] { "1", "2", "3", "4"});
            Assert.That(elf.TotalCalories, Is.EqualTo(10));
        }
    }
}