using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09.RopeMotionSimulator.RopeComponents
{
    internal class Rope
    {
        public Head Head { get; set; } = new();
        public Tail Tail { get; set; } = new();
        public Rope()
        {

        }
    }
}
