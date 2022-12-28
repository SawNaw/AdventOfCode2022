using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day07.Filesystem.Commands;

namespace Day07.Filesystem
{
    /// <summary>
    /// Reads the puzzle input and builds the directory structure from it, 
    /// recording file sizes as necessary.
    /// </summary>
    internal class FileSystem
    {
        private readonly string[] _inputFileContent;
        private Directory _currentDirectory = new Directory("/");
        private List<File> _content = new();
        public IReadOnlyCollection<File> Content => _content;
        public FileSystem(string inputFilePath)
        {
            _inputFileContent = System.IO.File.ReadAllLines(inputFilePath);
        }

        public void ProcessFile()
        {
            foreach (var line in _inputFileContent)
            {
                if (line.StartsWith("$ cd"))
                { }
            }
        }

        public void ExecuteCommand(Command cmd)
        {
            if (cmd is LsCommand lsCmd)
            {
                ExecuteLsCommand(lsCmd);
            }
            else if (cmd is CdCommand cdCmd)
            {
                ExecuteCdCommand(cdCmd);
            }
            else
            {
                throw new ArgumentException($"Unrecognised command {cmd}", nameof(cmd));
            }
        }

        private void ExecuteLsCommand(LsCommand cmd)
        {

        }

        private void ExecuteCdCommand(CdCommand cmd)
        {

        }
    }
}
