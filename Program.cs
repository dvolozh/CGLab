using CGLab.Class;

namespace CGLab {

    class Program {
        static void Main(string[] args) {

            double width = 50, height = 50;
            Frame view_frame = new Frame(new Point(0, 0, 50), width, height);
            Camera camera = new Camera(new Point(0, 0, 0), view_frame);
            Light light = new Light(new Vector(3, 0, -1));
            Scene scene = new Scene();

            Sphere s1 = new Sphere(new Point(10, 5, 35), 3);
            scene.AddObject(s1);
            Sphere s2 = new Sphere(new Point(10, -10, 35), 2);
            scene.AddObject(s2);

            scene.AddLight(light);


            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Ray ray = camera.PixelRay(j, height - i, width, height);
                    List<double> dist = new List<double>();
                    foreach (IObject obj in scene.objects)
                    {
                        var point = ray.PointAtRay(obj.Intersection(ray));
                        var normal = obj.GetNormal(point);
                        var li = scene.light.LightIntensity(normal);

                        if (li > 0 && li < 0.2) { 
                            Console.Write('.');
                        }
                        else if (li > 0.2 && li < 0.5)
                        {
                            Console.Write('*');
                        }
                        else if (li > 0.5 && li < 0.8)
                        {
                            Console.Write('O');
                        }
                        else if (li < 0)
                        {
                            Console.Write(' ');
                        }
                        else
                        {
                            Console.Write('#');
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}