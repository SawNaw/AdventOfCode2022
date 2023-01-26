namespace Day10.CPU
{
    internal class QueuedInstruction
    {
        public Instruction Instruction { get; }
        public int ExecutionTimer { get; set; }
        public QueuedInstruction(Instruction instruction, int cyclesToComplete)
        {
            Instruction = instruction;
            ExecutionTimer = cyclesToComplete;
        }
    }
}
