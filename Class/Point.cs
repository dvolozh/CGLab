using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGLab.Class
{
    public class Point
    {
        public double x, y, z;

        public Point (double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Point operator +(Point a, Vector b)
        {
            return new Point(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector ToVector (Point a)
        {
            return new Vector(a.x, a.y, a.z);
        }
    }
}
