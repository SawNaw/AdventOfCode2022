using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day07.Filesystem.Commands
{
    internal record class CdCommand : Command
    {
        public string TargetDirectory => this.Content.Split(' ')[1];
        public CdCommand(string content) : base(content)
        {
        }
    }
}
