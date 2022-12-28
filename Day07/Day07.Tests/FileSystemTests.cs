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
        public void ExecutingLsCommand_AddsAllContent_ToCurrentDirectory()
        {
            var fs = new FileSystem(@"BlankForTestPurposes.txt");
            //fs.ExecuteCommand(new Command("dir a"));
        }

        [Test]
        public void ProcessDirectory_AddsDirectory_ToContent()
        {
            
            //var cmd = new Command("")
        }
    }
}
