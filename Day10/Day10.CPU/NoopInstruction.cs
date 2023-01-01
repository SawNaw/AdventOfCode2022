using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.CPU
{
    internal record NoopInstruction : Instruction
    {
        public NoopInstruction() : base()
        {

        }
    }
}
