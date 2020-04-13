using System;
using System.Reflection;
using CSharp.Assignments.Classes.Housing;
using CSharp.Assignments.Tests.Library;
using NUnit.Framework;
using static CSharp.Assignments.Tests.Library.TypeAssert;
using System.Text;
using System.Linq;

namespace CSharp.Assignments.Classes.Housing.Tests
{
    public class HousingTests
    {
        [Test]
        [Category("Home Class")]
        public void TestHome()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<Home>();
            assert.Abstract();
            assert.Property<string>(
              "Address",
              BindingFlags.Instance |
              BindingFlags.Public |
              BindingFlags.GetProperty);

            assert.Property<int>(
                "YearBuilt",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            );

            assert.Property<decimal>(
                "Price",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            );

            assert.Constructor(
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<string>("address"),
                new Param<int>("yearBuilt"),
                new Param<decimal>("price")
            );

            assert.NonConstructor(
                BindingFlags.Public |
                BindingFlags.Instance
            );

            assert.Property<decimal>(
                "TotalCost",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Virtual();

            assert.Method<decimal>(
                "GetRate",
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<int>("numberOfPeriods")
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
        [Category("Home Class")]
        public void TestCondo()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<Condo>();
            assert.Extends<Home>();
            assert.Implements<IRental>();
            assert.NonAbstract();

            assert.Property<string>(
               "Address",
               BindingFlags.Instance |
               BindingFlags.Public |
               BindingFlags.GetProperty
            ).DeclaredIn<Home>();

            assert.Property<int>(
                "YearBuilt",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).DeclaredIn<Home>();

            assert.Property<decimal>(
                "Price",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).DeclaredIn<Home>();

            assert.Property<decimal>(
                "Fee",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty);

            assert.Property<string>(
                "UnitNumber",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            );

            assert.Property<bool>(
                "IsRental",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty |
                BindingFlags.SetProperty
            );

            assert.NonConstructor(
                BindingFlags.Public |
                BindingFlags.Instance
            );

            assert.Constructor(
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<string>("address"),
                new Param<int>("yearBuilt"),
                new Param<decimal>("price"),
                new Param<string>("unitNumber"),
                new Param<decimal>("fee"),
                new Param<bool>("isRental") { Default = false }
            );

            assert.NonConstructor(
                BindingFlags.Public |
                BindingFlags.Instance
            );

            assert.Property<decimal>(
                "TotalCost",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).Override().DeclaredIn<Condo>(); ;

            assert.Method<decimal>(
                "GetRate",
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<int>("numberOfPeriods")
            ).Override().DeclaredIn<Condo>();

            assert.Method<decimal>(
                "GetMonthlyRate",
                BindingFlags.Public |
                BindingFlags.Instance
            );
#if !DEBUG
    });
#endif
        }

        [Test]
        [Category("Home Class")]
        public void TestCondoData()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var condo = new TypeAssert<Condo>();
            dynamic o;
            Catch<ArgumentOutOfRangeException>(() => condo.New("One Main Street", 1799, 100_000m, "A", 1m, false));
            Catch<ArgumentOutOfRangeException>(() => condo.New("Two Main Street", 2000, 0m, "A", 1m, true));
            Catch<ArgumentOutOfRangeException>(() => condo.New("Two Main Street", 2000, 100m, "A", -1m, false));
            Catch<ArgumentOutOfRangeException>(() => condo.New("Two Main Street", 2050, 100m, "A", 1m, false));
            o = condo.New("Two Main Street", 1800, 100_000m, "A", 2000m, false);
            Assert.AreEqual(2000m, o.Fee);
            Assert.AreEqual(100_000m, o.Price);
            Assert.AreEqual(102_000m, o.TotalCost);
            Assert.AreEqual(1800, o.YearBuilt);
            Assert.AreEqual("A", o.UnitNumber);
            Assert.IsFalse(o.IsRental);
            Catch<InvalidOperationException>(() => o.GetMonthlyRate());
            Assert.AreEqual("Two Main Street 1800 A $102,000.00", o.ToString());

