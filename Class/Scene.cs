using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGLab.Class;

namespace CGLab.Class
{
    public class Scene
    {
        public List<IObject> objects;
        public Light light;

        public Scene()
        {
            objects = new List<IObject>();
        }

        public Scene (List<IObject> objects, Light light)
        {
            this.objects = objects;
            this.light = light;
        }

        public void AddObject(IObject obj)
        {
            objects.Add(obj);
        }

        public void AddObjects(List<IObject> objectsList)
        {
            foreach (IObject obj in objectsList)
            {
                objects.Add(obj);
            }
        }

        public void AddLight(Light light)
        {
            this.light = light;
        }
    }
}
