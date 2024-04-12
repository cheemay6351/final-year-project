namespace CS264_Assignment_4_factoryAssignment4
{
    public class Canvas // canvas is required to store and display the shapes that are created from addShapesCommand
    {
        private Stack<Shape> canvas = new Stack<Shape>(); // stack to store all shapes

        public void addShape(Shape s) // add shape to canvas
        {
            canvas.Push(s);
            Console.WriteLine("\nShape added to canvas: {0}", s.showSVG()); // in place of {0}, it displays the svg shape --> https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
        }

        public Shape removeShape() // remove the shape from canvas
        {
            Shape s = canvas.Pop();
            Console.WriteLine("\nShape has been removed from canvas: {0}", s.showSVG());
            return s;
        }

        public Canvas()
        {
            Console.WriteLine("\nWelcome to the app!\nCanvas created - use commands to add shapes to the canvas.");
        }

        public string drawShape() // draw the shapes onto canvas
        {
            String drawnShape = "<svg width = \"" + 1000 + "\" height = \"" + 1000 + "\" version = \"1.1\" xmlns = \"http://www.w3.org/2000/svg\">";
            for (int i = (canvas.Count() - 1); i >= 0; i--)
            {
                drawnShape += "\n" + canvas.ToArray()[i].showSVG(); // shapes in list being drawn onto the canvas
            }

            drawnShape += "\n</svg>";
            return drawnShape;
        }

        public void clearShapes() // clears canvas
        {
            canvas.Clear();
        }
    }
}