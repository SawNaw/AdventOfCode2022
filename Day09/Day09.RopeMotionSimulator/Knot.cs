namespace Day09.RopeMotionSimulator
{
    /// <summary>
    /// Represents a knot at a specific location in a two-dimensional plane. 
    /// Provides methods to move itself in any direction and detect its position relative to another knot.
    /// </summary>
    internal class Knot
    {
        public int X { get; private set; } = 0;
        public int Y { get; private set; } = 0;
        public Knot()
        {
        }

        public Coordinate MoveLeft()
        {
            X--;
            return new Coordinate(X, Y);
        }

        public Coordinate MoveRight()
        {
            X++;
            return new Coordinate(X, Y);
        }

        public Coordinate MoveUp()
        {
            Y++;
            return new Coordinate(X, Y);
        }

        public Coordinate MoveDown()
        {
            Y--;
            return new Coordinate(X, Y);
        }
        public Coordinate MoveDiagonallyDownLeft()
        {
            MoveDown();
            MoveLeft();
            return new Coordinate(X, Y);
        }

        public Coordinate MoveDiagonallyDownRight()
        {
            MoveDown();
            MoveRight();
            return new Coordinate(X, Y);
        }

        public Coordinate MoveDiagonallyUpLeft()
        {
            MoveUp();
            MoveLeft();
            return new Coordinate(X, Y);
        }

        public Coordinate MoveDiagonallyUpAndRight()
        {
            MoveUp();
            MoveRight();
            return new Coordinate(X, Y);
        }

        internal bool IsDirectlyAbove(Knot other)
        {
            return this.X == other.X
                && this.Y > other.Y;
        }

        internal bool IsDirectlyBelow(Knot other)
        {
            return this.X == other.X
                && this.Y < other.Y;
        }

        internal bool IsDirectlyToTheLeftOf(Knot other)
        {
            return this.X < other.X
                && this.Y == other.Y;
        }

        internal bool IsDirectlyToTheRightOf(Knot other)
        {
            return this.X > other.X
                && this.Y == other.Y;
        }

        internal bool IsAboveAndToTheRightOf(Knot other)
        {
            return this.X > other.X
                && this.Y > other.Y;
        }

        internal bool IsAboveAndToTheLeftOf(Knot other)
        {
            return this.X < other.X
                && this.Y > other.Y;
        }

        internal bool IsBelowAndToTheRightOf(Knot other)
        {
            return this.X > other.X
                && this.Y < other.Y;
        }

        internal bool IsBelowAndToTheLeftOf(Knot other)
        {
            return this.X < other.X
                && this.Y < other.Y;
        }

        internal bool IsNotTouching(Knot other) => !IsTouching(other);

        internal bool IsTouching(Knot other)
        {
            return IsOverlapping(other)
                || IsTouchingHorizontallyOrVertically(other)
                || IsTouchingDiagonally(other);
        }

        internal bool IsOverlapping(Knot other)
        {
            return this.X == other.X
                && this.Y == other.Y;
        }

        internal bool IsTouchingHorizontallyOrVertically(Knot other)
        {
            // EITHER the X OR Y coordinate differs by one
            return (IsVerticallyAlignedWith(other) && HorizontalDistanceIsOne(other))
                || (IsHorizontallyAlignedWith(other) && VerticalDistanceIsOne(other));
        }
        internal bool IsTouchingDiagonally(Knot other)
        {
            // Both X and Y coordinates differ by one
            return Math.Abs(this.X - other.X) == 1
                && Math.Abs(this.Y - other.Y) == 1;
        }

        internal bool HorizontalDistanceIsOne(Knot other)
        {
            return Math.Abs(this.X - other.X) == 1;
        }

        internal bool VerticalDistanceIsOne(Knot other)
        {
            return Math.Abs(this.Y - other.Y) == 1;
        }

        internal bool IsHorizontallyAlignedWith(Knot other)
        {
            return this.X == other.X;
        }

        internal bool IsVerticallyAlignedWith(Knot other)
        {
            return this.Y == other.Y;
        }

    }
}
