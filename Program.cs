using CGLab.Class;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace CGLab {

    class Program {
        static void Main(string[] args) {

            int width = 400, height = 400;
            Frame view_frame = new Frame(new Point(0, 0, 400), width, height);
            Camera camera = new Camera(new Point(0, 0, -15), view_frame);
            Light light = new Light(new Vector(0, 0, -1));
            Scene scene = new Scene();

            /*Sphere s1 = new Sphere(new Point(5, 5, 10), 3);
            scene.AddObject(s1);
            Sphere s2 = new Sphere(new Point(10, -10, 35), 2);
            scene.AddObject(s2);*/

            scene.AddLight(light);

            List<IObject> objects = ObjFileParse.ParseObjFile("E:\\D3\\3C\\Graphics\\CGLab\\CGLab\\Class\\cow.obj");
            scene.AddObjects(objects);

            string filename = "E:\\D3\\3C\\Graphics\\CGLab\\CGLab\\Class\\result.ppm";
            StreamWriter writer = new StreamWriter(filename);
            writer.Write("P3\n{0} {1} {2}\n", width, height, 255);
            writer.Flush();

            StringBuilder output = new StringBuilder("");


            double[,] buffer = new double[width, height];

            Stopwatch sw = new Stopwatch();

            sw.Start();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++) {
                    Ray ray = camera.PixelRay(j, height - i, width, height);

                    double minDist = GetNearestObj(ray, scene.objects, out IObject obj);
                    if (obj != null)
                    {
                        var point = ray.PointAtRay(minDist);
                        var normal = obj.GetNormal(point);
                        double li = scene.light.LightIntensity(normal);
                        buffer[i, j] = li;
                    }
                }
            }

             for (int i = 0; i < height; i++)
                {
                for (int j = 0; j < width; j++)
                {
                    var r = Convert.ToInt32(buffer[i, j] * 255);
                    if (buffer[i, j] == 0)
                    {
                        r = 255;
                    }
                    if (r > 255)
                    {
                        r = 255;
                    }
                    if (r < 0)
                    {
                        r = 0;
                    }

                    output.Append(r);
                    output.Append(" ");
                    output.Append(r);
                    output.Append(" ");
                    output.Append(r);
                    output.Append(" ");
                }
                writer.WriteLine(output);
                output.Clear();
            }
            writer.Close();

            sw.Stop();
            Console.WriteLine($"Done! Time passed: {sw.ElapsedMilliseconds} ms");
        }

        public static double GetNearestObj (Ray r, List<IObject> objects, out IObject obj)
        {
            double minDist = Int32.MaxValue;
            obj = null;
            for (int i = 0; i < objects.Count; i++)
            {
                double dist = objects[i].Intersection(r);
                if (dist < minDist) 
                {
                    minDist = dist;
                    obj = objects[i];
                }
            }
            return minDist;
        }
    }
}