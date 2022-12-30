using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09.RopeMotionSimulator.RopeComponents
{
    internal class KnottedRope
    {
        public List<Knot> Knots { get; } = new();
        public Knot TrueHead => Knots.First();
        public Knot TrueTail => Knots.Last();
        public Knot TemporaryHead { get; set; }
        public Knot TemporaryTail { get; set; }
        public KnottedRope(int numberOfKnots)
        {
            for (int i = 1; i <= numberOfKnots; i++) 
            { 
                Knots.Add(new Knot());
            }

            TemporaryHead = Knots.First();
            TemporaryTail = Knots.Last();
        }
    }
}
