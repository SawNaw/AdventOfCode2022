using Day11.Framework;

namespace Day11.Tests
{
    public class MonkeyTests
    {
        [Test]
        public void Constructor_Sets_WorryLevels_To_StartingItems()
        {
            var sut = new Monkey(x => x + 3, new Test(17, 0, 1), 1, 3, 5, 7);

            Assert.Multiple(() =>
            {
                Assert.That(sut.Items, Has.Count.EqualTo(4));
                Assert.That(sut.Items.ElementAt(0), Is.EqualTo(1));
                Assert.That(sut.Items.ElementAt(1), Is.EqualTo(3));
                Assert.That(sut.Items.ElementAt(2), Is.EqualTo(5));
                Assert.That(sut.Items.ElementAt(3), Is.EqualTo(7));
            });
        }

        [Test]
        public void DoOperation_Sets_WorryLevels_ToNewLevels()
        {
            var sut = new Monkey(x => x + 3, new Test(17, 0, 1), 1, 3, 5, 7);
            var result = sut.Items.Select(x => sut.Operation(x));

            Assert.Multiple(() =>
            {
                Assert.That(result.Count, Is.EqualTo(4));
                Assert.That(result.ElementAt(0), Is.EqualTo(4));
                Assert.That(result.ElementAt(1), Is.EqualTo(6));
                Assert.That(result.ElementAt(2), Is.EqualTo(8));
                Assert.That(result.ElementAt(3), Is.EqualTo(10));
            });
        }

        [Test]
        public void Throw_AddsItem_To_End_Of_Target_Monkeys_List()
        {
            var monkey = new Monkey(x => x + 3, new Test(17, 0, 1), 1, 2);
            var targetMonkey = new Monkey(x => x + 3, new Test(17, 0, 1), 3, 4);

            Assert.Multiple(() =>
            {
                Assert.That(targetMonkey.Items, Has.Count.EqualTo(2));
                Assert.That(targetMonkey.Items.ElementAt(0), Is.EqualTo(3));
                Assert.That(targetMonkey.Items.ElementAt(1), Is.EqualTo(4));
            });

            monkey.ThrowTo(targetMonkey);

            Assert.Multiple(() =>
            {
                Assert.That(monkey.Items.Single(), Is.EqualTo(2));
            });

            Assert.Multiple(() =>
            {
                Assert.That(targetMonkey.Items, Has.Count.EqualTo(3));
                Assert.That(targetMonkey.Items.ElementAt(0), Is.EqualTo(3));
                Assert.That(targetMonkey.Items.ElementAt(1), Is.EqualTo(4));
                Assert.That(targetMonkey.Items.ElementAt(2), Is.EqualTo(1));
            });

            monkey.ThrowTo(targetMonkey);

            Assert.Multiple(() =>
            {
                Assert.That(monkey.Items.Any(), Is.False);
            });

            Assert.Multiple(() =>
            {
                Assert.That(targetMonkey.Items, Has.Count.EqualTo(4));
                Assert.That(targetMonkey.Items.ElementAt(0), Is.EqualTo(3));
                Assert.That(targetMonkey.Items.ElementAt(1), Is.EqualTo(4));
                Assert.That(targetMonkey.Items.ElementAt(2), Is.EqualTo(1));
                Assert.That(targetMonkey.Items.ElementAt(3), Is.EqualTo(2));
            });
        }

        [Test]
        public void GetMonkeysFromFile_WorksAsExpected()
        {
            List<Monkey> monkeys = Monkey.GetMonkeysFromFile("testinput.txt").ToList();
            var firstMonkey = monkeys.First();
            var secondMonkey = monkeys.ElementAt(1);
            var thirdMonkey = monkeys.ElementAt(2);
            var fourthMonkey = monkeys.ElementAt(3);

            Assert.Multiple(() =>
            {
                Assert.That(firstMonkey.Items, Has.Count.EqualTo(2));
                Assert.That(firstMonkey.Items.ElementAt(0), Is.EqualTo(79));
                Assert.That(firstMonkey.Items.ElementAt(1), Is.EqualTo(98));

                Assert.That(firstMonkey.Operation(1), Is.EqualTo(19));

                Assert.That(firstMonkey.Test.IsPass(161), Is.True);
                Assert.That(firstMonkey.Test.IsPass(162), Is.False);
            });

            Assert.Multiple(() =>
            {
                Assert.That(secondMonkey.Items, Has.Count.EqualTo(4));
                Assert.That(secondMonkey.Items.ElementAt(0), Is.EqualTo(54));
                Assert.That(secondMonkey.Items.ElementAt(1), Is.EqualTo(65));
                Assert.That(secondMonkey.Items.ElementAt(2), Is.EqualTo(75));
                Assert.That(secondMonkey.Items.ElementAt(3), Is.EqualTo(74));

                Assert.That(secondMonkey.Operation(7), Is.EqualTo(13));

                Assert.That(secondMonkey.Test.IsPass(133), Is.True);
                Assert.That(secondMonkey.Test.IsPass(134), Is.False);
            });

            Assert.Multiple(() =>
            {
                Assert.That(thirdMonkey.Items, Has.Count.EqualTo(3));
                Assert.That(thirdMonkey.Items.ElementAt(0), Is.EqualTo(79));
                Assert.That(thirdMonkey.Items.ElementAt(1), Is.EqualTo(60));
                Assert.That(thirdMonkey.Items.ElementAt(2), Is.EqualTo(97));

                Assert.That(thirdMonkey.Operation(9), Is.EqualTo(81));

                Assert.That(thirdMonkey.Test.IsPass(91), Is.True);
                Assert.That(thirdMonkey.Test.IsPass(92), Is.False);
            });

            Assert.Multiple(() =>
            {
                Assert.That(fourthMonkey.Items, Has.Count.EqualTo(1));
                Assert.That(fourthMonkey.Items.ElementAt(0), Is.EqualTo(74));

                Assert.That(fourthMonkey.Operation(1), Is.EqualTo(4));

                Assert.That(fourthMonkey.Test.IsPass(119), Is.True);
                Assert.That(fourthMonkey.Test.IsPass(120), Is.False);
            });
        }
    }
}