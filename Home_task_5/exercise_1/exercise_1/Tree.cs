using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    internal class Tree
    {
        private double _x;
        private double _y;
        public Tree(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public double X { get => _x; }
        public double Y { get => _y; }

        public override string? ToString()
        {
            return $"Location of a tree ({_x},{_y})";
        }
    }
}
