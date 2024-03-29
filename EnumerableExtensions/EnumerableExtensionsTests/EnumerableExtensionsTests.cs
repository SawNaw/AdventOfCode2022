using EnumerableExtensions;

namespace EnumerableExtensionsTests
{
    public partial class Tests
    {
        private static IEnumerable<Person> GetPersonList()
        {
            return new Person[]
            {
                new Person("John", new DateOnly(2020, 01, 02), new[] { "manager", "administrator" }),
                new Person("Mike Wang", new DateOnly(2022, 10, 11), new[] { "engineer", "developer" }),
                new Person("Susanna Dai", new DateOnly(2021, 11, 04), new[] { "doctor", "surgeon" }),
                new Person("Wilbur", new DateOnly(1999, 11, 21), new[] { "manager", "administrator" }),
                new Person("Shaun", new DateOnly(2022, 08, 31), new[] { "pilot" }),
                new Person("Sephiroth", new DateOnly(1982, 04, 24), new[] { "doctor", "surgeon" }),
                new Person("Mario", new DateOnly(1986, 01, 12), new[] { "manager", "administrator" }),
                new Person("Michael", new DateOnly(2022, 10, 12), new[] { "engineer", "developer" }),
                new Person("Bowser", new DateOnly(2021, 11, 05), new[] { "sales" }),
                new Person("Zack", new DateOnly(2022, 10, 12), new[] { "manager", "surgeon" })
            };
        }

        [Test]
        public void Split_Works_With_Doubles()
        {
            double[] things = { 1.1, 2.1, 3.1, 0.1, 4.1, 5.1, 0.2, 6.1, 7.1 };
            var edibleThings = things.Split(0.1, 0.2);

            Assert.Multiple(() =>
            {
                // Check outer collection
                Assert.That(edibleThings.Count, Is.EqualTo(3));

                // Check inner collections
                Assert.That(edibleThings.First().First(), Is.EqualTo(1.1));
                Assert.That(edibleThings.First().ElementAt(1), Is.EqualTo(2.1));
                Assert.That(edibleThings.First().ElementAt(2), Is.EqualTo(3.1));
                Assert.That(edibleThings.First().Count, Is.EqualTo(3));

                Assert.That(edibleThings.ElementAt(1).ElementAt(0), Is.EqualTo(4.1));
                Assert.That(edibleThings.ElementAt(1).ElementAt(1), Is.EqualTo(5.1));
                Assert.That(edibleThings.ElementAt(1).Count, Is.EqualTo(2));

                Assert.That(edibleThings.ElementAt(2).ElementAt(0), Is.EqualTo(6.1));
                Assert.That(edibleThings.ElementAt(2).ElementAt(1), Is.EqualTo(7.1));
                Assert.That(edibleThings.ElementAt(2).Count, Is.EqualTo(2));
            });
        }

        [Test]
        public void Split_Works_With_Params()
        {
            string[] things = { "pie", "apple", "cake", "mud-pie", "nuts", "plum", "mud-spread", "milk", "butter" };
            var edibleThings = things.Split("mud-pie", "mud-spread");

            Assert.Multiple(() =>
            {
                // Check outer collection
                Assert.That(edibleThings.Count, Is.EqualTo(3));

                // Check inner collections
                Assert.That(edibleThings.First().First(), Is.EqualTo("pie"));
                Assert.That(edibleThings.First().ElementAt(1), Is.EqualTo("apple"));
                Assert.That(edibleThings.First().ElementAt(2), Is.EqualTo("cake"));
                Assert.That(edibleThings.First().Count, Is.EqualTo(3));

                Assert.That(edibleThings.ElementAt(1).ElementAt(0), Is.EqualTo("nuts"));
                Assert.That(edibleThings.ElementAt(1).ElementAt(1), Is.EqualTo("plum"));
                Assert.That(edibleThings.ElementAt(1).Count, Is.EqualTo(2));

                Assert.That(edibleThings.ElementAt(2).ElementAt(0), Is.EqualTo("milk"));
                Assert.That(edibleThings.ElementAt(2).ElementAt(1), Is.EqualTo("butter"));
                Assert.That(edibleThings.ElementAt(2).Count, Is.EqualTo(2));
            });
        }

