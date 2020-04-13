using CSharp.Assignments.Tests.Library;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Assignments.Classes.ShapeHierarchy.Tests
{
    public class RectangleTests
    {

        [Test]
        public void TestClass()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<Rectangle>();
            assert.Extends<EmptyTextShape>();

            assert.Constructor(
                BindingFlags.Instance |
                BindingFlags.Public,
                new Param<int>("width"),
                new Param<int>("height")
            );

            assert.Property<int>(
                "Width",
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.GetProperty
            ).DeclaredIn<EmptyTextShape>();

            assert.Property<int>(
                "Height",
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.GetProperty
            ).DeclaredIn<EmptyTextShape>();

            assert.Property<string>(
                "Name",
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.GetProperty
            ).DeclaredIn<EmptyTextShape>();

            assert.Method<decimal>(
              "Area",
              BindingFlags.Instance |
              BindingFlags.Public)
                  .Override();

            assert.Method<decimal>(
              "Perimeter",
              BindingFlags.Instance |
              BindingFlags.Public)
                  .Override();

#if !DEBUG
        });
#endif
        }

        [Test]
        public void TestMembers()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            dynamic o;
            // o = new Rectangle(23, 53);
            o = Activator.CreateInstance(typeof(Rectangle), 23, 53);
            Assert.AreEqual("rectangle", o.Name);
            Assert.AreEqual(23, o.Width);
            Assert.AreEqual(53, o.Height);
            Assert.AreEqual(23 * 53, o.Area());
            Assert.AreEqual(23 * 2 + 53 * 2, o.Perimeter());

            // o = new Rectangle(1037, 531);
            o = Activator.CreateInstance(typeof(Rectangle), 1037, 531);
            Assert.AreEqual("rectangle", o.Name);
            Assert.AreEqual(1037, o.Width);
            Assert.AreEqual(531, o.Height);
            Assert.AreEqual(1037 * 531, o.Area());
            Assert.AreEqual(1037 * 2 + 531 * 2, o.Perimeter());
#if !DEBUG
    });
#endif
        }

        [Test]
        public void TestToString()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            dynamic o;
            // o = new Rectangle(0, 0);
            o = Activator.CreateInstance(typeof(Rectangle), 0, 0);
            o.FillCharacter = '@';
            ((string)o.ToString()).Assert();

            // o = new Rectangle(1, 1);
            o = Activator.CreateInstance(typeof(Rectangle), 1, 1);
            o.FillCharacter = '-';
            ((string)o.ToString()).Assert("-");

            // o = new Rectangle(10, 1);
            o = Activator.CreateInstance(typeof(Rectangle), 10, 1);
            o.FillCharacter = '*';
            ((string)o.ToString()).Assert("**********");

            // o = new Rectangle(10, 7);
            o = Activator.CreateInstance(typeof(Rectangle), 10, 7);
            o.FillCharacter = '!';
            ((string)o.ToString()).Assert(
                "!!!!!!!!!!",
                "!!!!!!!!!!",
                "!!!!!!!!!!",
                "!!!!!!!!!!",
                "!!!!!!!!!!",
                "!!!!!!!!!!",
                "!!!!!!!!!!"
            );
#if !DEBUG
});
#endif
        }
    }
}
