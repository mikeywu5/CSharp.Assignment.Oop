using System;
using NUnit.Framework;
using CSharp.Assignments.Tests.Library;
using System.Reflection;
using System.Collections.Generic;

namespace CSharp.Assignments.Classes.Averages.Tests
{
    public class AveragesTests
    {
        [Test]
        public void TestAggregator()
        {
#if !DEBUG
            Assert.Multiple(() =>
            {
#endif
            var aggregator = new TypeAssert<Aggregator>();
            aggregator.Class();
            aggregator.Abstract();
            aggregator.Field<List<int>>("Numbers",
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.GetField)?.Protected()?.ReadOnly();

            aggregator.Constructor(
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<int[]>("numbers"));

            aggregator.Property<int>(
                "Value",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            )?.Abstract();

            aggregator.Method(
                "Append",
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<Aggregator>("aggregators")
            )?.Virtual();

            aggregator.Method<string>(
                "ToString",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.DeclaredOnly
            );

#if !DEBUG
            });
#endif
        }

        [Test]
        public void TestSum()
        {
#if !DEBUG
            Assert.Multiple(() =>
            {
#endif
            var sum = new TypeAssert<Sum>();
            sum.Class();
            sum.Extends<Aggregator>();
            sum.NonField<List<int>>("Numbers",
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.DeclaredOnly |
                BindingFlags.Instance |
                BindingFlags.GetField);

            sum.Constructor(
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<int[]>("numbers"));

            sum.Property<int>(
                "Value",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            )?.Override();

            sum.Method(
                "Append",
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<Aggregator>("aggregators")
            )?.Override();

#if !DEBUG
            });
#endif
        }
        [Test]
        public void TestCount()
        {
#if !DEBUG
            Assert.Multiple(() =>
            {
#endif
            var count = new TypeAssert<Count>();
            count.Class();
            count.Extends<Aggregator>();
            count.Constructor(
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<int[]>("numbers"));
            count.Property<int>(
                "Value",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            )?.Override();

#if !DEBUG
            });
#endif
        }

        [Test]
        public void TestAverage()
        {
#if !DEBUG
            Assert.Multiple(() =>
            {
#endif
            var average = new TypeAssert<Average>();
            average.Extends<Sum>();
            average.Class();
            average.Field<List<int>>("_count",
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.GetField)?.Private()?.ReadOnly();

            average.Constructor(
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<int[]>("numbers"));

            average.Property<int>(
                "Value",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            )?.Override();

            average.Property<decimal>(
                "DecimalValue",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            );

            average.Property<int>(
                "Value",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            )?.Override();
#if !DEBUG
            });
#endif
        }

        [Test]
        public void TestAppend()
        {
#if !DEBUG
            Assert.Multiple(() =>
            {
#endif      
            var count = new TypeAssert<Count>();
            var sum = new TypeAssert<Sum>();
            var average = new TypeAssert<Average>();
            dynamic a = count.New(new int[] { 1, 2, 3, 4 });
            dynamic b = sum.New(new int[] { 5, 6, 7 });
            dynamic c = average.New(new int[] { 4, 3, 2, 1, 6 });
            average.Catch<ArgumentNullException>(() => average.New(null));
            average.Catch<ArgumentNullException>(() => sum.New(null));
            average.Catch<ArgumentNullException>(() => count.New(null));
            average.Catch<ArgumentOutOfRangeException>(() => average.New(new int[0]));

            average.Catch<ArgumentNullException>(() => a.Append(null));
            average.Catch<ArgumentNullException>(() => b.Append(null));
            average.Catch<ArgumentNullException>(() => c.Append(null));
            a.Append(b);
            Assert.AreEqual("1 2 3 4 5 6 7", a.ToString());
            Assert.AreEqual(7, a.Value);
            Assert.AreEqual("5 6 7", b.ToString());
            Assert.AreEqual(18, b.Value);
            a = sum.New(new[] { 3, 2 });
            b.Append(a);
            Assert.AreEqual("8 8 7", b.ToString());
            Assert.AreEqual(23, b.Value);
            b.Append(c);
            Assert.AreEqual("12 11 9 1 6", b.ToString());
            Assert.AreEqual(39, b.Value);
            Assert.AreEqual("4 3 2 1 6", c.ToString());
            Assert.AreEqual(3, c.Value);
#if !DEBUG
            });
#endif
        }

        [Test]
        public void TestToString()
        {
#if !DEBUG
            Assert.Multiple(() =>
            {
#endif
            var count = new TypeAssert<Count>();
            var sum = new TypeAssert<Sum>();
            var average = new TypeAssert<Average>();

            dynamic a = sum.New(new[] { 1, 2, 3, 4 });
            Assert.AreEqual("1 2 3 4", a.ToString());
            a = count.New(new[] { 1, 2, 3, 4, 5 });
            Assert.AreEqual("1 2 3 4 5", a.ToString());
            a = average.New(new[] { 1, 3, 4, 5 });
            Assert.AreEqual("1 3 4 5", a.ToString());
#if !DEBUG
            });
#endif
        }
    }
}
