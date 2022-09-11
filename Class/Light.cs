using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGLab.Class
{
    public class Light
    {
        public Vector direction;

        public Light (Vector direction)
        {
            this.direction = direction;
        }

        public double LightIntensity (Vector vec)
        {
            double cos = Vector.DotProd(this.direction, vec);
            if (cos < 0)
            {
                return 0;
            } else {
                return cos;
            }
        }
    }
}
