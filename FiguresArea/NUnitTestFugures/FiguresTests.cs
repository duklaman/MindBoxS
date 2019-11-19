using System;
using System.Collections.Generic;
using FiguresArea.FigureBase;
using NUnit.Framework;
using FiguresArea.Figures;

namespace NUnitTestFigures
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCircleWrongArg()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var circle = new Circle(-1);
                });

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var circle = new Circle(0);
                });

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var circle = new Circle(double.MinValue);
                });

                Assert.Throws<Exception>(() =>
                {
                    var circle = new Circle(double.MaxValue);
                    circle.Area();
                } , "Can't calculate area, result is out of range!");


            });
            
        }

        [Test]
        public void TestCircleGoodCase()
        {
            Assert.Multiple(() =>
            {
                var circle1 = new Circle(1);

                Assert.AreEqual(circle1.Area() , Math.PI);

            });

        }

        [Test]
        public void TestTriangleWrongArg()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var triangle = new Triangle(-1 , 1 , 1);
                });

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var triangle = new Triangle(1, -1, 1);
                });

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var triangle = new Triangle(1, 1, -1);
                });

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var triangle = new Triangle(0 , 1 , 1);
                });

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var triangle = new Triangle(1, 0, 1);
                });

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var triangle = new Triangle(1, 1, 0);
                });

                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var triangle = new Triangle(double.MinValue , double.MinValue , double.MinValue);
                });

                Assert.Throws<Exception>(() =>
                {
                    var triangle = new Triangle(1, 1, 2);
                } , "Rectangle with sides 1, 1, 1 is not exist!");

                Assert.Throws<Exception>(() =>
                {
                    var triangle = new Triangle(double.MaxValue , double.MaxValue , double.MaxValue);
                    triangle.Area();
                }, "Can't calculate area, result is out of range!");

            });

        }

        [Test]
        public void TestTriangleGoodCase()
        {
            Assert.Multiple(() =>
            {
                var triangle1 = new Triangle(3 , 4 , 5);

                Assert.AreEqual(triangle1.Area(), 6);

                Assert.True(triangle1.IsTriangleRightAngled());

                var triangle2 = new Triangle(6, 25, 29);

                Assert.AreEqual(triangle2.Area(), 60);

                Assert.False(triangle2.IsTriangleRightAngled());

            });

        }

        /// <summary>
        /// Test for eval areas of different figures
        /// </summary>
        [Test]
        public void TestMultiFigures()
        {
            var triangle1 = new Triangle(3, 4, 5);
            var circle1 = new Circle(1);

            List<IFigureBase> figures = new List<IFigureBase> {triangle1, circle1};

            foreach (var figure in figures)
            {
                figure.Area();
            }
        }
    }
}