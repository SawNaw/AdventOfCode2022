using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08.Trees
{
    internal class Tree
    {
        public int Height { get; }
        public Tree(int height)
        {
            if (height >= 0 || height <= 9)
            {
                this.Height = height;
            }

            throw new ArgumentException($"Height must be between 0 and 9 inclusive.", nameof(height));
        }
    }
}
