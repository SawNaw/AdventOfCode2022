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
                // Move the head once
                MoveHead(instruction);

                // Move the other knots if necessary
                for (int j = 1; j < rope.Knots.Count; j++)
                {
                    backKnot = rope.Knots.ElementAt(j);
                    frontKnot = rope.Knots.ElementAt(j - 1);

                    if (Position.IsNotTouching(frontKnot, backKnot))
                    {
                        MoveTail();
                    }
                }

                if (!visitedCoordinates.Contains(rope.Tail.Position))
                {
                    visitedCoordinates.Add(rope.Tail.Position);
                }
            }

        }

        private void MoveHead(Instruction instruction)
        {
            switch (instruction.Direction)
            {
                case (Direction.Up):
                    rope.Head.MoveUp();
                    break;

                case (Direction.Down):
                    rope.Head.MoveDown();
                    break;

                case (Direction.Left):
                    rope.Head.MoveLeft();
                    break;

                case (Direction.Right):
                    rope.Head.MoveRight();
                    break;
            }
        }

        private void MoveTail()
        {
            if (Position.IsTouching(frontKnot, backKnot))
            {
                throw new InvalidOperationException("The tail should not be moved when it is touching the head.");
            }
            if (Position.FrontKnotIsDirectlyAbove(frontKnot, backKnot))
            {
                backKnot.MoveUp();
            }
            else if (Position.FrontKnotIsDirectlyBelow(frontKnot, backKnot))
            {
                backKnot.MoveDown();
            }
            else if (Position.FrontKnotIsDirectlyToTheLeft(frontKnot, backKnot))
            {
                backKnot.MoveLeft();
            }
            else if (Position.FrontKnotIsDirectlyToTheRight(frontKnot, backKnot))
            {
                backKnot.MoveRight();
            }
            else if (Position.FrontKnotIsAboveAndToTheRight(frontKnot, backKnot))
            {
                backKnot.MoveDiagonallyUpAndRight();
            }
            else if (Position.FrontKnotIsAboveAndToTheLeft(frontKnot, backKnot))
            {
                backKnot.MoveDiagonallyUpLeft();
            }
            else if (Position.FrontKnotIsBelowAndToTheRight(frontKnot, backKnot))
            {
                backKnot.MoveDiagonallyDownRight();
            }
            else if (Position.FrontKnotIsBelowAndToTheLeft(frontKnot, backKnot))
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
