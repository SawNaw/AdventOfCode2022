namespace Day07.Filesystem
{
    internal class File
    {
        internal string Name { get; }
        internal virtual int Size { get; }
        internal Directory? ParentDirectory { get; set; }
        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}