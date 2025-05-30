using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    public class PointData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color PointColor { get; set; }

        public PointData(int x, int y, Color color)
        {
            X = x;
            Y = y;
            PointColor = color;
        }
    }
}
