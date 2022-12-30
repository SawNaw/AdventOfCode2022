using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Forestry
{
    /// <summary>
    /// Represents a two-dimensional rectangle of <see cref="Tree"/> objects.
    /// </summary>
    internal class Forest
    {
        private int _highestScenicScore = 0;
        private readonly List<List<Tree>> _trees = new();
        private readonly List<Coordinate> _visibleTrees = new();
        public double XMax { get; } // X-coordinate of all trees on the right edge
        public double YMax { get; } // Y-coordinate of all trees on the bottom edge

        public Forest(string path)
        {
            var fileContents = File.ReadAllLines(path); // Each array element represents a horizontal row of trees
            XMax = fileContents.First().Length - 1; // Doesn't have to be First(), since all rows are the same length. But we have to pick one.
            YMax = fileContents.Length - 1;

            CreateForestOfTrees(fileContents);
        }

        public int GetNumberOfVisibleTrees()
        {
            for (int i = 0; i <= YMax; i++)
            {
                for (int j = 0; j <= XMax; j++)
                {
                    if (IsVisibleFromAnyDirection(j, i))
                    {
                        _visibleTrees.Add(new Coordinate(j, i));
                    }
                }
            }

            return _visibleTrees.Count;
        }

        public Tree TreeAt(int x, int y)
        {
            return _trees[y][x];
        }

        public bool IsVisibleFromAnyDirection(int x, int y)
        {
            return IsVisible(x, y, FromDirection.Top)
                || IsVisible(x, y, FromDirection.Bottom)
                || IsVisible(x, y, FromDirection.Left)
                || IsVisible(x, y, FromDirection.Right);
        }

        public bool IsVisibleFromTop(int x, int y)
        {
            return IsVisible(x, y, FromDirection.Top);
        }

        public bool IsVisibleFromBottom(int x, int y)
        {
            return IsVisible(x, y, FromDirection.Bottom);
        }

        public bool IsVisibleFromRight(int x, int y)
        {
            return IsVisible(x, y, FromDirection.Right);
        }

        public bool IsVisibleFromLeft(int x, int y)
        {
            return IsVisible(x, y, FromDirection.Left);
        }
        private void CreateForestOfTrees(string[] fileContents)
        {
            foreach (var line in fileContents)
            {
                var rowOfTrees = line.Select(l => new Tree(Char.GetNumericValue(l)))
                                     .ToList();

                _trees.Add(rowOfTrees);
            }
        }

        private bool IsVisible(int x, int y, FromDirection direction)
        {
            if (IsOnEdge(x, y))
            {
                return true;
            }

            switch (direction)
            {
                case FromDirection.Left:
                    for (int i = x - 1; i >= 0; i--)
                    {
                        if (TreeAt(i, y).Height >= TreeAt(x, y).Height)
                        {
                            return false;
                        }
                    }
                    break;
                case FromDirection.Right:
                    for (int i = x + 1; i <= XMax; i++)
                    {
                        if (TreeAt(i, y).Height >= TreeAt(x, y).Height)
                        {
                            return false;
                        }
                    }
                    break;
                case FromDirection.Top:
                    for (int i = y - 1; i >= 0; i--)
                    {
                        if (TreeAt(x, i).Height >= TreeAt(x, y).Height)
                        {
                            return false;
                        }
                    }
                    break;
                case FromDirection.Bottom:
                    for (int i = y + 1; i <= YMax; i++)
                    {
                        if (TreeAt(x, i).Height >= TreeAt(x, y).Height)
                        {
                            return false;
                        }
                    }
                    break;
            }

            return true;
        }

        
        public int FindHighestScenicScore()
        {
            var calculator = new ScenicScore(this);

            for (int i = 0; i <= XMax; i++)
            {
                for (int j = 0; j <= YMax; j++) 
                {
                    int total = calculator.CalculateScenicScore(i, j);
                    if (total > _highestScenicScore)
                    {
                        _highestScenicScore = total;
                    }
                }
            }

            return _highestScenicScore;
        }

        private bool IsOnEdge(int x, int y)
        {
            return x == 0
                || y == 0
                || x == XMax
                || y == YMax;
        }

        private enum FromDirection
        {
            Left, Right, Top, Bottom
        }
    }
}
