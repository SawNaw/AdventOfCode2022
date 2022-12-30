using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day09.RopeMotionSimulator
{
    internal struct Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Coordinate PushUp()
        {
            Y++;
            return this;
        }
        public Coordinate PushDown()
        {
            Y--;
            return this;
        }
        public Coordinate PushLeft()
        {
            X--;
            return this;
        }
        public Coordinate PushRight()
        {
            X++;
            return this;
        }
    }
}
