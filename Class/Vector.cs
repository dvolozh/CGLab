using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGLab.Class
{
    public class Vector
    {
        public double x, y, z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static double operator *(Vector a, Vector b)
        {
            return (a.x * b.x + a.y * b.y + a.z * b.z);
        }

        public static Vector operator *(Vector a, double num)
        {
            return new Vector(a.x * num, a.y * num, a.z * num);
        }

        public static Point ToPoint(Vector a)
        {
            return new Point(a.x, a.y, a.z);
        }

        public static double DotProd (Vector a, Vector b)
        {
            return (a.x * b.x + a.y * b.y + a.z * b.z);
        }

        public static Vector CrossProd (Vector a, Vector b)
        {
            return new Vector(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        }

        public static double Magnitude (Vector a)
        {
            return Math.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
        }

        public static Vector Normalize (Vector a)
        {
            var m = Magnitude(a);
            if (m > 0)
            {
                return new Vector(a.x / m, a.y / m, a.z / m);
            }
            else
            {
                return new Vector(0, 0, 0);
            }
        }
    }
}
