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
    public class SquareTests
    {
        [Test]
        public void TestClass()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<Square>();
            assert.Extends<Rectangle>();

            assert.Constructor(
                BindingFlags.Instance |
                BindingFlags.Public,
                new Param<int>("width")
            );

            assert.NonConstructor(
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
                  .DeclaredIn<Rectangle>();

            assert.Method<decimal>(
              "Perimeter",
              BindingFlags.Instance |
              BindingFlags.Public)
                  .DeclaredIn<Rectangle>();
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
            // o = new Square(23);
            o = Activator.CreateInstance(typeof(Square), 23);
            Assert.AreEqual("square", o.Name);
            Assert.AreEqual(23, o.Width);
            Assert.AreEqual(23, o.Height);
            Assert.AreEqual(23 * 23, o.Area());
            Assert.AreEqual(23 * 2 + 23 * 2, o.Perimeter());

            // o = new Square(1037);
            o = Activator.CreateInstance(typeof(Square), 1037);
            Assert.AreEqual("square", o.Name);
            Assert.AreEqual(1037, o.Width);
            Assert.AreEqual(1037, o.Height);
            Assert.AreEqual(1037 * 1037, o.Area());
            Assert.AreEqual(1037 * 2 + 1037 * 2, o.Perimeter());
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
            string actual;
            dynamic square;
            // square = new Square(0); and so forth...
            square = Activator.CreateInstance(typeof(Square), 0);
            square.FillCharacter = 'B';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "");

            square = Activator.CreateInstance(typeof(Square), 1);
            square.FillCharacter = '<';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "<");

            square = Activator.CreateInstance(typeof(Square), 2);
            square.FillCharacter = 'X';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "XX",
            "XX");

            square = Activator.CreateInstance(typeof(Square), 3);
            square.FillCharacter = '.';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "...",
            "...",
            "...");

            square = Activator.CreateInstance(typeof(Square), 4);
            square.FillCharacter = 'B';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "BBBB",
            "BBBB",
            "BBBB",
            "BBBB");

            square = Activator.CreateInstance(typeof(Square), 5);
            square.FillCharacter = 'c';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "ccccc",
            "ccccc",
            "ccccc",
            "ccccc",
            "ccccc");

            square = Activator.CreateInstance(typeof(Square), 6);
            square.FillCharacter = 'B';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "BBBBBB",
            "BBBBBB",
            "BBBBBB",
            "BBBBBB",
            "BBBBBB",
            "BBBBBB");

            square = Activator.CreateInstance(typeof(Square), 7);
            square.FillCharacter = 'X';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "XXXXXXX",
            "XXXXXXX",
            "XXXXXXX",
            "XXXXXXX",
            "XXXXXXX",
            "XXXXXXX",
            "XXXXXXX");

            square = Activator.CreateInstance(typeof(Square), 8);
            square.FillCharacter = '$';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "$$$$$$$$",
            "$$$$$$$$",
            "$$$$$$$$",
            "$$$$$$$$",
            "$$$$$$$$",
            "$$$$$$$$",
            "$$$$$$$$",
            "$$$$$$$$");

            square = Activator.CreateInstance(typeof(Square), 9);
            square.FillCharacter = '9';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "999999999",
            "999999999",
            "999999999",
            "999999999",
            "999999999",
            "999999999",
            "999999999",
            "999999999",
            "999999999");

            square = Activator.CreateInstance(typeof(Square), 10);
            square.FillCharacter = 'g';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "gggggggggg",
            "gggggggggg",
            "gggggggggg",
            "gggggggggg",
            "gggggggggg",
            "gggggggggg",
            "gggggggggg",
            "gggggggggg",
            "gggggggggg",
            "gggggggggg");

            square = Activator.CreateInstance(typeof(Square), 11);
            square.FillCharacter = 'n';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "nnnnnnnnnnn",
            "nnnnnnnnnnn",
            "nnnnnnnnnnn",
            "nnnnnnnnnnn",
            "nnnnnnnnnnn",
            "nnnnnnnnnnn",
            "nnnnnnnnnnn",
            "nnnnnnnnnnn",
            "nnnnnnnnnnn",
            "nnnnnnnnnnn",
            "nnnnnnnnnnn");

            square = Activator.CreateInstance(typeof(Square), 12);
            square.FillCharacter = 'R';
            Assert.AreEqual("square", square.Name);
            actual = square.ToString();
            actual.Assert(
            "RRRRRRRRRRRR",
            "RRRRRRRRRRRR",
            "RRRRRRRRRRRR",
            "RRRRRRRRRRRR",
            "RRRRRRRRRRRR",
            "RRRRRRRRRRRR",
            "RRRRRRRRRRRR",
            "RRRRRRRRRRRR",
            "RRRRRRRRRRRR",
            "RRRRRRRRRRRR",
            "RRRRRRRRRRRR",
            "RRRRRRRRRRRR");
#if !DEBUG
});
#endif
        }
        /*
        [Test]
        public void TesttoString()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var sb = new StringBuilder();
            string expected = "";
            for (int i = 0; i < 13; i++)
            {
                char c;
                do
                {
                    c = Convert.ToChar(Utils.Randomize(typeof(char), '!', '~'));
                } while (c == '\\' || c == '"' || c == '\'');
                var square = Activator.CreateInstance(typeof(Square), i);
                square.FillCharacter = c;
                sb.AppendLine($"square = Activator.CreateInstance(typeof(Square), {i});");
                sb.AppendLine($"square.FillCharacter = '{c}';");
                sb.AppendLine($"Assert.AreEqual(\"{square.Name}\", square.Name);");
                sb.AppendLine($"actual = square.ToString();");
                expected = string.Join("\",\n\"", square.ToString().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
                sb.AppendLine($"actual.Assert(\n\"{expected}\");");
                sb.AppendLine();
            }
            Assert.Fail(sb.ToString());
} ); 
        }
        */
    }
}
