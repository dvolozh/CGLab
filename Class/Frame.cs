using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGLab.Class
{
    public class Frame
    {
        public Point origin;
        public double width, height;

        public Frame (Point origin, double width, double height)
        {
            this.origin = origin;
            this.width = width;
            this.height = height;
        }

        public Point PixelPoint (double x, double y, double image_width, double image_height)
        {
            var x_fct = this.width / image_width;
            var y_fct = this.height / image_height;

            var x_offs = x * x_fct;
            var y_offs = y * y_fct;

            var new_x = this.origin.x - this.width / 2 + x_offs;
            var new_y = this.origin.y - this.height / 2 + y_offs;

            return new Point(new_x, new_y, this.origin.z);
        }
    }
}
