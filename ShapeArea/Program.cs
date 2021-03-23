using System;
using System.Collections.Generic;

namespace ShapeArea
{
    class Program
    {
        static void Main(string[] args)
        {
            IShapeData db;
            db = new InMemoryShapeData();
            var shapes = db.GetAllShapes();

            Console.WriteLine("Welcome to the Shape Area app!");

            ShowAvailableOptions(shapes);

            var option = GetUserInputForOption();
            if (option == -1)
            {
                Console.WriteLine("Have a nice day! Bye-bye");
                return;
            }
            var theSelectedShape = ProcessUserRequest(option, shapes);
            DisplayAreaOfShape(theSelectedShape);

        }

        private static void ShowAvailableOptions(IEnumerable<Shape> shapes)
        {
            Console.WriteLine("Please select the Id of the Shape you'd like to calculate the area");
            Console.WriteLine("----------------------------------------\n");
            var header = string.Format("{0, -5} {1, -20}", "Id", "Name");
            Console.WriteLine(header);
            Console.WriteLine("----------------------------------------");
            foreach (var shape in shapes)
            {
                var option = string.Format("{0, -5} {1, -20}", shape.Id, shape.Name);
                Console.WriteLine(option);
            }
            Console.WriteLine("----------------------------------------\n");
        }

        private static int GetUserInputForOption()
        {
            Console.Write("Please enter the shape Id or 'q' to quit, and then press Enter: ");
            
            var userInput = Console.ReadLine();
            // in case the user enter a "q" or "Q"
            if ("q".Equals(userInput.ToLower()))
            {
                return -1;
            }
            int integerEntered;
            // ensure an integer was entered by the user
            while (!int.TryParse(userInput, out integerEntered))
            {                
                Console.Write("Please enter the shape Id or 'q' to quit, and then press Enter: ");
                userInput = Console.ReadLine();                
            }
            return integerEntered;

        }

        private static Shape ProcessUserRequest(int shapeIdEntered, IEnumerable<Shape> shapes)
        {
            var isValidShapeId = false;            

            while (!isValidShapeId)
            {
                foreach (var shape in shapes)
                {
                    // check if the entered shape Id is available
                    if (shapeIdEntered == shape.Id)
                    {                        
                        isValidShapeId = true;
                        break;
                    }
                }

                if (!isValidShapeId)
                {
                    Console.WriteLine("The shape Id is unavailable.");
                    GetUserInputForOption();
                }                
            }
            return ProcessShapeId(shapeIdEntered);
        }

        private static Shape ProcessShapeId(int shapeId)
        {
            Shape selectedShape = null;
            switch(shapeId)
            {
                case 1:
                    Rectangle rectangle = new Rectangle();
                    rectangle.Length = GetUserInputForDouble(shapeId, "Length");
                    rectangle.Width = GetUserInputForDouble(shapeId, "Width");
                    selectedShape = (Shape) rectangle;
                    break;
                case 2:
                    Square square = new Square();
                    square.Side = GetUserInputForDouble(shapeId, "Side");
                    selectedShape = (Shape)square;
                    break;
                case 3:
                    Circle circle = new Circle();
                    circle.Radius = GetUserInputForDouble(shapeId, "Radius");
                    selectedShape = (Shape)circle;
                    break;
                case 4:
                    Triangle triangle = new Triangle();
                    triangle.SideOne = GetUserInputForDouble(shapeId, "side One");
                    triangle.SideTwo = GetUserInputForDouble(shapeId, "side Two");
                    triangle.SideThree = GetUserInputForDouble(shapeId, "side Three");
                    selectedShape = (Shape)triangle;
                    break;
                default:
                    break;
            }
            return selectedShape;
        }

        private static double GetUserInputForDouble(int shapeId, string inputFor)
        {
            double doubleEntered;
            var shape = "";
            switch(shapeId)
            {
                case 1: shape = "Rectangle"; break;
                case 2: shape = "Squre"; break;
                case 3: shape = "Circle"; break;
                case 4: shape = "Triangle"; break;
                default: shape = "Unknown"; break;
            }
            Console.Write($"Please enter the {inputFor} for {shape}, and then press Enter: ");

            var userInput = Console.ReadLine();
            // ensure a double was entered by the user
            while (!double.TryParse(userInput, out doubleEntered))
            {
                Console.Write($"Please enter the {inputFor} for {shape}, and then press Enter: ");
                userInput = Console.ReadLine();
            }
            return doubleEntered;            
        }

        private static void DisplayAreaOfShape(Shape shape)
        {
            var area = shape.calculateArea();

            Console.WriteLine("=================================================");
            Console.WriteLine($"The area of your selected shape is: {area:#.##}");

        }
    }
}
