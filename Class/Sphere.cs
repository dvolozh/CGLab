using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CGLab.Class
{
    public class Sphere : IObject
    {
        public Point center;
        public double radius;

        public Sphere(Point center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }

        //sphere intersection, returns distance
        public double Intersection(Ray r)
        {
            var n = r.origin - this.center;
            var a = Vector.DotProd(r.direction, r.direction);
            var b = 2 * Vector.DotProd(Point.ToVector(n), r.direction);
            var c = Vector.DotProd(Point.ToVector(n), Point.ToVector(n)) - this.radius * this.radius;
            var disc = b * b - 4 * a * c;

            if (disc < 0) return double.NaN;

            var t0 = (-b - Math.Sqrt(disc)) / (2 * a);
            var t1 = (-b + Math.Sqrt(disc)) / (2 * a);

            if (t0 > 0 && t1 > 0)
            {
                if (t0 < t1) { 
                    return t0;
                } else { 
                    return t1;
                }
            }
            else if (t0 > 0) return t0;
            else if (t1 > 0) return t1;
            else return double.NaN;
        }

        public Vector GetNormal(Point p)
        {
            Vector vec = Point.ToVector(p) - Point.ToVector(this.center);
            return Vector.Normalize(vec);
        }
    }
}