        [Test]
        public void Split_Works_With_Given_Condition()
        {
            string[] things = { "pie", "apple", "cake", "mud-pie", "nuts", "plum", "mud-spread", "milk", "butter" };
            var edibleThings = things.Split(t => t.StartsWith("mud"));

            Assert.Multiple(() =>
            {
                // Check outer collection
                Assert.That(edibleThings.Count, Is.EqualTo(3));

                // Check inner collections
                Assert.That(edibleThings.First().First(), Is.EqualTo("pie"));
                Assert.That(edibleThings.First().ElementAt(1), Is.EqualTo("apple"));
                Assert.That(edibleThings.First().ElementAt(2), Is.EqualTo("cake"));
                Assert.That(edibleThings.First().Count, Is.EqualTo(3));

                Assert.That(edibleThings.ElementAt(1).ElementAt(0), Is.EqualTo("nuts"));
                Assert.That(edibleThings.ElementAt(1).ElementAt(1), Is.EqualTo("plum"));
                Assert.That(edibleThings.ElementAt(1).Count, Is.EqualTo(2));

                Assert.That(edibleThings.ElementAt(2).ElementAt(0), Is.EqualTo("milk"));
                Assert.That(edibleThings.ElementAt(2).ElementAt(1), Is.EqualTo("butter"));
                Assert.That(edibleThings.ElementAt(2).Count, Is.EqualTo(2));
            });
        }

        [Test]
        public void Split_Works_With_Multiple_Conditions()
        {
            var list = GetPersonList();

            var result = list.Split(l => l.Titles.Contains("pilot") || l.Titles.Contains("sales"));
            var t = list.GroupBy(x => x.Name == "Shaun");

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(result.Where(r => r.Any(t => t.Titles.Contains("pilot"))), Is.Empty);
                Assert.That(result.Where(r => r.Any(t => t.Titles.Contains("sales"))), Is.Empty);
                Assert.That(result.First().Count, Is.EqualTo(4));
                Assert.That(result.ElementAt(1).Count, Is.EqualTo(3));
                Assert.That(result.ElementAt(2).Count, Is.EqualTo(1));
                Assert.That(result.Any(r => r.Any(t => t.Name == "Shaun")), Is.False);
                Assert.That(result.Any(r => r.Any(t => t.Name == "Bowser")), Is.False);
            });
        }

        [Test]
        public void Split_Works_With_Classes_Based_On_Given_Separators()
        {
            var list = GetPersonList();
            var result = list.Split(l => l.Name.Length < 9);
            var c = new[] { 'a', 'b' };

            Assert.Multiple(() =>
            {
                Assert.That(result.Count, Is.EqualTo(2));
                Assert.That(result.First().Count, Is.EqualTo(2));
                Assert.That(result.ElementAt(1).Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void Split_Works_With_Classes_Based_On_Given_Condition()
        {
            var list = GetPersonList();
            var result = list.Split(l => l.DateOfBirth.Year < 2000);

            Assert.Multiple(() =>
            {
                Assert.That(result.Count, Is.EqualTo(3));
                Assert.That(result.First().Count, Is.EqualTo(3));
                Assert.That(result.ElementAt(1).Count, Is.EqualTo(1));
                Assert.That(result.ElementAt(2).Count, Is.EqualTo(3));
                Assert.That(result.Any(r => r.Any(t => t.Name == "Wilbur")), Is.False);
                Assert.That(result.Any(r => r.Any(t => t.Name == "Mario")), Is.False);
            });
        }

        [Test]
        public void Split_Works_On_Text_File_Containing_Records_Separated_By_Newlines()
        {
            var file = File.ReadAllLines("TestInput.txt");
            var result = file.Split(x => string.IsNullOrWhiteSpace(x));

            var firstCollection = result.First();
            var secondCollection = result.ElementAt(1);
            var thirdCollection = result.ElementAt(2);

            Assert.That(result.All(x => x.Count() == 3), Is.True);

            Assert.Multiple(() =>
            {
                Assert.That(firstCollection.First(), Is.EqualTo("Blah Blah Information One"));
                Assert.That(firstCollection.ElementAt(1), Is.EqualTo("Yadda Yadda Information One"));
                Assert.That(firstCollection.ElementAt(2), Is.EqualTo("Test Test Information One"));

                Assert.That(secondCollection.First(), Is.EqualTo("Blah Blah Information Two"));
                Assert.That(secondCollection.ElementAt(1), Is.EqualTo("Yadda Yadda Information Two"));
                Assert.That(secondCollection.ElementAt(2), Is.EqualTo("Test Test Information Two"));

                Assert.That(thirdCollection.First(), Is.EqualTo("Blah Blah Information Three"));
                Assert.That(thirdCollection.ElementAt(1), Is.EqualTo("Yadda Yadda Information Three"));
                Assert.That(thirdCollection.ElementAt(2), Is.EqualTo("Test Test Information Three"));
            });
            
        }
    }
}