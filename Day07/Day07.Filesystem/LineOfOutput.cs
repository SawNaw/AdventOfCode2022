namespace Day07.Filesystem
{
    /// <summary>
    /// Represents a line of output obtained after an ls command is read.
    /// Determines its own content, type, name and size.
    /// Example content:
    ///   dir a
    ///   14848514 b.txt
    ///   8504156 c.dat
    ///   dir d
    /// </summary>
    internal record class LineOfOutput
    {
        public string Content { get; }
        public bool IsFile => IsValidFile();
        public bool IsDirectory => Content.StartsWith("dir");
        public string Name => Content.Split(' ').ElementAt(1);
        public int Size => GetSize();
        public LineOfOutput(string line)
        {
            this.Content = line;
        }

        private bool IsValidFile()
        {
            string[] splitLine = Content.Split(' ');

            return (int.TryParse(splitLine[0], out _));
        }

        private int GetSize()
        {
            return IsFile
                ? int.Parse(Content.Split(' ').First())
                : 0;
        }
    }
}
