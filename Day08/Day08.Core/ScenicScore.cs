using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Core
{
    internal class ScenicScore
    {
        private readonly Forest _forest;

        public ScenicScore(Forest forest)
        {
            _forest = forest;
        }

        private int GetUpViewingDistance(int x, int y)
        {
            if (y == 0) return 0; // no trees above

            int viewingDistance = 0;
            for (int nextY = y - 1; nextY >= 0; nextY--) // keep looking up
            {
                viewingDistance++;
                if (_forest.TreeAt(x, nextY).Height >= _forest.TreeAt(x, y).Height)
                {
                    break;
                }
            }
            return viewingDistance;
        }

        private int GetDownViewingDistance(int x, int y)
        {
            if (y == _forest.YMax) return 0; // no trees below

            int viewingDistance = 0;
            for (int nextY = y + 1; nextY <= _forest.YMax; nextY++) // keep looking down
            {
                viewingDistance++;
                if (_forest.TreeAt(x, nextY).Height >= _forest.TreeAt(x, y).Height)
                {
                    break;
                }
            }
            return viewingDistance;
        }

        private int GetLeftViewingDistance(int x, int y)
        {
            if (x == 0) return 0; // no trees to the left

            int viewingDistance = 0;
            for (int nextX = x - 1; nextX >= 0; nextX--) // keep looking left
            {
                viewingDistance++;
                if (_forest.TreeAt(nextX, y).Height >= _forest.TreeAt(x, y).Height)
                {
                    break;
                }
            }
            return viewingDistance;
        }

        private int GetRightViewingDistance(int x, int y)
        {
            if (x == _forest.XMax) return 0; // no trees to the right

            int viewingDistance = 0;
            for (int nextX = x + 1; nextX <= _forest.XMax; nextX++) // keep looking right
            {
                viewingDistance++;
                if (_forest.TreeAt(nextX, y).Height >= _forest.TreeAt(x, y).Height)
                {
                    break;
                }
            }
            return viewingDistance;
        }

        /// <summary>
        /// Calculates the scenic score for a tree in the forest.
        /// </summary>
        /// <param name="x">The X coordinate of the tree.</param>
        /// <param name="y">The Y coordinate of the tree.</param>
        /// <returns>The scenic score of the tree at the given coordinates.</returns>
        public int CalculateScenicScore(int x, int y)
        {
            return GetDownViewingDistance(x, y)
                     * GetLeftViewingDistance(x, y)
                     * GetUpViewingDistance(x, y)
                     * GetRightViewingDistance(x, y);
        }

    }
}
