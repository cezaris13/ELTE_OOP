using System;

namespace Circle 
{
    public class Point
    {
        public double X {get; private set;}
        public double Y {get; private set;}

        public Point(double x, double y){
            X = x;
            Y = y;
        }

        public double Distance (Point point){
            return Math.Sqrt((X-point.X)*(X-point.X) + (Y-point.Y)*(Y-point.Y));
        }
    }
}
