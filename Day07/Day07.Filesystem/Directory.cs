using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07.Filesystem
{
    internal class Directory : File // in Linux, a directory is just a type of file, so let's use that design here.
    {
        private const int EmptyDirectorySize = 0;
        private List<File> _content;
        internal IReadOnlyCollection<File> Content => _content;
        internal override int Size => _content.Sum(c => c.Size);
        internal int TotalSizeOfAllLessThanHundredThousand => _content.Sum(c => c.Size <= 100000 ? c.Size : 0);
        public Directory(string name) : base(name, EmptyDirectorySize)
        {
            _content = new();
        }

        public void Add(File fileOrDirectory)
        {
            if (_content.Any(x => x.Name == fileOrDirectory.Name))
            {
                throw new InvalidOperationException($"A directory or file with the name {fileOrDirectory.Name} already exists.");
            }
            else
            {
                fileOrDirectory.ParentDirectory = this;
                _content.Add(fileOrDirectory);
            }
        }
    }
}
