using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09.RopeMotionSimulator
{
    /// <summary>
    /// Provides methods to determine the relative positions of two Knots.
    /// </summary>
    internal static class Position
    {
        internal static bool FrontKnotIsDirectlyAbove(Knot frontKnot, Knot backKnot)
        {
            return frontKnot.Position.X == backKnot.Position.X
                && frontKnot.Position.Y > backKnot.Position.Y;
        }

        internal static bool FrontKnotIsDirectlyBelow(Knot frontKnot, Knot backKnot)
        {
            return frontKnot.Position.X == backKnot.Position.X
                && frontKnot.Position.Y < backKnot.Position.Y;
        }

        internal static bool FrontKnotIsDirectlyToTheLeft(Knot frontKnot, Knot backKnot)
        {
            return frontKnot.Position.X < backKnot.Position.X
                && frontKnot.Position.Y == backKnot.Position.Y;
        }

        internal static bool FrontKnotIsDirectlyToTheRight(Knot frontKnot, Knot backKnot)
        {
            return frontKnot.Position.X > backKnot.Position.X
                && frontKnot.Position.Y == backKnot.Position.Y;
        }

        internal static bool FrontKnotIsAboveAndToTheRight(Knot frontKnot, Knot backKnot)
        {
            return frontKnot.Position.X > backKnot.Position.X
                && frontKnot.Position.Y > backKnot.Position.Y;
        }

        internal static bool FrontKnotIsAboveAndToTheLeft(Knot frontKnot, Knot backKnot)
        {
            return frontKnot.Position.X < backKnot.Position.X
                && frontKnot.Position.Y > backKnot.Position.Y;
        }

        internal static bool FrontKnotIsBelowAndToTheRight(Knot frontKnot, Knot backKnot)
        {
            return frontKnot.Position.X > backKnot.Position.X
                && frontKnot.Position.Y < backKnot.Position.Y;
        }

        internal static bool FrontKnotIsBelowAndToTheLeft(Knot frontKnot, Knot backKnot)
        {
            return frontKnot.Position.X < backKnot.Position.X
                && frontKnot.Position.Y < backKnot.Position.Y;
        }

        internal static bool IsNotTouching(Knot frontKnot, Knot backKnot) => !IsTouching(frontKnot, backKnot);

        internal static bool IsTouching(Knot frontKnot, Knot backKnot)
        {
            return IsOverlapping(frontKnot, backKnot)
                || IsTouchingHorizontallyOrVertically(frontKnot, backKnot)
                || IsTouchingDiagonally(frontKnot, backKnot);
        }
        internal static bool IsOverlapping(Knot frontKnot, Knot backKnot)
        {
            return frontKnot.Position.X == backKnot.Position.X
                && frontKnot.Position.Y == backKnot.Position.Y;
        }

        internal static bool IsTouchingHorizontallyOrVertically(Knot frontKnot, Knot backKnot)
        {
            // EITHER the X OR Y coordinate differs by one
            return (IsVerticallyAligned(frontKnot, backKnot) && HorizontalDistanceIs(frontKnot, backKnot, 1))
                || (IsHorizontallyAligned(frontKnot, backKnot) && VerticalDistanceIs(frontKnot, backKnot, 1));
        }

        internal static bool HorizontalDistanceIs(Knot frontKnot, Knot backKnot, int n)
        {
            return Math.Abs(frontKnot.Position.X - backKnot.Position.X) == n;
        }

        internal static bool VerticalDistanceIs(Knot frontKnot, Knot backKnot, int n)
        {
            return Math.Abs(frontKnot.Position.Y - backKnot.Position.Y) == n;
        }

        internal static bool IsHorizontallyAligned(Knot frontKnot, Knot backKnot)
        {
            return frontKnot.Position.X == backKnot.Position.X;
        }

        internal static bool IsVerticallyAligned(Knot frontKnot, Knot backKnot)
        {
            return frontKnot.Position.Y == backKnot.Position.Y;
        }

        internal static bool IsTouchingDiagonally(Knot frontKnot, Knot backKnot)
        {
            // Both X and Y coordinates differ by one
            return Math.Abs(frontKnot.Position.X - backKnot.Position.X) == 1
                && Math.Abs(frontKnot.Position.Y - backKnot.Position.Y) == 1;
        }
    }
}
