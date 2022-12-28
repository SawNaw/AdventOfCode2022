using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07.Filesystem.Commands
{
    internal record class LsCommand : Command
    {
        public LsCommand(string line) : base(line)
        {
        }
    }
}
