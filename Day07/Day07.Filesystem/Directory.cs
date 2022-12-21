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
        public Directory(string name) : base(name, EmptyDirectorySize)
        {
            _content = new();
        }

        public void Add(File f)
        {
            if (_content.Any(x => x.Name == f.Name))
            {
                throw new InvalidOperationException($"A directory or file with the name {f.Name} already exists.");
            }
            else
            {
                _content.Add(f);
            }
        }
    }
}
