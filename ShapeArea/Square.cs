namespace ShapeArea
{
    public class Square : Shape
    {       
        public double Side { get; set; }
        
        public override double calculateArea()
        {
            double area = Side * Side;
            return area;
        }
    }
}
