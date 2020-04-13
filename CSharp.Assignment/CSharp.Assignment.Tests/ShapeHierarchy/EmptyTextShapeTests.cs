using System;
using CSharp.Assignments.Tests.Library;
using NUnit.Framework;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace CSharp.Assignments.Classes.ShapeHierarchy.Tests
{
    public class EmptyTextShapeTests
    {
        [Test]
        public void TestClass()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<EmptyTextShape>();
            assert.Property<int>(
                "Width",
                BindingFlags.Instance |
                 BindingFlags.Public |
                BindingFlags.GetProperty
            );
            assert.Property<int>(
                "Height",
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.GetProperty
            );
            assert.Property<string>(
                "Name",
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.GetProperty);
            assert.Method(
                "Draw",
                 BindingFlags.Instance |
                 BindingFlags.Public
            );
            assert.Constructor(
                BindingFlags.Instance |
                BindingFlags.Public,
                new Param<int>("width"),
                new Param<int>("height")
            );
            assert.Method<decimal>(
                "Area",
                BindingFlags.Instance |
                BindingFlags.Public
            ).Virtual();

            assert.Method<decimal>(
                "Perimeter",
                BindingFlags.Instance |
                BindingFlags.Public
            ).Virtual();
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
            dynamic o = Activator.CreateInstance(typeof(EmptyTextShape), 10, 20);
            Assert.AreEqual(10, o.Width);
            Assert.AreEqual(20, o.Height);
            Assert.AreEqual("empty shape", o.Name);
            o.FillCharacter = '#';
            Assert.AreEqual('#', o.FillCharacter);
            o.FillCharacter = '*';
            Assert.AreEqual('*', o.FillCharacter);
            Assert.AreEqual(0, o.Area());
            Assert.AreEqual(0, o.Perimeter());
#if !DEBUG
    });
#endif
        }
    }
}
