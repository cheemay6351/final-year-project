// Browser: Chrome
// Operating System: Edition; Windows 11 & Home Version; 21H2
// Browser Version: Version 100.0.4896.60 (Official Build) (64-bit)
// IDE: Visual Studio Code
// Zi Wei Song - 20334601
// 05-12-2022

// I am using factory method and singleton for this assignment (add part) - this is a rework of assignment 4.

namespace CS264_Assignment_4_factoryAssignment4
{
    // https://www.codeguru.com/csharp/c-sharp-reference-types/ <-- this website help deal with nullables
    class Program
    {
        static void Main(string[] args)
        {
            Canvas canvas = new Canvas();
            Invoker user = new Invoker();
            ShapeFactory shapeFactory = new ShapeFactory();

            printCommands(canvas); // print the commands

            bool end = true;
            String input = "";
            while (end)
            {
                input = Console.ReadLine().ToUpper();
                String shape = "";
                while (input.Length >= 2) // whilst the user input length is equal or more than 2
                {
                    if (input.Contains("A") || input.Contains("a")) // https://www.geeksforgeeks.org/c-sharp-substring-method/ <--- ensures the shape's first character is lowercase
                    {
                        shape = input.Substring(2); // if user input is "A circle" then the shape is "circle"
                        input = input.Substring(0, 1).ToUpper(); // if user input "a circle" then set first character to uppercase
                        shape = shape.Substring(0, 1).ToLower() + shape.Substring(1).ToLower(); // set the first character of shape "circle" to uppercase leaving the rest to lowercase
                        Console.WriteLine(shape);
                    }
                    else
                    {
                        Console.WriteLine("Try again next time :3");
                        Environment.Exit(0);
                    }
                }

                switch (input) // using switch - user gets to choose which commands they want to use
                {
                    case "H": printCommands(canvas); break;
                    case "A": user.Action(new addShapeCommand(shape, shapeFactory.generateShape(shape), canvas)); printCommands(canvas); break;
                    case "U": user.Undo(); printCommands(canvas); break;
                    case "R": user.Redo(); printCommands(canvas); break;
                    case "C": user.Action(new deleteAllShapesCommand(canvas)); Console.WriteLine("\nCanvas has been cleared."); printCommands(canvas); break;
                    case "D": Console.WriteLine("\nDisplaying canvas...\n\n" + canvas.drawShape() + "\n"); printCommands(canvas); break;
                    case "S": outputFile(canvas); break;
                    case "Q": end = false; break;
                    default: Console.WriteLine("\nPlease try again:\n"); break;
                }
            }
            Console.WriteLine("\nGoodbye!");

            if (File.Exists("Program.svg")) System.IO.File.WriteAllText("Program.svg", canvas.drawShape());
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

        public static void outputFile(Canvas canvas) // export canvas to svg
        {
            Console.WriteLine("\nPlease name your file...\n"); // allow user to name their own svg file 
            string fileName = Console.ReadLine();

            // https://stackoverflow.com/questions/44235689/how-to-overwrite-a-file-if-it-already-exists - overwrites file if it already exists
            var file = new FileStream(@"./" + fileName + ".svg", FileMode.OpenOrCreate); // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-create-a-file-or-folder
            var standardOutput = Console.Out;
            StreamWriter writer = new StreamWriter(file);
            using (writer)
            {
                Console.SetOut(writer);
                Console.WriteLine(canvas.drawShape()); // canvas getting drawn into file
                writer.Close();
                Environment.Exit(1);
            }
        }
    }
}