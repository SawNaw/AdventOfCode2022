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

        private void ExecuteSingleInstruction(Instruction instruction)
        {
            for (int j = 1; j < knottedRope.Knots.Count; j++)
            {
                knottedRope.TemporaryTail = knottedRope.Knots.ElementAt(j);
                knottedRope.TemporaryHead = knottedRope.Knots.ElementAt(j - 1);

                for (int i = 1; i <= instruction.Steps; i++)
                {
                    MoveHead(instruction);

                    if (IsNotTouching())
                    {
                        MoveTail();
                    }

                    if (!visitedCoordinates.Contains(knottedRope.TrueTail.Position))
                    {
                        visitedCoordinates.Add(knottedRope.TrueTail.Position);
                    }
                }

            }
        }

        private void MoveHead(Instruction instruction)
        {
            switch (instruction.Direction)
            {
                case (Direction.Up):
                    knottedRope.TemporaryHead.MoveUp();
                    break;

                case (Direction.Down):
                    knottedRope.TemporaryHead.MoveDown();
                    break;

                case (Direction.Left):
                    knottedRope.TemporaryHead.MoveLeft();
                    break;

                case (Direction.Right):
                    knottedRope.TemporaryHead.MoveRight();
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
                knottedRope.TemporaryTail.MoveUp();
            }
            else if (HeadIsDirectlyBelow())
            {
                knottedRope.TemporaryTail.MoveDown();
            }
            else if (HeadIsDirectlyToTheLeft())
            {
                knottedRope.TemporaryTail.MoveLeft();
            }
            else if (HeadIsDirectlyToTheRight())
            {
                knottedRope.TemporaryTail.MoveRight();
            }
            else if (HeadIsAboveAndToTheRight())
            {
                knottedRope.TemporaryTail.MoveDiagonallyUpAndRight();
            }
            else if (HeadIsAboveAndToTheLeft())
            {
                knottedRope.TemporaryTail.MoveDiagonallyUpLeft();
            }
            else if (HeadIsBelowAndToTheRight())
            {
                knottedRope.TemporaryTail.MoveDiagonallyDownRight();
            }
            else if (HeadIsBelowAndToTheLeft())
            {
                knottedRope.TemporaryTail.MoveDiagonallyDownLeft();
            }
            else
            {
                throw new InvalidOperationException("The head and tail should not be touching or overlapping for this.");
            }
        }

        

        private bool HeadIsDirectlyAbove()
        {
            return knottedRope.TemporaryHead.Position.X == knottedRope.TemporaryTail.Position.X 
                && knottedRope.TemporaryHead.Position.Y > knottedRope.TemporaryTail.Position.Y;
        }

        private bool HeadIsDirectlyBelow()
        {
            return knottedRope.TemporaryHead.Position.X == knottedRope.TemporaryTail.Position.X 
                && knottedRope.TemporaryHead.Position.Y < knottedRope.TemporaryTail.Position.Y;
        }

        private bool HeadIsDirectlyToTheLeft()
        {
            return knottedRope.TemporaryHead.Position.X < knottedRope.TemporaryTail.Position.X 
                && knottedRope.TemporaryHead.Position.Y == knottedRope.TemporaryTail.Position.Y;
        }

        private bool HeadIsDirectlyToTheRight()
        {
            return knottedRope.TemporaryHead.Position.X > knottedRope.TemporaryTail.Position.X 
                && knottedRope.TemporaryHead.Position.Y == knottedRope.TemporaryTail.Position.Y;
        }

        private bool HeadIsAboveAndToTheRight()
        {
            return knottedRope.TemporaryHead.Position.X > knottedRope.TemporaryTail.Position.X 
                && knottedRope.TemporaryHead.Position.Y > knottedRope.TemporaryTail.Position.Y;
        }

        private bool HeadIsAboveAndToTheLeft()
        {
            return knottedRope.TemporaryHead.Position.X < knottedRope.TemporaryTail.Position.X 
                && knottedRope.TemporaryHead.Position.Y > knottedRope.TemporaryTail.Position.Y;
        }

        private bool HeadIsBelowAndToTheRight()
        {
            return knottedRope.TemporaryHead.Position.X > knottedRope.TemporaryTail.Position.X 
                && knottedRope.TemporaryHead.Position.Y < knottedRope.TemporaryTail.Position.Y;
        }

        private bool HeadIsBelowAndToTheLeft()
        {
            return knottedRope.TemporaryHead.Position.X < knottedRope.TemporaryTail.Position.X 
                && knottedRope.TemporaryHead.Position.Y < knottedRope.TemporaryTail.Position.Y;
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
            return knottedRope.TemporaryHead.Position.X == knottedRope.TemporaryTail.Position.X
                && knottedRope.TemporaryHead.Position.Y == knottedRope.TemporaryTail.Position.Y;
        }

        private bool IsTouchingHorizontallyOrVertically()
        {
            // EITHER the X OR Y coordinate differs by one
            return (IsVerticallyAligned() && HorizontalDistanceIs(1))
                || (IsHorizontallyAligned() && VerticalDistanceIs(1));
        }

        private bool HorizontalDistanceIs(int n) 
        {
            return Math.Abs(knottedRope.TemporaryHead.Position.X - knottedRope.TemporaryTail.Position.X) == n;
        }

        private bool VerticalDistanceIs(int n)
        {
            return Math.Abs(knottedRope.TemporaryHead.Position.Y - knottedRope.TemporaryTail.Position.Y) == n;
        }

        private bool IsHorizontallyAligned()
        {
            return knottedRope.TemporaryHead.Position.X == knottedRope.TemporaryTail.Position.X;
        }

        private bool IsVerticallyAligned()
        {
            return knottedRope.TemporaryHead.Position.Y == knottedRope.TemporaryTail.Position.Y;
        }

        private bool IsTouchingDiagonally()
        {
            // Both X and Y coordinates differ by one
            return Math.Abs(knottedRope.TemporaryHead.Position.X - knottedRope.TemporaryTail.Position.X) == 1
                && Math.Abs(knottedRope.TemporaryHead.Position.Y - knottedRope.TemporaryTail.Position.Y) == 1;
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
