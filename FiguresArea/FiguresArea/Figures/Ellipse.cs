using System;
using FiguresArea.FigureBase;

namespace FiguresArea.Figures
{
    public class Ellipse : IFigureBase
    {
        private readonly double _radiusMax;
        private readonly double _radiusMin;

        public Ellipse(double radiusMax, double radiusMin)
        {
            if (radiusMax <= 0) throw new ArgumentOutOfRangeException(nameof(radiusMax) , $"{nameof(radiusMax)} cannot be less than 0!");
            if (radiusMin <= 0) throw new ArgumentOutOfRangeException(nameof(radiusMin) , $"{nameof(radiusMin)} cannot be less than 0!");
            _radiusMax = radiusMax;
            _radiusMin = radiusMin;
        }

        public double Area()
        {
            var area = Math.PI * _radiusMax * _radiusMin;

            if (double.IsInfinity(area)) throw new Exception($"Can't calculate area, result is out of range!");
            return area;
        }
    }
}
