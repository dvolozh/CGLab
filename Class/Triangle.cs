using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGLab.Class
{
    public class Triangle : IObject
    {
        public Vector a;
        public Vector b;
        public Vector c;

        public Triangle(Point a, Point b, Point c)
        {
            this.a = Point.ToVector(a);
            this.b = Point.ToVector(b);
            this.c = Point.ToVector(c);
        }

        public double Intersection(Ray r)
        {
            Vector ab = this.b - this.a;
            Vector ac = this.c - this.a;
            Vector normal = Vector.CrossProd(r.direction, ac);
            var det = Vector.DotProd(ab, normal);
            if (Math.Abs(det) < 0.0001f)
            {
                return double.NaN;
            }

            var invDet = 1 / det;
            Vector v0 = Point.ToVector(r.origin) - this.a;
            double u = Vector.DotProd(v0, normal) * invDet;
            if (u < 0 || u > 1)
            {
                return double.NaN;
            }

            Vector v1 = Vector.CrossProd(v0, ab);
            double v = Vector.DotProd(r.direction, v1) * invDet;
            if (v < 0 || (u + v) > 1)
            {
                return double.NaN;
            }

            double t = Vector.DotProd(ac, v1) * invDet;
            if (t > 0.0001f)
            {
                return t;
            }
            else
            {
                return double.NaN;
            }
        }

        public Vector GetNormal(Point p)
        {
            Vector ab = this.b - this.a;
            Vector ac = this.c - this.a;
            Vector vec = Vector.CrossProd(ab, ac);
            return Vector.Normalize(vec);
        }
    }
}
