using Day09.RopeMotionSimulator.RopeComponents;

namespace Day09.RopeMotionSimulator
{
    internal class MotionSimulator
    {
        private IEnumerable<Instruction> instructions;
        private HashSet<Coordinate> visitedCoordinates = new();
        internal Rope Rope = new();
        internal MotionSimulator(string instructionFilePath)
        {
            instructions = GetInstructionsFromFile(instructionFilePath);
            visitedCoordinates.Add(new Coordinate(0, 0));
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
            for (int i = 1; i <= instruction.Steps; i++)
            {
                MoveHead(instruction);

                if (IsNotTouching())
                {
                    MoveTail();
                }

                if (!visitedCoordinates.Contains(Rope.Tail.Position))
                {
                    visitedCoordinates.Add(Rope.Tail.Position);
                }
            }
        }

        private void MoveHead(Instruction instruction)
        {
            switch (instruction.Direction)
            {
                case (Direction.Up):
                    Rope.Head.MoveUp();
                    break;

                case (Direction.Down):
                    Rope.Head.MoveDown();
                    break;

                case (Direction.Left):
                    Rope.Head.MoveLeft();
                    break;

                case (Direction.Right):
                    Rope.Head.MoveRight();
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
                Rope.Tail.MoveUp();
            }
            else if (HeadIsDirectlyBelow())
            {
                Rope.Tail.MoveDown();
            }
            else if (HeadIsDirectlyToTheLeft())
            {
                Rope.Tail.MoveLeft();
            }
            else if (HeadIsDirectlyToTheRight())
            {
                Rope.Tail.MoveRight();
            }
            else if (HeadIsAboveAndToTheRight())
            {
                Rope.Tail.MoveDiagonallyUpAndRight();
            }
            else if (HeadIsAboveAndToTheLeft())
            {
                Rope.Tail.MoveDiagonallyUpLeft();
            }
            else if (HeadIsBelowAndToTheRight())
            {
                Rope.Tail.MoveDiagonallyDownRight();
            }
            else if (HeadIsBelowAndToTheLeft())
            {
                Rope.Tail.MoveDiagonallyDownLeft();
            }
            else
            {
                throw new InvalidOperationException("The head and tail should not be touching or overlapping for this.");
            }
        }

        

        private bool HeadIsDirectlyAbove()
        {
            return Rope.Head.Position.X == Rope.Tail.Position.X 
                && Rope.Head.Position.Y > Rope.Tail.Position.Y;
        }

        private bool HeadIsDirectlyBelow()
        {
            return Rope.Head.Position.X == Rope.Tail.Position.X 
                && Rope.Head.Position.Y < Rope.Tail.Position.Y;
        }

        private bool HeadIsDirectlyToTheLeft()
        {
            return Rope.Head.Position.X < Rope.Tail.Position.X 
                && Rope.Head.Position.Y == Rope.Tail.Position.Y;
        }

        private bool HeadIsDirectlyToTheRight()
        {
            return Rope.Head.Position.X > Rope.Tail.Position.X 
                && Rope.Head.Position.Y == Rope.Tail.Position.Y;
        }

        private bool HeadIsAboveAndToTheRight()
        {
            return Rope.Head.Position.X > Rope.Tail.Position.X 
                && Rope.Head.Position.Y > Rope.Tail.Position.Y;
        }

        private bool HeadIsAboveAndToTheLeft()
        {
            return Rope.Head.Position.X < Rope.Tail.Position.X 
                && Rope.Head.Position.Y > Rope.Tail.Position.Y;
        }

        private bool HeadIsBelowAndToTheRight()
        {
            return Rope.Head.Position.X > Rope.Tail.Position.X 
                && Rope.Head.Position.Y < Rope.Tail.Position.Y;
        }

        private bool HeadIsBelowAndToTheLeft()
        {
            return Rope.Head.Position.X < Rope.Tail.Position.X 
                && Rope.Head.Position.Y < Rope.Tail.Position.Y;
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
            return Rope.Head.Position.X == Rope.Tail.Position.X
                && Rope.Head.Position.Y == Rope.Tail.Position.Y;
        }

        private bool IsTouchingHorizontallyOrVertically()
        {
            // EITHER the X OR Y coordinate differs by one
            return (IsVerticallyAligned() && HorizontalDistanceIs(1))
                || (IsHorizontallyAligned() && VerticalDistanceIs(1));
        }

        private bool HorizontalDistanceIs(int n) 
        {
            return Math.Abs(Rope.Head.Position.X - Rope.Tail.Position.X) == n;
        }

        private bool VerticalDistanceIs(int n)
        {
            return Math.Abs(Rope.Head.Position.Y - Rope.Tail.Position.Y) == n;
        }

        private bool IsHorizontallyAligned()
        {
            return Rope.Head.Position.X == Rope.Tail.Position.X;
        }

        private bool IsVerticallyAligned()
        {
            return Rope.Head.Position.Y == Rope.Tail.Position.Y;
        }

        private bool IsTouchingDiagonally()
        {
            // Both X and Y coordinates differ by one
            return Math.Abs(Rope.Head.Position.X - Rope.Tail.Position.X) == 1
                && Math.Abs(Rope.Head.Position.Y - Rope.Tail.Position.Y) == 1;
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
    }
}
