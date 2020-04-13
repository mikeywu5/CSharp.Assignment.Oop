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
    public class BottomLeftTriangleTests
    {
        [Test]
        public void TestClass()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<BottomLeftTriangle>();
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
            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 0);
            triangle.FillCharacter = 'a';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "");

            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 1);
            triangle.FillCharacter = 'j';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "j");

            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 2);
            triangle.FillCharacter = '=';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "==",
            "=");

            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 3);
            triangle.FillCharacter = 'O';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "OOO",
            "OO",
            "O");

            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 4);
            triangle.FillCharacter = 'Q';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "QQQQ",
            "QQQ",
            "QQ",
            "Q");

            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 5);
            triangle.FillCharacter = 'c';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "ccccc",
            "cccc",
            "ccc",
            "cc",
            "c");

            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 6);
            triangle.FillCharacter = '7';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "777777",
            "77777",
            "7777",
            "777",
            "77",
            "7");

            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 7);
            triangle.FillCharacter = '5';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "5555555",
            "555555",
            "55555",
            "5555",
            "555",
            "55",
            "5");

            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 8);
            triangle.FillCharacter = 'i';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "iiiiiiii",
            "iiiiiii",
            "iiiiii",
            "iiiii",
            "iiii",
            "iii",
            "ii",
            "i");

            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 9);
            triangle.FillCharacter = 'x';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "xxxxxxxxx",
            "xxxxxxxx",
            "xxxxxxx",
            "xxxxxx",
            "xxxxx",
            "xxxx",
            "xxx",
            "xx",
            "x");

            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 10);
            triangle.FillCharacter = 'P';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "PPPPPPPPPP",
            "PPPPPPPPP",
            "PPPPPPPP",
            "PPPPPPP",
            "PPPPPP",
            "PPPPP",
            "PPPP",
            "PPP",
            "PP",
            "P");

            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 11);
            triangle.FillCharacter = 'c';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "ccccccccccc",
            "cccccccccc",
            "ccccccccc",
            "cccccccc",
            "ccccccc",
            "cccccc",
            "ccccc",
            "cccc",
            "ccc",
            "cc",
            "c");

            triangle = Activator.CreateInstance(typeof(BottomLeftTriangle), 12);
            triangle.FillCharacter = ',';
            Assert.AreEqual("bottom left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            ",,,,,,,,,,,,",
            ",,,,,,,,,,,",
            ",,,,,,,,,,",
            ",,,,,,,,,",
            ",,,,,,,,",
            ",,,,,,,",
            ",,,,,,",
            ",,,,,",
            ",,,,",
            ",,,",
            ",,",
            ",");


#if !DEBUG
    });
#endif
        }


    }
}
