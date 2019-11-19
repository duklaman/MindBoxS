using System;
using FiguresArea.FigureBase;
using FiguresArea.Helpers;

namespace FiguresArea.Figures
{
    public class Triangle : IFigureBase
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;
        private readonly int _doubleTolerance;

        public Triangle(double sideA, double sideB, double sideC, int doubleTolerance = 1)
        {
            if (sideA <= 0) throw new ArgumentOutOfRangeException(nameof(sideA) , $"{nameof(sideA)} cannot be less than 0!");
            if (sideB <= 0) throw new ArgumentOutOfRangeException(nameof(sideB) , $"{nameof(sideB)} cannot be less than 0!");
            if (sideC <= 0) throw new ArgumentOutOfRangeException(nameof(sideC) , $"{nameof(sideC)} cannot be less than 0!");
            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
                throw new Exception($"Rectangle with sides {sideA}, {sideB}, {sideC} is not exist!");
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
            _doubleTolerance = doubleTolerance;
        }
        public double Area()
        {
            var semiPerimeter = (_sideA + _sideB + _sideC) / 2;
            var area = Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));

            if(double.IsInfinity(area)) throw new Exception("Can't calculate area, result is out of range!");
            return area;
        }

        public bool IsTriangleRightAngled()
        {
            if (_sideA > _sideB && _sideA >_sideC)
            {
                return (_sideC * _sideC + _sideB * _sideB).HasMinimalDifference(_sideA * _sideA, _doubleTolerance);
            }
            if (_sideB > _sideA && _sideB > _sideC)
            {
                return (_sideA * _sideA + _sideC * _sideC).HasMinimalDifference(_sideB * _sideB, _doubleTolerance);
            }

            return (_sideA * _sideA + _sideB * _sideB).HasMinimalDifference(_sideC * _sideC, _doubleTolerance);
        }

    }
}
