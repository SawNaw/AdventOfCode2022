using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01.Core
{
    public struct CalorieAndPosition
    {
        public int HighestCalorie;
        public int Position;

        public CalorieAndPosition(int highestCalorie, int position)
        {
            this.HighestCalorie = highestCalorie;
            this.Position = position;    
        }
    }
}
