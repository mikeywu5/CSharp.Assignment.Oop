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
    public class UpLeftTriangleTests
    {


        [Test]
        public void TestClass()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<UpLeftTriangle>();
            assert.Extends<EmptyTextShape>();

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

        public void TestMembers()
        {
            dynamic triangle;
            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 23); ; // new UpLeftTriangle(23)
            Assert.AreEqual(23, triangle.Width);
            Assert.AreEqual(23, triangle.Height);
            Assert.AreEqual(23 * (2 + Math.Sqrt(2)), triangle.Area(), 1E-9);
            Assert.AreEqual(23 * 23 / 2m, triangle.Perimeter());

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 207); ; // new UpLeftTriangle(207)
            Assert.AreEqual(207, triangle.Width);
            Assert.AreEqual(207, triangle.Height);
            Assert.AreEqual(207 * (2 + Math.Sqrt(2)), triangle.Area(), 1E-9);
            Assert.AreEqual(207 * 207 / 2m, triangle.Perimeter());

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 0); ; // new UpLeftTriangle(0)
            Assert.AreEqual(0, triangle.Width);
            Assert.AreEqual(0, triangle.Height);
            Assert.AreEqual(0, triangle.Area(), 1E-9);
            Assert.AreEqual(0, triangle.Perimeter());

        }


        [Test]
        public virtual void TestToString()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            ;
            string actual;
            dynamic triangle;
            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 0);
            triangle.FillCharacter = 'K';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "");

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 1);
            triangle.FillCharacter = ';';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            ";");

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 2);
            triangle.FillCharacter = '-';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "-",
            "--");

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 3);
            triangle.FillCharacter = 'I';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "I",
            "II",
            "III");

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 4);
            triangle.FillCharacter = '8';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "8",
            "88",
            "888",
            "8888");

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 5);
            triangle.FillCharacter = 'T';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "T",
            "TT",
            "TTT",
            "TTTT",
            "TTTTT");

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 6);
            triangle.FillCharacter = 'M';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "M",
            "MM",
            "MMM",
            "MMMM",
            "MMMMM",
            "MMMMMM");

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 7);
            triangle.FillCharacter = '4';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "4",
            "44",
            "444",
            "4444",
            "44444",
            "444444",
            "4444444");

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 8);
            triangle.FillCharacter = 'S';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "S",
            "SS",
            "SSS",
            "SSSS",
            "SSSSS",
            "SSSSSS",
            "SSSSSSS",
            "SSSSSSSS");

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 9);
            triangle.FillCharacter = '-';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "-",
            "--",
            "---",
            "----",
            "-----",
            "------",
            "-------",
            "--------",
            "---------");

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 10);
            triangle.FillCharacter = 'b';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "b",
            "bb",
            "bbb",
            "bbbb",
            "bbbbb",
            "bbbbbb",
            "bbbbbbb",
            "bbbbbbbb",
            "bbbbbbbbb",
            "bbbbbbbbbb");

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 11);
            triangle.FillCharacter = 'D';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "D",
            "DD",
            "DDD",
            "DDDD",
            "DDDDD",
            "DDDDDD",
            "DDDDDDD",
            "DDDDDDDD",
            "DDDDDDDDD",
            "DDDDDDDDDD",
            "DDDDDDDDDDD");

            triangle = Activator.CreateInstance(typeof(UpLeftTriangle), 12);
            triangle.FillCharacter = 'q';
            Assert.AreEqual("up left triangle", triangle.Name);
            actual = triangle.ToString();
            actual.Assert(
            "q",
            "qq",
            "qqq",
            "qqqq",
            "qqqqq",
            "qqqqqq",
            "qqqqqqq",
            "qqqqqqqq",
            "qqqqqqqqq",
            "qqqqqqqqqq",
            "qqqqqqqqqqq",
            "qqqqqqqqqqqq");
#if !DEBUG
    });
#endif
        }


    }
}
