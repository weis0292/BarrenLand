using Microsoft.VisualStudio.TestTools.UnitTesting;
using MikeWeispfenning.BarrenLandAnalysis.Application.Factories;
using MikeWeispfenning.BarrenLandAnalysis.Application.Interfaces;
using System;

namespace MikeWeispfenning.BarrenLandAnalysis.Tests
{
    [TestClass]
    public class RectangleFactoryTests
    {
        [TestMethod]
        public void Should_ReturnCorrectRectangle_When_RectanglePointsStringIsValid()
        {
            var rectangleFactory = new RectangleFactory();
            var pointFactory = new MockPointFactory(new Point(10, 23), new Point(34, 50));
            var rectangle = rectangleFactory.CreateRectangle(pointFactory, "10 23 34 50");

            Assert.AreEqual(10, rectangle.BottomLeft.X);
            Assert.AreEqual(23, rectangle.BottomLeft.Y);
            Assert.AreEqual(34, rectangle.BottomRight.X);
            Assert.AreEqual(23, rectangle.BottomRight.Y);
            Assert.AreEqual(34, rectangle.TopRight.X);
            Assert.AreEqual(50, rectangle.TopRight.Y);
            Assert.AreEqual(10, rectangle.TopLeft.X);
            Assert.AreEqual(50, rectangle.TopLeft.Y);
            Assert.AreEqual(24, rectangle.XLength);
            Assert.AreEqual(27, rectangle.YLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowException_When_PointsAreNull()
        {
            var rectangeFactory = new RectangleFactory();
            var rectangle = rectangeFactory.CreateRectangle(new MockPointFactory(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowException_When_PointsAreEmpty()
        {
            var rectangeFactory = new RectangleFactory();
            var rectangle = rectangeFactory.CreateRectangle(new MockPointFactory(), string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowException_When_NotEnoughPointsAreEntered()
        {
            var rectangeFactory = new RectangleFactory();
            var rectangle = rectangeFactory.CreateRectangle(new MockPointFactory(), "10 20 30");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_ThrowException_When_TooManyPointsAreEntered()
        {
            var rectangeFactory = new RectangleFactory();
            var rectangle = rectangeFactory.CreateRectangle(new MockPointFactory(), "10 20 30 40 50");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_ThrowException_When_PointFactoryIsNull()
        {
            var rectangeFactory = new RectangleFactory();
            var rectangle = rectangeFactory.CreateRectangle(null, "10 20 30 40");
        }

        [TestMethod]
        public void Should_ReturnCorrectRectangle_When_LengthAndWidthAreValid()
        {
            var rectangleFactory = new RectangleFactory();
            var pointFactory = new MockPointFactory(new Point(0, 0), new Point(30, 40));
            var rectangle = rectangleFactory.CreateRectangle(pointFactory, 30, 40);

            Assert.AreEqual(0, rectangle.BottomLeft.X);
            Assert.AreEqual(0, rectangle.BottomLeft.Y);
            Assert.AreEqual(30, rectangle.BottomRight.X);
            Assert.AreEqual(0, rectangle.BottomRight.Y);
            Assert.AreEqual(30, rectangle.TopRight.X);
            Assert.AreEqual(40, rectangle.TopRight.Y);
            Assert.AreEqual(0, rectangle.TopLeft.X);
            Assert.AreEqual(40, rectangle.TopLeft.Y);
            Assert.AreEqual(30, rectangle.XLength);
            Assert.AreEqual(40, rectangle.YLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_ThrowException_When_XIsNegative()
        {
            new RectangleFactory().CreateRectangle(new MockPointFactory(), -10, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_ThrowException_When_YIsNegative()
        {
            new RectangleFactory().CreateRectangle(new MockPointFactory(), 10, -10);
        }

        private class MockPointFactory : IPointFactory
        {
            private readonly Point[] _points;
            private int _count;

            public MockPointFactory(params Point[] points)
            {
                _points = points;
                _count = 0;
            }

            public Point CreatePoint(string xAsString, string yAsString)
            {
                return _points[_count++];
            }

            public Point CreatePoint(int x, int y)
            {
                return _points[_count++];
            }
        }
    }
}
