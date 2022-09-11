using CGLab.Class;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDotProduct()
        {
            Vector a = new Vector(1, 1, 1);
            Vector b = new Vector(-1, 1, 1);
            double expect = 1;
            double result = Vector.DotProd(a, b);
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void TestCrossProduct()
        {
            Vector a = new Vector(1, 3, 5);
            Vector b = new Vector(1, 1, 1);
            Vector expect = new Vector(-2, 4, -2);
            Vector result = Vector.CrossProd(a, b);
            Assert.AreEqual((expect.x, expect.y, expect.z), (result.x, result.y, result.z));
        }

        [TestMethod]
        public void TestNormalize()
        {
            Vector a = new Vector(0, 5, 0);
            Vector expect = new Vector(0, 1, 0);
            Vector result = Vector.Normalize(a);
            Assert.AreEqual((expect.x, expect.y, expect.z), (result.x, result.y, result.z));
        }

        [TestMethod]
        public void TestSphereIntersection()
        {
            Sphere sphere = new Sphere(new Point(0, 3, 0), 1);
            Ray ray = new Ray(new Point(0, 0, 0), new Vector(0, 2, 0));
            var expect = 1;
            var result = sphere.Intersection(ray);
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void TestPlaneIntersection()
        {
            Plane plane = new Plane(new Vector(0, 1, 0), new Point(0, 5, 0));
            Ray ray = new Ray(new Point(0, 0, 0), new Vector(0, 2, 0));
            var expect = 2.5;
            var result = plane.Intersection(ray);
            Assert.AreEqual(expect, result);
        }

        [TestMethod]
        public void TestGetSphereNormal()
        {
            Sphere sphere = new Sphere(new Point(0, 3, 0), 1);
            Point p = new Point(0, 2, 0);
            Point expect = new Point(0, -1, 0);
            var result = sphere.GetNormal(p);
            Assert.AreEqual((expect.x, expect.y, expect.z), (result.x, result.y, result.z));
        }
    }
}