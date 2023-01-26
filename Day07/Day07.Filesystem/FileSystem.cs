using System.Data;

namespace Day07.Filesystem
{
    /// <summary>
    /// Reads the puzzle input and builds the directory structure from it, 
    /// recording file sizes as necessary.
    /// </summary>
    internal class FileSystem
    {
        private readonly string[] _inputFileContent;
        private readonly List<Directory> DeletionCandidates = new();
        public Directory RootDirectory { get; } = new("/");
        public Directory CurrentDirectory { get; private set; }
        public int TotalSize => RootDirectory.Size;
        public int UnusedSpace => 70000000 - TotalSize;
        public Directory SmallestDeletionCandidate => DeletionCandidates.MinBy(d => d.Size)!;

        public FileSystem(string inputFilePath)
        {
            _inputFileContent = System.IO.File.ReadAllLines(inputFilePath);
            CurrentDirectory = RootDirectory;
        }

        public void ProcessFile()
        {
            foreach (var line in _inputFileContent)
            {
                if (line.StartsWith("$ cd"))
                {
                    ExecuteCdCommand(line);
                }
                else
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

        public int GetTotalSizeForPartOne(Directory d)
        {
            int total = 0;
            var allSubdirectories = d.Content.Where(c => c is Directory).Cast<Directory>();
            foreach (Directory item in allSubdirectories)
            {
                if (item.Size <= 100000)
                {
                    total += item.Size;
                }

                total += GetTotalSizeForPartOne(item);
            }
            return total;
        }

        public void GetDeletionCandidatesForPartTwo(Directory d)
        {
            var allSubdirectories = d.Content.Where(c => c is Directory).Cast<Directory>();

            // Iterate over all subdirectories, identify deletion candidates
            foreach (Directory item in allSubdirectories)
            {
                if (UnusedSpace + item.Size >= 30000000)
                {
                    DeletionCandidates.Add(item);
                }
            }

            // Iterate over all subdiretories again, this time entering each subdirectory.
            foreach (Directory sub in allSubdirectories)
            {
                GetDeletionCandidatesForPartTwo(sub);
            }
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
    }
}
