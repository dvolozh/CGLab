using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGLab.Class
{
    public class Plane : IObject
    {
        public Vector normal;
        public Point center;

        public Plane(Vector normal, Point center)
        {
            this.normal = normal;
            this.center = center;
        }

        public double Intersection(Ray r)
        {
            double denom = Vector.DotProd(r.direction, normal);
            if (Math.Abs(denom) <= 0.0001f)
            {
                return double.NaN;
            }
            double t = Vector.DotProd(Point.ToVector(center - r.origin), normal) / denom;
            if (t > 0)
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
            return this.normal;
        }
    }
}
