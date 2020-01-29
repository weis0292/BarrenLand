using Microsoft.VisualStudio.TestTools.UnitTesting;
using MikeWeispfenning.BarrenLandAnalysis.Application.Factories;
using System;

namespace MikeWeispfenning.BarrenLandAnalysis.Tests
{
    [TestClass]
    public class PointFactoryTests
    {
        [TestMethod]
        public void Should_ReturnCorrectPoint_When_XStringAndYStringAreValid()
        {
            var pointFactory = new PointFactory();
            var point = pointFactory.CreatePoint("12", "25");
            Assert.AreEqual(12, point.X);
            Assert.AreEqual(25, point.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowArgumentException_When_XStringIsValidAndYStringIsNull()
        {
            var pointFactory = new PointFactory();
            var point = pointFactory.CreatePoint("15", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowArgumentException_When_XStringIsNullAndYStringIsValid()
        {
            var pointFactory = new PointFactory();
            var point = pointFactory.CreatePoint(null, "34");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowArgumentException_When_XStringIsNotANumberAndYStringIsValid()
        {
            var pointFactory = new PointFactory();
            var point = pointFactory.CreatePoint("abc", "34");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowArgumentException_When_XStringIsValidAndYStringIsNotANumber()
        {
            var pointFactory = new PointFactory();
            var point = pointFactory.CreatePoint("24", "abc");
        }
    }
}
