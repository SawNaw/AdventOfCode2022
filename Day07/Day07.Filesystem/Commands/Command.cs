using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07.Filesystem.Commands
{
    internal abstract record class Command
    {
        public string Content { get; }
        public Command(string line)
        {
            if (!line.StartsWith('$'))
            {
                throw new ArgumentException($"{line} is not a valid command.");
            }
            Content = line;
        }
    }
}