            o.IsRental = true;
            Assert.AreEqual(2000m, o.Fee);
            Assert.AreEqual(100_000m, o.Price);
            Assert.AreEqual(102_000m, o.TotalCost);
            Assert.AreEqual(1800, o.YearBuilt);
            Assert.AreEqual("A", o.UnitNumber);
            Assert.IsTrue(o.IsRental);
            Assert.AreEqual(425, o.GetMonthlyRate());
            Assert.AreEqual("Two Main Street 1800 A $425.00", o.ToString());
#if !DEBUG
});
#endif
        }

        [Test]
        [Category("Home Class")]
        public void TestIRental()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<IRental>();
            assert.Method<decimal>(
                "GetMonthlyRate",
                BindingFlags.Public |
                BindingFlags.Instance
            );

            assert.Property<bool>(
                "IsRental",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty |
                BindingFlags.SetProperty
            );
#if !DEBUG
});
#endif
        }

        [Test]
        [Category("Home Class")]
        public void TestSingleFamily()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var assert = new TypeAssert<SingleFamily>();
            assert.Extends<Home>();
            assert.NotImplements<IRental>();

            assert.Property<string>(
               "Address",
               BindingFlags.Instance |
               BindingFlags.Public |
               BindingFlags.GetProperty
            ).DeclaredIn<Home>();

            assert.Property<int>(
                "YearBuilt",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).DeclaredIn<Home>();

            assert.Property<decimal>(
                "Price",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).DeclaredIn<Home>();

            assert.Constructor(
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<string>("address"),
                new Param<int>("yearBuilt"),
                new Param<decimal>("price")
            );

            assert.NonConstructor(
                BindingFlags.Public |
                BindingFlags.Instance
            );

            assert.Property<decimal>(
                "TotalCost",
                BindingFlags.Public |
                BindingFlags.Instance |
                BindingFlags.GetProperty
            ).DeclaredIn<Home>().Override();

            assert.Method<decimal>(
                "GetRate",
                BindingFlags.Public |
                BindingFlags.Instance,
                new Param<int>("numberOfPeriods")
            ).DeclaredIn<SingleFamily>().Override();

            assert.Method<string>(
                "ToString",
                BindingFlags.Public |
                BindingFlags.Instance
            ).DeclaredIn<SingleFamily>().Override();
#if !DEBUG
});
#endif
        }

        [Test]
        [Category("Home Class")]
        public void TestSingleFamilyData()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var singleFamily = new TypeAssert<SingleFamily>();
            dynamic o;
            Catch<ArgumentOutOfRangeException>(() => singleFamily.New("One Main Street", 1799, 100_000m));
            Catch<ArgumentOutOfRangeException>(() => singleFamily.New("Two Main Street", 2000, 0m));
            o = singleFamily.New("Two Main Street", 1800, 100_000m);
            Assert.AreEqual(100_000m, o.Price);
            Assert.AreEqual(100_000m, o.TotalCost);
            Assert.AreEqual(1800, o.YearBuilt);
            Assert.AreEqual("Two Main Street 1800 $100,000.00", o.ToString());
#if !DEBUG
});
#endif
        }

        [Test]
        [Category("Home Class")]
        public void TestHomeShow()
        {
#if !DEBUG
        Assert.Multiple(() => {
#endif
            var home = new TypeAssert<Home>();
            var show = home.Method(
                "Show",
                BindingFlags.Public |
                BindingFlags.Static,
                new Param<Home[]>("homes")
                {
                    Params = true
                }
            );
            var condo = new TypeAssert<Condo>();
            var singleFamily = new TypeAssert<SingleFamily>();
            dynamic condo1, condo2;
            dynamic[] homes = {
                singleFamily.New("Two Main Street", 1800, 100_000m),
                condo1 = condo.New("One Main Street", 1900, 100_000m, "A", 2000m, false),
                condo2 = condo.New("Three Main Street", 2000, 200_000m, "A", 1000m, true),
                singleFamily.New("Four Main Street", 2010, 300_000m)
            };

            // Asserting: Home.Show(homes);
            Action showApp = () => show.Invoke(null, new object[] { homes.Cast<Home>().ToArray() });
            var actual = showApp.Run();
            actual.Assert(
                "Two Main Street 1800 $100,000.00",
                "One Main Street 1900 A $102,000.00",
                "One Main Street 1900 A $425.00",
                "Three Main Street 2000 A $201,000.00",
                "Three Main Street 2000 A $837.50",
                "Four Main Street 2010 $300,000.00"
            );
            Assert.IsFalse(condo1.IsRental, "The rental option must be reverted");
            Assert.IsTrue(condo2.IsRental, "The rental option must be reverted");
#if !DEBUG
});
#endif
        }
    }
}
