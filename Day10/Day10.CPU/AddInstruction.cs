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
