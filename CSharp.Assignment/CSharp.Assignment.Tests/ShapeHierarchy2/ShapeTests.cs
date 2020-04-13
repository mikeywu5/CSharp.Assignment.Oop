// Exercise 12.10 Solution: ShapeTest.cs
// Application tests the Shape hierarchy.
using System;
using CSharp.Assignments.Tests.Library;
using System.Text;
using NUnit.Framework;
using System.Reflection;

namespace CSharp.Assignments.Classes.ShapeHierarchy2.Tests
{
    public class ShapeTests
    {
        [Test]
        public void TestShape()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<Shape>();

            assert.Abstract();

            assert.Property<int>(
                 "X",
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.GetProperty
            );

            assert.Property<int>(
                "Y",
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.GetProperty
            );

            assert.Property<string>(
                "Name",
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.GetProperty
            );

            assert.Constructor(
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic,
                new Param<int>("x"),
                new Param<int>("y")
            );

            assert.Property<string>(
                "Name",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Abstract();

            assert.Method<string>(
                "ToString",
                BindingFlags.Public |
                BindingFlags.Instance
            ).Override();
#if !DEBUG
        });
#endif
        }

        [Test]
        public void TestTwoDimensionalShape()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<TwoDimensionalShape>();
            assert.Abstract();
            assert.Extends<Shape>();
            assert.Constructor(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance,
                new Param<int>("x"),
                new Param<int>("y"),
                new Param<int>("dimension1"),
                new Param<int>("dimension2")
            );

            assert.Field<int>(
                "Dimension1",
                BindingFlags.Instance |
                BindingFlags.NonPublic
            ).Protected();

            assert.Field<int>(
                "Dimension2",
                BindingFlags.Instance |
                BindingFlags.NonPublic
            ).Protected();

            assert.Property<double>(
                "Area",
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.GetProperty
            ).Abstract();
#if !DEBUG
    });
#endif
        }

        [Test]
        public void TestThreeDimensionalShape()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<ThreeDimensionalShape>();
            assert.Abstract();
            assert.Extends<Shape>();
            assert.Constructor(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance,
                new Param<int>("x"),
                new Param<int>("y"),
                new Param<int>("dimension1"),
                new Param<int>("dimension2"),
                new Param<int>("dimension3")
            );

            assert.Field<int>(
                "Dimension1",
                BindingFlags.Instance |
                BindingFlags.NonPublic
            ).Protected();

            assert.Field<int>(
                "Dimension2",
                BindingFlags.Instance |
                BindingFlags.NonPublic
            ).Protected();

            assert.Field<int>(
                "Dimension3",
                BindingFlags.Instance |
                BindingFlags.NonPublic
            ).Protected();

            assert.Property<double>(
                "Area",
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.GetProperty
            ).Abstract();

            assert.Property<double>(
                "Volume",
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.GetProperty
            ).Abstract();
