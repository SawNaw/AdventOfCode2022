using Day09.RopeMotionSimulator.RopeComponents;

namespace Day09.RopeMotionSimulator
{
    internal class MotionSimulator
    {
        private IEnumerable<Instruction> instructions;
        private HashSet<Coordinate> visitedCoordinates = new();
        private KnottedRope knottedRope;

        internal MotionSimulator(string instructionFilePath, Modes mode)
        {
            instructions = GetInstructionsFromFile(instructionFilePath);
            visitedCoordinates.Add(new Coordinate(0, 0));
            knottedRope = (mode == Modes.PartOne ? new KnottedRope(2) : new KnottedRope(10));
        }

        public int ExecuteInstructions()
        {
            foreach (var instruction in instructions)
            {
                ExecuteSingleInstruction(instruction);
            }

            return visitedCoordinates.Count;
        }

        public int ExecuteInstructionsPart2()
        {
            foreach (var instruction in instructions)
            {
                ExecuteSingleInstructionV2(instruction);
            }

            return visitedCoordinates.Count;
        }

        private void ExecuteSingleInstructionV2(Instruction instruction)
        {
            for (int i = 1; i <= instruction.Steps; i++)
            {
                MoveHead(instruction);

                if (IsNotTouching())
                {
                    MoveTail();
                }

                if (!visitedCoordinates.Contains(knottedRope.Tail.Position))
                {
                    visitedCoordinates.Add(knottedRope.Tail.Position);
                }
            }
        }

        private void ExecuteSingleInstruction(Instruction instruction)
        {
            for (int i = 1; i <= instruction.Steps; i++)
            {
                MoveHead(instruction);

                if (IsNotTouching())
                {
                    MoveTail();
                }

                if (!visitedCoordinates.Contains(knottedRope.Tail.Position))
                {
                    visitedCoordinates.Add(knottedRope.Tail.Position);
                }
            }
        }

        private void MoveHead(Instruction instruction)
        {
            switch (instruction.Direction)
            {
                case (Direction.Up):
                    knottedRope.Head.MoveUp();
                    break;

                case (Direction.Down):
                    knottedRope.Head.MoveDown();
                    break;

                case (Direction.Left):
                    knottedRope.Head.MoveLeft();
                    break;

                case (Direction.Right):
                    knottedRope.Head.MoveRight();
                    break;
            }
        }

        private void MoveTail()
        {
            if (IsTouching())
            {
                throw new InvalidOperationException("The tail should not be moved when it is touching the head.");
            }
            if (HeadIsDirectlyAbove())
            {
                knottedRope.Tail.MoveUp();
            }
            else if (HeadIsDirectlyBelow())
            {
                knottedRope.Tail.MoveDown();
            }
            else if (HeadIsDirectlyToTheLeft())
            {
                knottedRope.Tail.MoveLeft();
            }
            else if (HeadIsDirectlyToTheRight())
            {
                knottedRope.Tail.MoveRight();
            }
            else if (HeadIsAboveAndToTheRight())
            {
                knottedRope.Tail.MoveDiagonallyUpAndRight();
            }
            else if (HeadIsAboveAndToTheLeft())
            {
                knottedRope.Tail.MoveDiagonallyUpLeft();
            }
            else if (HeadIsBelowAndToTheRight())
            {
                knottedRope.Tail.MoveDiagonallyDownRight();
            }
            else if (HeadIsBelowAndToTheLeft())
            {
                knottedRope.Tail.MoveDiagonallyDownLeft();
            }
            else
            {
                throw new InvalidOperationException("The head and tail should not be touching or overlapping for this.");
            }
        }

        

        private bool HeadIsDirectlyAbove()
        {
            return knottedRope.Head.Position.X == knottedRope.Tail.Position.X 
                && knottedRope.Head.Position.Y > knottedRope.Tail.Position.Y;
        }

        private bool HeadIsDirectlyBelow()
        {
            return knottedRope.Head.Position.X == knottedRope.Tail.Position.X 
                && knottedRope.Head.Position.Y < knottedRope.Tail.Position.Y;
        }

        private bool HeadIsDirectlyToTheLeft()
        {
            return knottedRope.Head.Position.X < knottedRope.Tail.Position.X 
                && knottedRope.Head.Position.Y == knottedRope.Tail.Position.Y;
        }

        private bool HeadIsDirectlyToTheRight()
        {
            return knottedRope.Head.Position.X > knottedRope.Tail.Position.X 
                && knottedRope.Head.Position.Y == knottedRope.Tail.Position.Y;
        }

        private bool HeadIsAboveAndToTheRight()
        {
            return knottedRope.Head.Position.X > knottedRope.Tail.Position.X 
                && knottedRope.Head.Position.Y > knottedRope.Tail.Position.Y;
        }

        private bool HeadIsAboveAndToTheLeft()
        {
            return knottedRope.Head.Position.X < knottedRope.Tail.Position.X 
                && knottedRope.Head.Position.Y > knottedRope.Tail.Position.Y;
        }

        private bool HeadIsBelowAndToTheRight()
        {
            return knottedRope.Head.Position.X > knottedRope.Tail.Position.X 
                && knottedRope.Head.Position.Y < knottedRope.Tail.Position.Y;
        }

        private bool HeadIsBelowAndToTheLeft()
        {
            return knottedRope.Head.Position.X < knottedRope.Tail.Position.X 
                && knottedRope.Head.Position.Y < knottedRope.Tail.Position.Y;
        }

        private bool IsNotTouching() => !IsTouching();

        private bool IsTouching()
        {
            return IsOverlapping()
                || IsTouchingHorizontallyOrVertically()
                || IsTouchingDiagonally();
        }
        private bool IsOverlapping()
        {
            return knottedRope.Head.Position.X == knottedRope.Tail.Position.X
                && knottedRope.Head.Position.Y == knottedRope.Tail.Position.Y;
        }

        private bool IsTouchingHorizontallyOrVertically()
        {
            // EITHER the X OR Y coordinate differs by one
            return (IsVerticallyAligned() && HorizontalDistanceIs(1))
                || (IsHorizontallyAligned() && VerticalDistanceIs(1));
        }

        private bool HorizontalDistanceIs(int n) 
        {
            return Math.Abs(knottedRope.Head.Position.X - knottedRope.Tail.Position.X) == n;
        }

        private bool VerticalDistanceIs(int n)
        {
            return Math.Abs(knottedRope.Head.Position.Y - knottedRope.Tail.Position.Y) == n;
        }

        private bool IsHorizontallyAligned()
        {
            return knottedRope.Head.Position.X == knottedRope.Tail.Position.X;
        }

        private bool IsVerticallyAligned()
        {
            return knottedRope.Head.Position.Y == knottedRope.Tail.Position.Y;
        }

        private bool IsTouchingDiagonally()
        {
            // Both X and Y coordinates differ by one
            return Math.Abs(knottedRope.Head.Position.X - knottedRope.Tail.Position.X) == 1
                && Math.Abs(knottedRope.Head.Position.Y - knottedRope.Tail.Position.Y) == 1;
        }

        private IEnumerable<Instruction> GetInstructionsFromFile(string path)
        {
            return File.ReadAllLines(path)
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

        internal enum Modes
        {
            PartOne,
            PartTwo,
        }
    }
}
