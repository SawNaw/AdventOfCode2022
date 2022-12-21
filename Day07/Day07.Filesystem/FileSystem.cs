using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07.Filesystem
{
    internal class FileSystem
    {
        private List<File> _content = new();
        public IReadOnlyCollection<File> Content => _content;

        public void ExecuteCommand(Command cmd)
        {

        }

        private void ExecuteLsCommand()
        {

        }

        private void ExecuteCdCommand()
        {

        }
    }
}
