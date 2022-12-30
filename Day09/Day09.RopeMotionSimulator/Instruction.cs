namespace Day09.RopeMotionSimulator
{
    internal class Instruction
    {
        internal Direction Direction { get; }
        internal int Steps { get; }
        internal Instruction(Direction direction, int steps)
        {
            Direction = direction;
            Steps = steps;
        }
    }
}