namespace Day07.Filesystem
{
    internal class File
    {
        internal string Name { get; }
        internal virtual int Size { get; }
        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}