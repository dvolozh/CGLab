using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGLab.Class
{
    public interface IObject
    {
        double Intersection(Ray r);
        Vector GetNormal(Point p);
    }
}
