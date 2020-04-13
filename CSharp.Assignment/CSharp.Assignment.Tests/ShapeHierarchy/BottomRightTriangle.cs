using CSharp.Assignments.Tests.Library;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using System.Reflection;

namespace CSharp.Assignments.Classes.ShapeHierarchy.Tests
{
    public class BottomRightTriangleTests
    {
        [Test]
        public void TestClass()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<BottomRightTriangle>();
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
            dynamic triangle;
            string actual;
            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 0);
            triangle.FillCharacter = '1';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "");

            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 1);
            triangle.FillCharacter = '}';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "}");

            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 2);
            triangle.FillCharacter = 'p';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "pp",
            " p");

            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 3);
            triangle.FillCharacter = ',';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            ",,,",
            " ,,",
            "  ,");

            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 4);
            triangle.FillCharacter = 'y';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "yyyy",
            " yyy",
            "  yy",
            "   y");

            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 5);
            triangle.FillCharacter = 'M';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "MMMMM",
            " MMMM",
            "  MMM",
            "   MM",
            "    M");

            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 6);
            triangle.FillCharacter = '=';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "======",
            " =====",
            "  ====",
            "   ===",
            "    ==",
            "     =");

            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 7);
            triangle.FillCharacter = 't';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "ttttttt",
            " tttttt",
            "  ttttt",
            "   tttt",
            "    ttt",
            "     tt",
            "      t");

            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 8);
            triangle.FillCharacter = 'A';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "AAAAAAAA",
            " AAAAAAA",
            "  AAAAAA",
            "   AAAAA",
            "    AAAA",
            "     AAA",
            "      AA",
            "       A");

            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 9);
            triangle.FillCharacter = 'P';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "PPPPPPPPP",
            " PPPPPPPP",
            "  PPPPPPP",
            "   PPPPPP",
            "    PPPPP",
            "     PPPP",
            "      PPP",
            "       PP",
            "        P");

            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 10);
            triangle.FillCharacter = 'D';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "DDDDDDDDDD",
            " DDDDDDDDD",
            "  DDDDDDDD",
            "   DDDDDDD",
            "    DDDDDD",
            "     DDDDD",
            "      DDDD",
            "       DDD",
            "        DD",
            "         D");

            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 11);
            triangle.FillCharacter = '>';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            ">>>>>>>>>>>",
            " >>>>>>>>>>",
            "  >>>>>>>>>",
            "   >>>>>>>>",
            "    >>>>>>>",
            "     >>>>>>",
            "      >>>>>",
            "       >>>>",
            "        >>>",
            "         >>",
            "          >");

            triangle = Activator.CreateInstance(typeof(BottomRightTriangle), 12);
            triangle.FillCharacter = 'r';
            Assert.AreEqual("bottom right triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "rrrrrrrrrrrr",
            " rrrrrrrrrrr",
            "  rrrrrrrrrr",
            "   rrrrrrrrr",
            "    rrrrrrrr",
            "     rrrrrrr",
            "      rrrrrr",
            "       rrrrr",
            "        rrrr",
            "         rrr",
            "          rr",
            "           r");

#if !DEBUG
    });
#endif
        }
    }
}
