using System;

namespace Circle
{
    public class Circle
    {
        public double Radius { get; private set; }
        public Point  Point { get; private set;}


        public Circle(Point point, double radius) {
            if (radius < 0)
            {
                throw new WrongRadiusException();
            }
            Radius = radius;
            Point = point;
        }

        public bool Contains(Point point) {
            return this.Point.Distance(point) <= this.Radius;
        }
    }
    
    public class WrongRadiusException : Exception {
        
    }
}
