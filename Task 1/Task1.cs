using System;

    public class Task1
    {

        public static void Main(string[] args)
        {
            // Create some geometric figures
            Point p1 = new Point(0, 0);
            Point p2 = new Point(3, 4);
            Line l1 = new Line(p1, p2);
            Circle c1 = new Circle(new Point(0, 0), 5);

            // Move and rotate the figures
            p1.Move(1, 1);
            l1.Rotate(Math.PI / 2);
            c1.Move(-2, 3);

            // Create an aggregation of figures
            List<GeometricFigure> figures = new List<GeometricFigure> { p1, l1, c1 };
            Aggregation agg = new Aggregation(figures);

            // Move and rotate the aggregation
            agg.Move(2, 2);
            agg.Rotate(Math.PI / 4);

            // Print information about the figures and aggregation
            Console.WriteLine("Point p1: ({0}, {1})", p1.X, p1.Y);
            Console.WriteLine("Line l1 start: ({0}, {1})", l1.Start.X, l1.Start.Y);
            Console.WriteLine("Line l1 end: ({0}, {1})", l1.End.X, l1.End.Y);
            Console.WriteLine("Circle c1 center: ({0}, {1})", c1.Center.X, c1.Center.Y);
            Console.WriteLine("Circle c1 radius: {0}", c1.Radius);
        }


        // GeometricFigure class is an abstract base class for all geometric figures
        public abstract class GeometricFigure
        {
            public abstract void Move(double dx, double dy);
            public abstract void Rotate(double angle);
        }

        // Point class represents a point in 2D space
        public class Point : GeometricFigure
        {
            public double X { get; private set; }  // X coordinate
            public double Y { get; private set; }  // Y coordinate

            // Constructor to initialize X and Y coordinates
            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            // Implementation of Move method to move the point by a specified amount in X and Y directions
            public override void Move(double dx, double dy)
            {
                X += dx;
                Y += dy;
            }

            // Implementation of Rotate method to rotate the point around the origin by a specified angle in radians
            public override void Rotate(double angle)
            {
                double cosAngle = Math.Cos(angle);
                double sinAngle = Math.Sin(angle);
                double xNew = X * cosAngle - Y * sinAngle;
                double yNew = X * sinAngle + Y * cosAngle;
                X = xNew;
                Y = yNew;
            }
        }

        // Line class represents a line segment in 2D space
        public class Line : GeometricFigure
        {
            public Point Start { get; private set; }   // Starting point of the line
            public Point End { get; private set; }     // Ending point of the line

            // Constructor to initialize starting and ending points
            public Line(Point start, Point end)
            {
                Start = start;
                End = end;
            }

            // Implementation of Move method to move the line by a specified amount in X and Y directions
            public override void Move(double dx, double dy)
            {
                Start.Move(dx, dy);
                End.Move(dx, dy);
            }

            // Implementation of Rotate method to rotate the line around the origin by a specified angle in radians
            public override void Rotate(double angle)
            {
                Start.Rotate(angle);
                End.Rotate(angle);
            }
        }

        // Circle class represents a circle in 2D space
        public class Circle : GeometricFigure
        {
            public Point Center { get; private set; }  // Center point of the circle
            public double Radius { get; private set; } // Radius of the circle

            // Constructor to initialize center point and radius
            public Circle(Point center, double radius)
            {
                Center = center;
                Radius = radius;
            }

            // Implementation of Move method to move the circle by a specified amount in X and Y directions
            public override void Move(double dx, double dy)
            {
                Center.Move(dx, dy);
            }

            // Implementation of Rotate method to rotate the circle around the origin by a specified angle in radians
            public override void Rotate(double angle)
            {
                Center.Rotate(angle);
            }
        }

        // Aggregation class represents an aggregation of multiple geometric figures
        public class Aggregation : GeometricFigure
        {
            private List<GeometricFigure> _figures; // List of geometric figures

            // Constructor to initialize the list of geometric figures
            public Aggregation(List<GeometricFigure> figures)
            {
                _figures = figures;
            }

            // Implementation of Move method to move all the figures in the aggregation by a specified amount in X and Y directions
            public override void Move(double dx, double dy)
            {
                foreach (GeometricFigure figure in _figures)
                {
                    figure.Move(dx, dy);
                }
            }

            // Implementation of Rotate method to rotate all the figures in the aggregation around the origin by a specified angle in radians
            public override void Rotate(double angle)
            {
                foreach (GeometricFigure figure in _figures)
                {
                    figure.Rotate(angle);
                }
            }
        }


    }

 

