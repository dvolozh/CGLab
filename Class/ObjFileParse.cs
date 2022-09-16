using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGLab.Class
{
    public class ObjFileParse
    {
        public static List<IObject> ParseObjFile(string filename)
        {
            StreamReader reader = File.OpenText(filename);
            List<Point> points = new List<Point>();
            List<Vector> normals = new List<Vector>();
            List<IObject> objects = new List<IObject>();
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                if (line == "")
                {
                    continue;
                }
                string[] items = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (items[0] == "v")
                {
                    var x = double.Parse(items[1]);
                    var y = double.Parse(items[2]);
                    var z = double.Parse(items[3]);
                    points.Add(new Point(x, y, z));
                }
                else if (items[0] == "vn")
                {
                    var x = double.Parse(items[1]);
                    var y = double.Parse(items[2]);
                    var z = double.Parse(items[3]);
                    normals.Add(new Vector(x, y, z));
                }
                else if (items[0] == "f")
                {
                    int[] point = new int[3];
                    int[] vector = new int[3];
                    for (int i = 1; i < items.Length; i++)
                    {
                        string[] coords = items[i].Split('/');
                        point[i - 1] = int.Parse(coords[0]);
                    }

                    Point x = new Point(points[point[0] - 1].x, points[point[0] - 1].y, points[point[0] - 1].z);
                    Point y = new Point(points[point[1] - 1].x, points[point[1] - 1].y, points[point[1] - 1].z);
                    Point z = new Point(points[point[2] - 1].x, points[point[2] - 1].y, points[point[2] - 1].z);

                    objects.Add(new Triangle(x, y, z));
                }
            }

            return objects;
        }
    }
}
