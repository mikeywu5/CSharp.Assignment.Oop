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
    public class UpRightTriangleTests
    {
        [Test]
        public void TestClass()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<UpRightTriangle>();
            assert.Extends<UpLeftTriangle>();

            assert.Constructor(
                BindingFlags.Instance |
                BindingFlags.Public,
                new Param<int>("baseLength")
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
                  .DeclaredIn<UpLeftTriangle>();

            assert.Method<decimal>(
              "Perimeter",
              BindingFlags.Instance |
              BindingFlags.Public)
                  .DeclaredIn<UpLeftTriangle>();
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
            dynamic triangle;


            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 0);
            triangle.FillCharacter = '/';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "");

            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 1);
            triangle.FillCharacter = '}';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "}");

            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 2);
            triangle.FillCharacter = 'W';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            " W",
            "WW");

            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 3);
            triangle.FillCharacter = 'L';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "  L",
            " LL",
            "LLL");

            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 4);
            triangle.FillCharacter = '!';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "   !",
            "  !!",
            " !!!",
            "!!!!");

            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 5);
            triangle.FillCharacter = 'A';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "    A",
            "   AA",
            "  AAA",
            " AAAA",
            "AAAAA");

            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 6);
            triangle.FillCharacter = 'L';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "     L",
            "    LL",
            "   LLL",
            "  LLLL",
            " LLLLL",
            "LLLLLL");

            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 7);
            triangle.FillCharacter = ']';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "      ]",
            "     ]]",
            "    ]]]",
            "   ]]]]",
            "  ]]]]]",
            " ]]]]]]",
            "]]]]]]]");

            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 8);
            triangle.FillCharacter = '1';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "       1",
            "      11",
            "     111",
            "    1111",
            "   11111",
            "  111111",
            " 1111111",
            "11111111");

            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 9);
            triangle.FillCharacter = 'X';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "        X",
            "       XX",
            "      XXX",
            "     XXXX",
            "    XXXXX",
            "   XXXXXX",
            "  XXXXXXX",
            " XXXXXXXX",
            "XXXXXXXXX");

            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 10);
            triangle.FillCharacter = 'y';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "         y",
            "        yy",
            "       yyy",
            "      yyyy",
            "     yyyyy",
            "    yyyyyy",
            "   yyyyyyy",
            "  yyyyyyyy",
            " yyyyyyyyy",
            "yyyyyyyyyy");

            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 11);
            triangle.FillCharacter = '5';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "          5",
            "         55",
            "        555",
            "       5555",
            "      55555",
            "     555555",
            "    5555555",
            "   55555555",
            "  555555555",
            " 5555555555",
            "55555555555");

            triangle = Activator.CreateInstance(typeof(UpRightTriangle), 12);
            triangle.FillCharacter = 'C';
            Assert.AreEqual("up right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "           C",
            "          CC",
            "         CCC",
            "        CCCC",
            "       CCCCC",
            "      CCCCCC",
            "     CCCCCCC",
            "    CCCCCCCC",
            "   CCCCCCCCC",
            "  CCCCCCCCCC",
            " CCCCCCCCCCC",
            "CCCCCCCCCCCC");
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
                var triangle = Activator.CreateInstance(typeof(UpRightTriangle), i);
                triangle.FillCharacter = c;
                sb.AppendLine($"triangle = Activator.CreateInstance(typeof(UpRightTriangle), {i});");
                sb.AppendLine($"triangle.FillCharacter = '{c}';");
                sb.AppendLine($"Assert.AreEqual(\"{triangle.Name}\", triangle.Name);");
                sb.AppendLine($"actual = triangle.ToString();");
                expected = string.Join("\",\n\"", triangle.ToString().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
                sb.AppendLine($"actual.Assert(\n\"{expected}\");");
                sb.AppendLine();
            }
            Assert.Fail(sb.ToString());
} ); 
        }
        */
    }
}
