using System;

namespace ShapeArea
{
    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double calculateArea()
        {                        
            return Math.PI * Radius * Radius;
        }
    }
}
