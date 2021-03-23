namespace ShapeArea
{
    public abstract class Shape 
    {
        public int Id { get;  set; }
        public string Name { get; set; }

        public abstract double calculateArea();        
    }
}
