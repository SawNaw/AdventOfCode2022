using Day07.Filesystem;
using Day07.Filesystem.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07.Tests
{
    internal class FileSystemTests
    {
        [Test]
        public void SimpleTestInput_ProcessesCorrectly()
        {
            var fileSystem = new FileSystem(@"TestInput\SimpleTestInput.txt");
            fileSystem.ProcessFile();

            Assert.Multiple(() =>
            {
                Assert.That(fileSystem.CurrentDirectory.Name, Is.EqualTo("/"));
                Assert.That(fileSystem.CurrentDirectory.Content.First().Name, Is.EqualTo("a"));
                Assert.That(fileSystem.CurrentDirectory.Content.ElementAt(1).Name, Is.EqualTo("b.txt"));
                Assert.That(fileSystem.CurrentDirectory.Content.ElementAt(1).Size, Is.EqualTo(14848514));
                Assert.That(fileSystem.CurrentDirectory.Content.ElementAt(2).Name, Is.EqualTo("c.dat"));
                Assert.That(fileSystem.CurrentDirectory.Content.ElementAt(2).Size, Is.EqualTo(8504156));
                Assert.That(fileSystem.CurrentDirectory.Content.ElementAt(3).Name, Is.EqualTo("d"));
            });
        }

        [Test]
        public void FullTestInput_ProcessesCorrectly()
        {
            var fileSystem = new FileSystem(@"TestInput\testinput.txt");
            fileSystem.ProcessFile();

            Assert.That(fileSystem.TotalSize, Is.EqualTo(48381165));
            Assert.That(fileSystem.GetTotalSizeForPartOne(fileSystem.RootDirectory), Is.EqualTo(95437));
        }

        [Test]
        public void ExecutingLsCommand_AddsAllContent_ToCurrentDirectory()
        {
            var fs = new FileSystem(@"TestInput\BlankForTestPurposes.txt");
            //fs.ExecuteCommand(new Command("dir a"));
        }

        [Test]
        public void ProcessDirectory_AddsDirectory_ToContent()
        {
            
            //var cmd = new Command("")
        }
    }
}
