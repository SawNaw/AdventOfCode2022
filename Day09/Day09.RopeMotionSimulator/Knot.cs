namespace Day09.RopeMotionSimulator
{
    internal class Knot
    {
        public Coordinate Position;
        public Knot()
        {
            Position = new Coordinate(0, 0);
        }
        public void MoveLeft()
        {
            Position.PushLeft();
        }

        public void MoveRight()
        {
            Position.PushRight();
        }

        public void MoveUp()
        {
            Position.PushUp();
        }

        public void MoveDown()
        {
            Position.PushDown();
        }
        public void MoveDiagonallyDownLeft()
        {
            Position.PushDown();
            Position.PushLeft();
        }

        public void MoveDiagonallyDownRight()
        {
            Position.PushDown();
            Position.PushRight();
        }

        public void MoveDiagonallyUpLeft()
        {
            Position.PushUp();
            Position.PushLeft();
        }

        public void MoveDiagonallyUpAndRight()
        {
            Position.PushUp();
            Position.PushRight();
        }
    }
}
