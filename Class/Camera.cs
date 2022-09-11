using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGLab.Class;

namespace CGLab.Class
{
    public class Camera
    {
        public Point position;
        public Frame view_frame;

        public Camera (Point origin, Frame view_frame)
        {
            this.position = origin;
            this.view_frame = view_frame;
        }

        public Ray PixelRay (double x, double y, double image_width, double image_height)
        {
            var point = view_frame.PixelPoint(x, y, image_width, image_height);
            var direction = (Point.ToVector(point) - Vector.Normalize(Point.ToVector(this.position)));
            return new Ray(this.position, direction);
        }
    }
}
