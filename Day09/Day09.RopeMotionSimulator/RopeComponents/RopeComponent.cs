using Day09.RopeMotionSimulator.RopeComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09.RopeMotionSimulator.RopeComponents
{
    internal abstract class RopeComponent
    {
        public Coordinate Position;
        public RopeComponent()
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