#if !DEBUG
});
#endif
        }

        [Test]
        public void TestCircle()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<Circle>();
            assert.Extends<TwoDimensionalShape>();
            assert.NonAbstract();
            assert.Constructor(
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<int>("x"),
                new Param<int>("y"),
                new Param<int>("radius")
            );
            assert.ConstructorCount(1);

            assert.Property<string>(
                "Name",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Override();

            assert.Property<double>(
                "Area",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Override();

            assert.Property<int>(
                "Radius",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty |
                BindingFlags.SetProperty
            );

            assert.Method<string>(
                "ToString",
                BindingFlags.Public |
                BindingFlags.Instance
            ).Override();

            var dimension1 = assert.Field<int>(
                "Dimension1",
                BindingFlags.NonPublic |
                BindingFlags.Instance
            ).DeclaredIn<TwoDimensionalShape>();

            var dimension2 = assert.Field<int>(
                "Dimension2",
                BindingFlags.NonPublic |
                BindingFlags.Instance
            ).DeclaredIn<TwoDimensionalShape>();

            // var obj = new Circle(1, 2 ,3);
            dynamic obj = assert.New(1, 2, 3);
            Assert.AreEqual("Circle", obj.Name);
            Assert.AreEqual(1, obj.X);
            Assert.AreEqual(2, obj.Y);
            Assert.AreEqual(3, obj.Radius);
            Assert.AreEqual(3, dimension1.GetValue(obj));
            Assert.AreEqual(3, dimension2.GetValue(obj));
            Assert.AreEqual(28.274333882308138, obj.Area, 1E-10);
            Assert.AreEqual("(1, 2) radius: 3", obj.ToString());

            obj.Radius = 7;
            Assert.AreEqual(7, dimension1.GetValue(obj));
            Assert.AreEqual(7, dimension2.GetValue(obj));
            Assert.AreEqual(153.93804002589985, obj.Area, 1E-10);
            Assert.AreEqual("(1, 2) radius: 7", obj.ToString());
#if !DEBUG
});
#endif
        }

        [Test]
        public void TestSquare()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<Square>();
            assert.Extends<TwoDimensionalShape>();
            assert.NonAbstract();
            assert.Constructor(
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<int>("x"),
                new Param<int>("y"),
                new Param<int>("side")
            );
            assert.ConstructorCount(1);

            assert.Property<string>(
                "Name",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Override();

            assert.Property<double>(
                "Area",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Override();

            assert.Property<int>(
                "Side",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty |
                BindingFlags.SetProperty
            );

            assert.Method<string>(
                "ToString",
                BindingFlags.Public |
                BindingFlags.Instance
            ).Override();

            var dimension1 = assert.Field<int>(
                "Dimension1",
                BindingFlags.NonPublic |
                BindingFlags.Instance
            ).DeclaredIn<TwoDimensionalShape>();

            var dimension2 = assert.Field<int>(
                "Dimension2",
                BindingFlags.NonPublic |
                BindingFlags.Instance
            ).DeclaredIn<TwoDimensionalShape>();

            // var obj = new Square(1, 2 ,3);
            dynamic obj = assert.New(1, 2, 3);
            Assert.AreEqual("Square", obj.Name);
            Assert.AreEqual(1, obj.X);
            Assert.AreEqual(2, obj.Y);
            Assert.AreEqual(3, obj.Side);
            Assert.AreEqual(3, dimension1.GetValue(obj));
            Assert.AreEqual(3, dimension2.GetValue(obj));
            Assert.AreEqual(9.0, obj.Area, 1E-10);
            Assert.AreEqual("(1, 2) side: 3", obj.ToString());

            obj.Side = 7;
            Assert.AreEqual(7, dimension1.GetValue(obj));
            Assert.AreEqual(7, dimension2.GetValue(obj));
            Assert.AreEqual(49.0, obj.Area, 1E-10);
            Assert.AreEqual("(1, 2) side: 7", obj.ToString());
#if !DEBUG
});
#endif
        }

        [Test]
        public void TestSphere()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<Sphere>();
            assert.Extends<ThreeDimensionalShape>();
            assert.NonAbstract();
            assert.Constructor(
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<int>("x"),
                new Param<int>("y"),
                new Param<int>("radius")
            );
            assert.ConstructorCount(1);

            assert.Property<string>(
                "Name",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Override();

            assert.Property<double>(
                "Area",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Override();

            assert.Property<double>(
                "Volume",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Override();

            assert.Property<int>(
                "Radius",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty |
                BindingFlags.SetProperty
            );

            assert.Method<string>(
                "ToString",
                BindingFlags.Public |
                BindingFlags.Instance
            ).Override();

            var dimension1 = assert.Field<int>(
                "Dimension1",
                BindingFlags.NonPublic |
                BindingFlags.Instance
            ).DeclaredIn<ThreeDimensionalShape>();

            var dimension2 = assert.Field<int>(
                "Dimension2",
                BindingFlags.NonPublic |
                BindingFlags.Instance
            ).DeclaredIn<ThreeDimensionalShape>();

            var dimension3 = assert.Field<int>(
              "Dimension3",
              BindingFlags.NonPublic |
              BindingFlags.Instance
          ).DeclaredIn<ThreeDimensionalShape>();

            // var obj = new Sphere(1, 2 ,3);
            dynamic obj = assert.New(2, 1, 4);
            Assert.AreEqual("Sphere", obj.Name);
            Assert.AreEqual(2, obj.X);
            Assert.AreEqual(1, obj.Y);
            Assert.AreEqual(4, obj.Radius);
            Assert.AreEqual(4, dimension1.GetValue(obj));
            Assert.AreEqual(4, dimension2.GetValue(obj));
            Assert.AreEqual(4, dimension3.GetValue(obj));
            Assert.AreEqual(201.06192982974676, obj.Area, 1E-10);
            Assert.AreEqual(268.08257310632899, obj.Volume, 1E-10);
            Assert.AreEqual("(2, 1) radius: 4", obj.ToString());

            obj.Radius = 7;
            Assert.AreEqual(7, dimension1.GetValue(obj));
            Assert.AreEqual(7, dimension2.GetValue(obj));
            Assert.AreEqual(615.75216010359941, obj.Area, 1E-10);
            Assert.AreEqual(1436.7550402417321, obj.Volume, 1E-10);
            Assert.AreEqual("(2, 1) radius: 7", obj.ToString());
#if !DEBUG
});
#endif
        }

        [Test]
        public void TestCube()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<Cube>();
            assert.Extends<ThreeDimensionalShape>();
            assert.NonAbstract();
            assert.Constructor(
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<int>("x"),
                new Param<int>("y"),
                new Param<int>("side")
            );
            assert.ConstructorCount(1);

            assert.Property<string>(
                "Name",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Override();

            assert.Property<double>(
                "Area",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Override();

            assert.Property<double>(
                "Volume",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Override();

            assert.Property<int>(
                "Side",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty |
                BindingFlags.SetProperty
            );

            assert.Method<string>(
                "ToString",
                BindingFlags.Public |
                BindingFlags.Instance
            ).Override();

            var dimension1 = assert.Field<int>(
                "Dimension1",
                BindingFlags.NonPublic |
                BindingFlags.Instance
            ).DeclaredIn<ThreeDimensionalShape>();

            var dimension2 = assert.Field<int>(
                "Dimension2",
                BindingFlags.NonPublic |
                BindingFlags.Instance
            ).DeclaredIn<ThreeDimensionalShape>();

            var dimension3 = assert.Field<int>(
                "Dimension3",
                BindingFlags.NonPublic |
                BindingFlags.Instance
            ).DeclaredIn<ThreeDimensionalShape>();

            // var obj = new Sphere(1, 2 ,3);
            dynamic obj = assert.New(3, 5, 2);
            Assert.AreEqual("Cube", obj.Name);
            Assert.AreEqual(3, obj.X);
            Assert.AreEqual(5, obj.Y);
            Assert.AreEqual(2, obj.Side);
            Assert.AreEqual(2, dimension1.GetValue(obj));
            Assert.AreEqual(2, dimension2.GetValue(obj));
            Assert.AreEqual(2, dimension3.GetValue(obj));
            Assert.AreEqual(24, obj.Area, 1E-10);
            Assert.AreEqual(8, obj.Volume, 1E-10);
            Assert.AreEqual("(3, 5) side: 2", obj.ToString());

            obj.Side = 7;
            Assert.AreEqual(7, dimension1.GetValue(obj));
            Assert.AreEqual(7, dimension2.GetValue(obj));
            Assert.AreEqual(294, obj.Area, 1E-10);
            Assert.AreEqual(343, obj.Volume, 1E-10);
            Assert.AreEqual("(3, 5) side: 7", obj.ToString());
#if !DEBUG
});
#endif
        }

        /// <summary>
        /// Tests the polymorphism of the compute method.
        /// </summary>
        [Test]
        public void TestCompute()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<Shape>();
            var compute = assert.Method(
                "Compute",
                BindingFlags.Static |
                BindingFlags.Public,
                new Param<Shape[]>("shapes")
            );

            Shape[] shapes = new Shape[4];
            // shapes[0] = new Circle(22, 88, 4);
            shapes[0] = (Shape)Activator.CreateInstance(typeof(Circle), 22, 88, 4);
            // shapes[1] = new Cube(79, 61, 8);
            shapes[1] = (Shape)Activator.CreateInstance(typeof(Cube), 79, 61, 8);
            // shapes[2] = new Sphere(8, 89, 2);
            shapes[2] = (Shape)Activator.CreateInstance(typeof(Sphere), 8, 89, 2);
            // shapes[3] = new Square(71, 96, 10);
            shapes[3] = (Shape)Activator.CreateInstance(typeof(Square), 71, 96, 10);

            // Shape.Compute(shapes);
            Action app = () => compute.Invoke(null, new[] { shapes });
            string actual = app.Run();
            actual.Assert(
                "Circle",
                "(22, 88) radius: 4",
                "50.26548246",
                "Cube",
                "(79, 61) side: 8",
                "384",
                "512",
                "Sphere",
                "(8, 89) radius: 2",
                "50.26548246",
                "33.51032164",
                "Square",
                "(71, 96) side: 10",
                "100"
            );
#if !DEBUG
});
#endif
        }
    }
}
