// Browser: Chrome
// Operating System: Edition; Windows 11 & Home Version; 21H2
// Browser Version: Version 100.0.4896.60 (Official Build) (64-bit)
// IDE: Visual Studio Code
// Zi Wei Song - 20334601
// 05-12-2022 

// I am using factory method and singleton for this assignment - this is a rework of assignment 3.

using System;
using System.IO;
using System.Collections.Generic;
namespace CS264_Assignment_5_factoryAssignment3 // took reference from https://www.youtube.com/watch?v=C8YDxHCPmgY&ab_channel=JohnKeating & notes.cs
{
    // https://www.codeguru.com/csharp/c-sharp-reference-types/ <----- this website help deal with nullables
    class Program
    {
        public static Caretaker mementoCanvas = new Caretaker(new Memento(new Canvas()));
        public static ShapeFactory shapeFactory = new ShapeFactory();
        public static StylesFactory styles = new StylesFactory();
        static void Main(string[] args)
        {
            Canvas canvas = new Canvas();

            Console.WriteLine("\nWelcome to the app!\nCanvas created - use commands to add shapes to the canvas.");
            printCommands(canvas); // print the commands

            String input = "";
            bool end = false;
            while (end == false)
            {
                input = Console.ReadLine().ToUpper();
                switch (input) // using switch statement - user gets to choose which commands they want to use
                {
                    case "H": printCommands(canvas); break;
                    case "A": canvas = addShape(canvas); printCommands(canvas); break;
                    case "U": undo(canvas); printCommands(canvas); break;
                    case "R": redo(canvas); printCommands(canvas); break;
                    case "C":
                        Console.WriteLine("\nAre you sure you wanna clear the canvas?");
                        if (userDecision())
                        {
                            canvas.deleteAllShapes();
                            mementoCanvas.addMemento(new Memento(canvas)); // memento canvas information after getting deleted is saved
                        }
                        Console.WriteLine("\nCanvas has been cleared.");
                        printCommands(canvas); break;
                    case "D":
                        Console.WriteLine("\nDisplaying canvas...\n\n" + canvas.draw() + "\n");
                        printCommands(canvas); break;
                    case "S": outputFile(canvas); break;
                    case "Q": end = true; break;
                    default: Console.WriteLine("Ensure you type 'H', 'A', 'U', 'R', 'C', 'D', 'S' or 'Q' to proceed."); break;
                }
            }
            Console.WriteLine("\nGoodbye!\n");

            if (File.Exists("Program.svg")) System.IO.File.WriteAllText("Program.svg", canvas.draw());
        }

        //https://www.tutorialsteacher.com/csharp/csharp-if-else#:~:text=C%23%20if%20Statement,will%20be%20executed%2C%20otherwise%20not.
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

        public static Canvas addShape(Canvas canvas) // add shape method
        {
            shapeList();
            String command = "";
            bool end = false;
            while (end == false)
            {
                command = Console.ReadLine();
                switch (command) // user following how to input a shape --> creates a shape
                {
                    case "A circle": addCircle(canvas); shapeList(); break;
                    case "A rectangle": addRectangle(canvas); shapeList(); break;
                    case "An ellipse": addEllipse(canvas); shapeList(); break;
                    case "A line": addLine(canvas); shapeList(); break;
                    case "A polyline": addPolyline(canvas); shapeList(); break;
                    case "A polygon": addPolygon(canvas); shapeList(); break;
                    case "A path": addPath(canvas); shapeList(); break;
                    case "n": end = true; break;
                    default: Console.WriteLine("\nEnsure you are typing 'A' as uppercase.\n"); break;
                }
            }
            return canvas;
        }
        // undo-redo functionalities using memento
        public static void undo(Canvas canvas)
        {
            if (canvas.getSize() > 0)
            { // if the canvas is not empty, do undo
                canvas.undoShape(); mementoCanvas.undo();
            }
            else
            {
                Console.WriteLine("\nThere is nothing to undo.");
            }
        }

        public static void redo(Canvas canvas)
        {
            canvas.redoShape(); mementoCanvas.redo(); // if it ins't redo could be done and the redo function used is saved into mementoCanvas()
        }

        public static bool makeSure(Shape s, String type) // this method makes sure the user is ready to abandon/add shape (confirmation)
        {
            Console.WriteLine("\nSVG written for {0}", type.ToLower() + ":");
            Console.WriteLine(s.draw() + "\n");
            while (userDecision() == false)
            {
                Console.WriteLine("\nAbandon shape?\n");
                if (userDecision()) return false;
                Console.WriteLine("\nAdd shape?");
            }
            return true;
        }

