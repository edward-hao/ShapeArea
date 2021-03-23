using System.Collections.Generic;

namespace ShapeArea
{
    internal interface IShapeData
    {
        IEnumerable<Shape> GetAllShapes();
    }
}