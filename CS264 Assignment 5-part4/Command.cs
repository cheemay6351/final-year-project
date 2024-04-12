namespace CS264_Assignment_4_factoryAssignment4
{
    // most of what i have are referenced from john's provided demo command code 
    public abstract class Command
    {
        public abstract void Do(); // what happens when we execute
        public abstract void Undo(); // what happens when we unexecute
    }

    public class addShapeCommand : Command
    {
        public String command;
        public Shape shape;
        public Canvas canvas;
        public static StylesFactory styles = new StylesFactory();

        public addShapeCommand(String sh, Shape s, Canvas c)
        {
            command = sh;
            shape = s;
            canvas = c;
        }

        public override void Do() // adds a shape to the canvas as "Do" action
        {
            Random rd = new Random();
            switch (command) // user following how to input a shape --> creates a shape
            {
                case "circle":
                    Circle circle = new Circle();
                    Console.WriteLine("\nCommand recieved!\n\nCreating a circle...");
                    Console.WriteLine("Would you like to change the dimensions for your circle?");
                    if (userDecision())
                    {
                        Console.WriteLine("\ncx: ");
                        int cx = int.Parse(Console.ReadLine());
                        Console.WriteLine("\ncy:");
                        int cy = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nr:");
                        int r = int.Parse(Console.ReadLine());

                        circle = new Circle(cx, cy, r);
                    }
                    styles.chooseStyles(circle, command.ToUpper());
                    if (makeSure(circle, command.ToUpper()))
                    {
                        canvas.addShape(circle);
                    }
                    break;
                //-----------------------------------------------------------------------------
                case "rectangle":
                    Rectangle rectangle = new Rectangle();
                    Console.WriteLine("\nCommand recieved!\n\nCreating a rectangle...");
                    Console.WriteLine("Would you like to change the dimensions for your rectangle?");
                    if (userDecision())
                    {
                        Console.WriteLine("\nx: ");
                        int x = int.Parse(Console.ReadLine());
                        Console.WriteLine("\ny:");
                        int y = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nwidth:");
                        int width = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nheight:");
                        int height = int.Parse(Console.ReadLine());

                        rectangle = new Rectangle(x, y, width, height);
                    }
                    styles.chooseStyles(rectangle, command.ToUpper());
                    if (makeSure(rectangle, command.ToUpper()))
                    {
                        canvas.addShape(rectangle);
                    }
                    break;
                //-----------------------------------------------------------------------------
                case "ellipse":
                    Ellipse ellipse = new Ellipse();
                    Console.WriteLine("\nCommand recieved!\n\nCreating an ellipse...");
                    Console.WriteLine("Would you like to change the dimensions for your ellipse?");
                    if (userDecision())
                    {
                        Console.WriteLine("\nx: ");
                        int x = int.Parse(Console.ReadLine());
                        Console.WriteLine("\ny:");
                        int y = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nx2:");
                        int x2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nxy2:");
                        int y2 = int.Parse(Console.ReadLine());

                        ellipse = new Ellipse(x, y, x2, y2);
                    }
                    styles.chooseStyles(ellipse, command.ToUpper());
                    if (makeSure(ellipse, command.ToUpper()))
                    {
                        canvas.addShape(ellipse);
                    }
                    break;
                //-----------------------------------------------------------------------------
                case "line":
                    Line line = new Line();
                    Console.WriteLine("\nCommand recieved!\n\nCreating a line...");
                    Console.WriteLine("Would you like to change the dimensions for your ellipse?");
                    if (userDecision())
                    {
                        Console.WriteLine("\nx1: ");
                        int x1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("\ny1:");
                        int y1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nx2:");
                        int x2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("\ny2:");
                        int y2 = int.Parse(Console.ReadLine());

                        line = new Line(x1, y1, x2, y2);
                    }
                    styles.chooseLineStyles(line, command.ToUpper());
                    if (makeSure(line, command.ToUpper()))
                    {
                        canvas.addShape(line);
                    }
                    break;
                //-----------------------------------------------------------------------------
                case "polyline":
                    Polyline polyline = new Polyline();
                    Console.WriteLine("\nCommand recieved!\n\nCreating a polyline...");
                    Console.WriteLine("Would you like to change the dimensions for your polyline?");
                    if (userDecision())
                    {
                        Console.WriteLine("\npoly: ");
                        String poly = Console.ReadLine();

                        polyline = new Polyline(poly);
                    }
                    styles.chooseStyles(polyline, command.ToUpper());
                    if (makeSure(polyline, command.ToUpper()))
                    {
                        canvas.addShape(polyline);
                    }
                    break;
                //-----------------------------------------------------------------------------
                case "polygon":
                    Polygon polygon = new Polygon();
                    Console.WriteLine("\nCommand recieved!\n\nCreating a polygon...");
                    Console.WriteLine("Would you like to change the dimensions for your polygon?");
                    if (userDecision())
                    {
                        Console.WriteLine("\npoly: ");
                        String poly = Console.ReadLine();

                        polygon = new Polygon(poly);
                    }
                    styles.chooseStyles(polygon, command.ToUpper());
                    if (makeSure(polygon, command.ToUpper()))
                    {
                        canvas.addShape(polygon);
                    }
                    break;
                //-----------------------------------------------------------------------------
                case "path":
                    Console.WriteLine("\nCommand recieved!\n\nCreating a path...");
                    Path path = new Path();
                    Console.WriteLine("Would you like to change the dimensions for your path?");
                    if (userDecision())
                    {
                        Console.WriteLine("\npath: ");
                        String pathWay = Console.ReadLine();

                        path = new Path(pathWay);
                    }
                    styles.chooseStyles(path, command.ToUpper());
                    if (makeSure(path, command.ToUpper()))
                    {
                        canvas.addShape(path);
                    }
                    break;
                //-----------------------------------------------------------------------------
                default: Console.WriteLine("\nInvalid Input!"); shapeList(); break;
            }
        }

        public override void Undo() // remove a shape from canvas as "Undo" action
        {
            canvas.removeShape();
        }

        public static void printCommands(Canvas canvas) // just a visual list of commands
        {
            Console.WriteLine("\nCommands:");
            Console.WriteLine("H    Help - displays this message.");
            Console.WriteLine("A    Add shape to canvas.");
            Console.WriteLine("U    Undo last operation.");
            Console.WriteLine("R    Redo last operation.");
            Console.WriteLine("C    Clear canvas.");
            Console.WriteLine("D    Display current canvas.");
            Console.WriteLine("S    Save canvas.");
            Console.WriteLine("Q    Quit application.\n");
        }

        public static void shapeList() // just shows the shapes the user can create and how to create them etc.
        {
            Console.WriteLine("\nThese are the shapes you can create:");
            Console.WriteLine("Circle, Rectangle, Ellipse, Line, Polyline, Polygon, Path");
            Console.WriteLine("\nPlease type 'A <shape>' to add shapes!\n");
        }
        static bool userDecision()
        {
            Console.WriteLine("Enter 'y' for yes or 'n' for no:\n");
            String input = Console.ReadLine().ToLower();

            while (!input.Equals("y") && !input.Equals("n"))
            { // if the user input isn't 'y' or 'n', prompt user for input until correct input
                Console.WriteLine("\nPlease try again:");
                input = Console.ReadLine().ToLower();
            }

            if (input.Equals("y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool makeSure(Shape s, String type) // this method makes sure the user is ready to abandon/add shape (confirmation)
        {
            Console.WriteLine("\nSVG written for {0}", type.ToLower() + ":");
            Console.WriteLine(s.showSVG() + "\n");
            while (userDecision() == false)
            {
                Console.WriteLine("\nAbandon shape?\n");
                if (userDecision()) return false;
                Console.WriteLine("\nAdd shape?");
            }
            return true;
        }
    }

    // delete shape command - concrete command class extends Command
    public class deleteAllShapesCommand : Command
    {
        public Shape shape;
        public Canvas canvas;

        public deleteAllShapesCommand(Canvas c) // canvas gets cleared
        {
            canvas = c;
        }

        public override void Do() // remove shapes from canvas as "Do" action
        {
            canvas.clearShapes();
        }

        public override void Undo() // adds a shape to the canvas as "Undo" action
        {
            canvas.addShape(shape);
        }
    }
}