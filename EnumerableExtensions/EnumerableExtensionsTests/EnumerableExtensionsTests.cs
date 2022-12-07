using EnumerableExtensions;

namespace EnumerableExtensionsTests
{
    public partial class Tests
    {
        private static List<Person> GetList()
        {
            var list = new List<Person>();
            list.Add(new Person("John", new DateOnly(2020, 01, 02), new[] { "manager", "administrator" }));
            list.Add(new Person("Mike Wang", new DateOnly(2022, 10, 11), new[] { "engineer", "developer" }));
            list.Add(new Person("Susanna Dai", new DateOnly(2021, 11, 04), new[] { "doctor", "surgeon" }));
            list.Add(new Person("Wilbur", new DateOnly(1999, 11, 21), new[] { "manager", "administrator" }));
            list.Add(new Person("Shaun", new DateOnly(2022, 08, 31), new[] { "pilot" }));
            list.Add(new Person("Sephiroth", new DateOnly(1982, 04, 24), new[] { "doctor", "surgeon" }));
            list.Add(new Person("Mario", new DateOnly(1986, 01, 12), new[] { "manager", "administrator" }));
            list.Add(new Person("Michael", new DateOnly(2022, 10, 12), new[] { "engineer", "developer" }));
            list.Add(new Person("Bowser", new DateOnly(2021, 11, 05), new[] { "sales" }));
            list.Add(new Person("Zack", new DateOnly(2022, 10, 12), new[] { "manager", "surgeon" }));
            return list;
        }

        [Test]
        public void Simple_Numbers_Split_Works()
        {
            int[] numbers = new[] { 1, 2, 3, 4, 5, 6 };
            var result = numbers.SplitBy(n => n == 3);
        }

        [Test]
        public void Integration_Test_One()
        {
            List<Person> list = GetList();

            var result = list.SplitBy(l => l.Titles.Contains("pilot") || l.Titles.Contains("sales"));

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.Where(r => r.Any(t => t.Titles.Contains("pilot"))), Is.Empty);
            Assert.That(result.Where(r => r.Any(t => t.Titles.Contains("sales"))), Is.Empty);
            Assert.That(result.First().Count, Is.EqualTo(4));
            Assert.That(result.ElementAt(1).Count, Is.EqualTo(3));
            Assert.That(result.ElementAt(2).Count, Is.EqualTo(1));
            Assert.That(result.Any(r => r.Any(t => t.Name == "Shaun")), Is.False);
            Assert.That(result.Any(r => r.Any(t => t.Name == "Bowser")), Is.False);
        }

        [Test]
        public void Integration_Test_Two()
        {
            List<Person> list = GetList();
            var result = list.SplitBy(l => l.Name.Length < 9);

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.First().Count, Is.EqualTo(2));
            Assert.That(result.ElementAt(1).Count, Is.EqualTo(1));
        }

        [Test]
        public void Integration_Test_Three()
        {
            List<Person> list = GetList();
            var result = list.SplitBy(l => l.DateOfBirth.Year < 2000);

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.First().Count, Is.EqualTo(3));
            Assert.That(result.ElementAt(1).Count, Is.EqualTo(1));
            Assert.That(result.ElementAt(2).Count, Is.EqualTo(3));
            Assert.That(result.Any(r => r.Any(t => t.Name == "Wilbur")), Is.False);
            Assert.That(result.Any(r => r.Any(t => t.Name == "Mario")), Is.False);
        }
    }
}