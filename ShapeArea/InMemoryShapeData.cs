using System.Collections.Generic;

namespace ShapeArea
{
    public class InMemoryShapeData : IShapeData
    {
        List<Shape> shapes;

        public InMemoryShapeData()
        {
            shapes = new List<Shape>()
            {
                new Rectangle
                {
                    Id = 1,
                    Name = "Rectangle"
                },
                new Square
                {
                    Id = 2,
                    Name = "Square"
                },
                new Circle
                {
                    Id = 3,
                    Name = "Circle"
                }
                //TODO: to be added onto the list of options
                //,
                //new Triangle
                //{
                //    Id = 4,
                //    Name = "Triangle"
                //}
            };
        }
        public IEnumerable<Shape> GetAllShapes()
        {
            return shapes;
        }
    }
}
