using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10.CPU
{
    internal record AddInstruction : Instruction
    {
        internal Registers Register { get; }
        internal int Value { get; }
        public AddInstruction(Registers register, int value)
        {
            Register = register;
            Value = value;
        }
    }
}
