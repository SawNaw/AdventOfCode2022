using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Trees
{
    /// <summary>
    /// Represents a 2x2 rectangle of <see cref="Tree"/> objects.
    /// </summary>
    internal class Forest
    {
        private readonly double _xMax;
        private readonly double _yMax;
        private readonly List<List<Tree>> _trees = new();
        private readonly List<Coordinate> _visibleTrees = new();

        public Forest(string path)
        {
            var fileContents = File.ReadAllLines(path);

            _xMax = fileContents.First().Length - 1;
            _yMax = fileContents.Length - 1;

            CreateForestOfTrees(fileContents);
        }

        public int GetNumberOfVisibleTrees()
        {
            for (int i = 0; i <= _yMax; i++) 
            { 
                for (int j = 0; j <= _xMax; j++) 
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
                    for (int i = x + 1; i <= _xMax; i++)
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
                    for (int i = y + 1; i <= _yMax; i++)
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

        private bool IsOnEdge(int x, int y)
        {
            return x == 0
                || y == 0
                || x == _xMax
                || y == _yMax;
        }

        private enum FromDirection
        {
            Left, Right, Top, Bottom
        }
    }
}