        public static void addCircle(Canvas canvas) // function to add a circle
        {
            Console.WriteLine("\nCreating a circle...");
            shapeFactory = new ShapeFactory();
            Shape circle = shapeFactory.generateShape("A circle"); // use of factory
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
            styles.chooseStyles(circle, "Circle");
            if (makeSure(circle, "Circle"))
            {
                canvas.addShape(circle);
            }
        }

        public static void addRectangle(Canvas canvas) // function to add a rectangle
        {
            Console.WriteLine("\nCreating a rectangle...");
            shapeFactory = new ShapeFactory();
            Shape rectangle = shapeFactory.generateShape("A rectangle"); // use of factory
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
            styles.chooseStyles(rectangle, "Rectangle");
            if (makeSure(rectangle, "Rectangle"))
            {
                canvas.addShape(rectangle);
            }
        }

        public static void addEllipse(Canvas canvas) // creating an ellipse
        {
            Console.WriteLine("\nCreating an ellipse...");
            shapeFactory = new ShapeFactory();
            Shape ellipse = shapeFactory.generateShape("An ellipse"); // use of factory
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
            styles.chooseStyles(ellipse, "Ellipse");
            if (makeSure(ellipse, "Ellipse"))
            {
                canvas.addShape(ellipse);
            }
        }
        public static void addLine(Canvas canvas) // creating a line
        {
            Console.WriteLine("\nCreating a line...");
            shapeFactory = new ShapeFactory();
            Shape line = shapeFactory.generateShape("A line"); // use of factory
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
            styles.chooseLineStyles(line, "Line");
            if (makeSure(line, "Line"))
            {
                canvas.addShape(line);
            }
        }
        public static void addPolyline(Canvas canvas) // creating a polyline
        {
            Console.WriteLine("\nCreating a polyline...");
            shapeFactory = new ShapeFactory();
            Shape polyline = shapeFactory.generateShape("A polyline"); // use of factory
            Console.WriteLine("Would you like to change the dimensions for your polyline?");
            if (userDecision())
            {
                Console.WriteLine("\npoly: ");
                String poly = Console.ReadLine();

                polyline = new Polyline(poly);
            }
            styles.chooseStyles(polyline, "Polyline");
            if (makeSure(polyline, "Polyline"))
            {
                canvas.addShape(polyline);
            }
        }

        public static void addPolygon(Canvas canvas) // creating a polygon
        {
            Console.WriteLine("\nCreating a polygon...");
            shapeFactory = new ShapeFactory();
            Shape polygon = shapeFactory.generateShape("A polygon"); // use of factory
            Console.WriteLine("Would you like to change the dimensions for your polygon?");
            if (userDecision())
            {
                Console.WriteLine("\npoly: ");
                String poly = Console.ReadLine();

                polygon = new Polygon(poly);
            }
            styles.chooseStyles(polygon, "Polygon");
            if (makeSure(polygon, "Polygon"))
            {
                canvas.addShape(polygon);
            }
        }

        public static void addPath(Canvas canvas) // creating a path
        {
            Console.WriteLine("\nCreating a path...");
            shapeFactory = new ShapeFactory();
            Shape path = shapeFactory.generateShape("A path"); // use of factory
            Console.WriteLine("Would you like to change the dimensions for your path?");
            if (userDecision())
            {
                Console.WriteLine("\npath: ");
                String pathWay = Console.ReadLine();

                path = new Path(pathWay);
            }
            styles.chooseStyles(path, "Path");
            if (makeSure(path, "Path"))
            {
                canvas.addShape(path);
            }
        }

        public static void shapeList() // just shows the shapes the user can create
        {
            Console.WriteLine("\nThese are the shapes you can create:");
            Console.WriteLine("Circle, Rectangle, Ellipse, Line, Polyline, Polygon, Path");
            Console.WriteLine("\nPlease type 'A/An <shape>' OR Type 'n' to go back to list of commands.\n");
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

        public static void outputFile(Canvas canvas)
        {
            Console.WriteLine("\nPlease name your file...\n"); // allow user to name their own svg file 
            string fileName = Console.ReadLine();

            // https://stackoverflow.com/questions/44235689/how-to-overwrite-a-file-if-it-already-exists - overwrites file if it already exists
            var file = new FileStream(@"./" + fileName + ".svg", FileMode.OpenOrCreate); // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-create-a-file-or-folder
            StreamWriter writer = new StreamWriter(file);
            using (writer)
            {
                Console.SetOut(writer);
                Console.WriteLine(canvas.draw());
                writer.Close();
                Environment.Exit(1);
            }
        }

    }
}
