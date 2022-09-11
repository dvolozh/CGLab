using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGLab.Class
{
    public class Ray
    {
        public Point origin;
        public Vector direction;

        public Ray (Point origin, Vector direction)
        {
            this.origin = origin;
            this.direction = direction;
        }

        public Point PointAtRay (double t)
        {
            return (origin + direction * t);
        }
    }
}
