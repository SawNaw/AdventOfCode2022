namespace Day09.RopeMotionSimulator
{
    internal class KnottedRope
    {
        public List<Knot> Knots { get; } = new();
        public Knot Head => Knots.First();
        public Knot Tail => Knots.Last();
        public KnottedRope(int numberOfKnots)
        {
            for (int i = 1; i <= numberOfKnots; i++)
            {
                Knots.Add(new Knot());
            }
        }
    }
}
