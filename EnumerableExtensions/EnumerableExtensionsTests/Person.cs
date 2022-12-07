namespace EnumerableExtensionsTests
{
    internal class Person
    {
        internal string Name;
        internal DateOnly DateOfBirth;
        internal ICollection<string> Titles;

        public Person(string name, DateOnly dateOfBirth, string[] titles)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Titles = titles;
        }
    }
}