namespace Day09.RopeMotionSimulator
{
    /// <summary>
    /// Simulates the movement of a knotted rope as dictated by instructions.
    /// </summary>
    internal class MotionSimulator
    {
        private readonly IEnumerable<Instruction> instructions;
        private readonly HashSet<Coordinate> visitedCoordinates = new();
        private readonly KnottedRope rope;

        // To examine pairs of knots while traversing down the rope for part 2.
        private Knot frontKnot;
        private Knot backKnot;

        internal MotionSimulator(string instructionFilePath, int numberOfKnots)
        {
            instructions = LoadInstructions(instructionFilePath);
            visitedCoordinates.Add(new Coordinate(0, 0));

            rope = new KnottedRope(numberOfKnots);

            frontKnot = rope.Head;
            backKnot = rope.Tail;
        }

        /// <summary>
        /// Executes all movement instructions from the input file.
        /// </summary>
        /// <returns>The number of distinct visited coordinates.</returns>
        public int ExecuteAllInstructions()
        {
            foreach (var instruction in instructions)
            {
                ExecuteInstruction(instruction);
            }

            return visitedCoordinates.Count;
        }

        private void ExecuteInstruction(Instruction instruction)
        {
            for (int i = 1; i <= instruction.Steps; i++)
            {
                // Move the head knot by one step
                MoveHead(instruction);

                // Move the other knots if necessary
                for (int j = 1; j < rope.Knots.Count; j++)
                {
                    backKnot = rope.Knots.ElementAt(j);
                    frontKnot = rope.Knots.ElementAt(j - 1);

                    if (frontKnot.IsNotTouching(backKnot))
                    {
                        MoveOtherKnots();
                    }
                }

                visitedCoordinates.Add(new Coordinate(rope.Tail.X, rope.Tail.Y));
            }

        }

        private Coordinate MoveHead(Instruction instruction) => instruction.Direction switch
        {
            Direction.Up => rope.Head.MoveUp(),
            Direction.Down => rope.Head.MoveDown(),
            Direction.Left => rope.Head.MoveLeft(),
            Direction.Right => rope.Head.MoveRight(),
            _ => throw new NotImplementedException($"{instruction.Direction} is not a recognised direction")
        };

        private void MoveOtherKnots()
        {
            if (frontKnot.IsDirectlyAbove(backKnot))
            {
                backKnot.MoveUp();
            }
            else if (frontKnot.IsDirectlyBelow(backKnot))
            {
                backKnot.MoveDown();
            }
            else if (frontKnot.IsDirectlyToTheLeftOf(backKnot))
            {
                backKnot.MoveLeft();
            }
            else if (frontKnot.IsDirectlyToTheRightOf(backKnot))
            {
                backKnot.MoveRight();
            }
            else if (frontKnot.IsAboveAndToTheRightOf(backKnot))
            {
                backKnot.MoveDiagonallyUpAndRight();
            }
            else if (frontKnot.IsAboveAndToTheLeftOf(backKnot))
            {
                backKnot.MoveDiagonallyUpLeft();
            }
            else if (frontKnot.IsBelowAndToTheRightOf(backKnot))
            {
                backKnot.MoveDiagonallyDownRight();
            }
            else if (frontKnot.IsBelowAndToTheLeftOf(backKnot))
            {
                backKnot.MoveDiagonallyDownLeft();
            }
            else
            {
                throw new InvalidOperationException("The head and tail should not be touching or overlapping for this.");
            }

        }

        private static IEnumerable<Instruction> LoadInstructions(string filePath)
        {
            return File.ReadAllLines(filePath)
                       .Select(x => x.Split(' '))
                       .Select(x => new Instruction(GetDirectionFromLetter(x.First()), int.Parse(x[1])));

        }

        private static Direction GetDirectionFromLetter(string letter) => Char.Parse(letter) switch
        {
            'U' => Direction.Up,
            'D' => Direction.Down,
            'L' => Direction.Left,
            'R' => Direction.Right,
            _ => throw new ArgumentException($"The letter {letter} is not a recognised direction.", nameof(letter)),
        };
    }
}
