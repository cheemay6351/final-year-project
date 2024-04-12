namespace CS264_Assignment_5_factoryAssignment3 // took reference from https://www.youtube.com/watch?v=C8YDxHCPmgY&ab_channel=JohnKeating & notes.cs
{
    public class Canvas
    {
        public Stack<Shape> canvas = new Stack<Shape>(); // stack to store all shapes
        private Stack<Shape> undo = new Stack<Shape>(); // stack for undo stuff
        int width, height;

        public Canvas() // default canvas size
        {
            width = 500;
            height = 500;
        }

        public Canvas(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public Shape undoShape()
        {
            // mentioned in the tutorial: 
            // whenever you remove a shape from a canvas,
            // you have to make sure to add it to undo stack --> the information is saved for any redos later
            if (canvas.Count > 0)
            {
                Shape s = removeShape(); undo.Push(s);
                Console.WriteLine("\nShape undone: " + s.draw());
                return s;
            }
            Console.WriteLine("\nThere is nothing to undo");
            return new Shape();
        }

        public void redoShape()
        {
            // when you redo, push it back into the canvas 
            // undo only if the stack has something
            if (undo.Count == 0)
            {
                Console.WriteLine("\nThere is nothing to redo.");
                // Shape s = undo.Pop();
                // Console.WriteLine("\nShape redone: " + s.draw());
                // canvas.Push(s);
            }
            else
            {
                Shape s = undo.Pop();
                Console.WriteLine("\nShape redone: " + s.draw());
                canvas.Push(s);
            }
        }

        // getters
        public int getHeight()
        {
            return this.height;
        }

        public int getWidth()
        {
            return this.width;
        }

        public int getSize()
        {
            return canvas.Count;
        }

        // setters
        public void setHeight(int height)
        {
            this.height = height;
        }

        public void setWidth(int width)
        {
            this.width = width;
        }

        // add, remove, delete all, draw
        public void addShape(Shape s)
        {
            Console.WriteLine("\nShape added to canvas: {0}", s.draw()); // in place of {0}, it displays the svg shape --> https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            undo = new Stack<Shape>();
            canvas.Push(s);
        }

        public Shape removeShape() // remove a shape
        {
            Shape s = canvas.Pop();
            Console.WriteLine("\nShape has been removed from canvas: {0}", s.draw());
            return s;
        }

        public void deleteAllShapes() // canvas gets cleared
        {
            canvas.Clear();
        }

        public string draw() // draw the shapes onto canvas
        {
            String drawnShape = "<svg width = \"" + 1000 + "\" height = \"" + 1000 + "\" version = \"1.1\" xmlns = \"http://www.w3.org/2000/svg\">";
            for (int i = (getSize() - 1); i >= 0; i--)
            {
                drawnShape += "\n" + canvas.ToArray()[i].draw(); // shapes in list being drawn onto the canvas
            }

            drawnShape += "\n</svg>";
            return drawnShape;
        }
    }
}