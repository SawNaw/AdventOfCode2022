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
        private readonly Directory _rootDirectory = new("/");
        public Directory CurrentDirectory { get; private set; }
        public int TotalSize => _rootDirectory.Size;

        public FileSystem(string inputFilePath)
        {
            _inputFileContent = System.IO.File.ReadAllLines(inputFilePath);
            CurrentDirectory = _rootDirectory;
        }

        public void ProcessFile()
        {
            foreach (var line in _inputFileContent)
            {
                if (line.StartsWith("$ cd"))
                {
                    ExecuteCdCommand(line);
                }
                else if (line.StartsWith("$ ls"))
                {
                    ExecuteLsCommand(line);
                }
                else // at this point, the line represents a file or a directory
                {
                    var outputLine = new LineOfOutput(line);
                    if (outputLine.IsFile)
                    {
                        CurrentDirectory.Add(new File(outputLine.Name, outputLine.Size));
                    }
                    else if (outputLine.IsDirectory)
                    {
                        CurrentDirectory.Add(new Directory(outputLine.Name));
                    }
                }
            }
        }

        public void ExecuteCommand(string command)
        {
            if (command.StartsWith("$ cd"))
            {
                ExecuteCdCommand(command);
            }

            else
            {
                throw new ArgumentException($"Unrecognised command {command}", nameof(command));
            }
        }

        public int GetTotalSizeForPartOne()
        {
            int total = 0;
            total += GetTotalSizeForPartOneCore(_rootDirectory);
            return total;
        }

        private void ExecuteCdCommand(string cmd)
        {
            string argument = cmd.Split(' ').ElementAt(2);

            // At the start of the input file, so don't do anything.
            if (argument == "/")
            {
                return;
            }

            if (argument == "..")
            {
                CurrentDirectory = CurrentDirectory.ParentDirectory ?? throw new ArgumentException("This directory has no parent!"); 
            }

            if (CurrentDirectory.Content.Any(c => c.Name == argument))
            {
                CurrentDirectory = (Directory)CurrentDirectory.Content.Single(c => c.Name == argument);
            }
        }

        private void ExecuteLsCommand(string cmd)
        {
        }

        private int GetTotalSizeForPartOneCore(Directory d)
        {
            int total = 0;
            foreach (Directory item in d.Content.Where(c => c is Directory)) 
            {
                if (item.Size <= 100000)
                {
                    total += item.Size;
                }

                total += GetTotalSizeForPartOneCore(item);
            }
            return total;
        }
    }
}
