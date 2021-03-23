namespace ShapeArea
{
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public override double calculateArea()
        {
            double area = Length * Width;
            return area;
        }
    }
}
