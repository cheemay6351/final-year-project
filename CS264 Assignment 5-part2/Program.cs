// Browser: Chrome
// Operating System: Edition; Windows 11 & Home Version; 21H2
// Browser Version: Version 100.0.4896.60 (Official Build) (64-bit)
// IDE: Visual Studio Code
// Zi Wei Song - 20334601
// 05/12/2022

// I am using factory method and singleton for this assignment (add part) - this is a rework of assignment 2.

using System;
using System.IO;
using System.Collections;
namespace CS264_Assignment_5_factoryAssignment2
{
    //references from tutorial & https://developer.mozilla.org/en-US/docs/Web/SVG/Tutorial/Basic_Shapes
    class Program
    {
        public static ArrayList shapesList = new ArrayList(); // https://www.codeproject.com/Questions/1262226/Add-element-in-arraylist-from-another-method
        public static Canvas canvas = new Canvas();
        public static Shape currentShape;
        public static ShapeFactory shapeFactory = new ShapeFactory(); // use ShapeFactory to get object from concrete class
        public static StylesFactory styles = new StylesFactory();
        static void Main(string[] args) // in my main; it will display my menu and the options inside
        {
            Console.WriteLine("\nUse any of these commands:");
            Console.WriteLine("[1] Create shapes.");
            Console.WriteLine("[2] Update shapes.");
            Console.WriteLine("[3] Delete shapes.");
            Console.WriteLine("[4] Print out list.");
            Console.WriteLine("[5] Modify index.");
            Console.WriteLine("[6] Export svg.");
            Console.WriteLine("[7] Exit the app.\n");

            // doesn't necessarily need user input but user should be able to modify the shapes
            // decided to do user input to make it easier for myself
            bool close = false;
            String input = "";
            while (close == false)
            {
                input = (Console.ReadLine() + "").ToLower(); // made sure that every user input is set to lower case to make it easier
                switch (input)
                {
                    //switch statement with options so user input can input what they want to do
                    case "1": createShapes(); break;
                    case "2": updateShapes(); break;
                    case "3": deleteShapes(); break;
                    case "4": printOutList(); break;
                    case "5": modIndex(); break;
                    case "6": export(); break;
                    case "7": close = exit(); Environment.Exit(0); break;
                }
            }
        }

        static void createChoices() // this method is to list the shapes and export function
        {
            Console.WriteLine("\n[a] Create Rectangle.");
            Console.WriteLine("[b] Create Circle.");
            Console.WriteLine("[c] Create Ellipse.");
            Console.WriteLine("[d] Create Line.");
            Console.WriteLine("[e] Create Polyline.");
            Console.WriteLine("[f] Create Polygon.");
            Console.WriteLine("[g] Create Path.");
            Console.WriteLine("[m] Back to Menu.");
            Console.WriteLine("[l] Leave.\n");
        }

        static void createShapes() // this method is where the shapes are being created
        {
            canvas = new Canvas();
            shapesList = new ArrayList();
            shapeFactory = new ShapeFactory();
            styles = new StylesFactory();

            bool finish = false;
            string userChoice = "";
            createChoices(); // called my method createChoices() so it could display what the choices are after clicking 'Create Shapes'

            string userPick = "";
            while (!finish)
            { // while finish is not true, keep running
                userChoice = (Console.ReadLine() + "").ToLower(); // made sure that every user input is set to lower case to make it easier
                switch (userChoice)
                {
                    case "a":
                        Console.WriteLine("\nProcessing drawing a rectangle....");
                        Console.WriteLine("Would you like to stick with the default rectangle size?\n'y' for yes or 'n' for no\n");

                        Shape currentShape = shapeFactory.generateShape("rectangle");
                        userPick = Console.ReadLine();

                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape = shapeFactory.generateShape("rectangle");
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in 4 numbers: first being x, second being y, third being height, fourth being width.\n");
                            string x = Console.ReadLine();
                            string y = Console.ReadLine();
                            string height = Console.ReadLine();
                            string width = Console.ReadLine();
                            currentShape = new Rectangle(x, y, height, width);
                        }

                        userPick = "";
                        Console.WriteLine("\nWould you like to stick with the default rectangle colour and line thickness size?\n'y' for yes or 'n' for no\n");
                        userPick = Console.ReadLine();
                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape.setFill("");
                            currentShape.setStroke("");
                            currentShape.setStrokeWidth("");
                            Console.WriteLine("\n" + currentShape.getShapeAttribute());
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("\n" + currentShape.getShapeAttribute());
                        }
                        shapesList.Add(currentShape.getShapeAttribute());
                        break;

                    case "b":
                        Console.WriteLine("\nProcessing drawing a circle....");
                        Console.WriteLine("Would you like to stick with the default circle size?\n'y' for yes or 'n' for no\n");

                        currentShape = shapeFactory.generateShape("circle");
                        userPick = Console.ReadLine();

                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape = shapeFactory.generateShape("circle");
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in 3 numbers: first being cx, second being cy, third being radius\n");
                            string cx = Console.ReadLine();
                            string cy = Console.ReadLine();
                            string radius = Console.ReadLine();
                            currentShape = new Circle(cx, cy, radius);
                        }

                        userPick = "";
                        Console.WriteLine("\nWould you like to stick with the default circle colour and line thickness size?\n'y' for yes or 'n' for no\n");
                        userPick = Console.ReadLine();
                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape.setFill("");
                            currentShape.setStroke("");
                            currentShape.setStrokeWidth("");
                            Console.WriteLine("\n" + currentShape.getShapeAttribute());
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("\n" + currentShape.getShapeAttribute());
                        }
                        shapesList.Add(currentShape.getShapeAttribute());
                        break;

                    case "c":
                        Console.WriteLine("\nProcessing drawing an ellipse....");
                        Console.WriteLine("Would you like to stick with the default ellipse size?\n'y' for yes or 'n' for no\n");

                        currentShape = shapeFactory.generateShape("ellipse");
                        userPick = Console.ReadLine();

                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape = shapeFactory.generateShape("ellipse");
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in 4 numbers: first being cx, second being cy, third being rx, fourth being ry");
                            string cx = Console.ReadLine();
                            string cy = Console.ReadLine();
                            string rx = Console.ReadLine();
                            string ry = Console.ReadLine();
                            currentShape = new Ellipse(cx, cy, rx, ry);
                        }

                        userPick = "";
                        Console.WriteLine("\nWould you like to stick with the default ellipse colour and line thickness size?\n'y' for yes or 'n' for no\n");
                        userPick = Console.ReadLine();
                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape.setFill("");
                            currentShape.setStroke("");
                            currentShape.setStrokeWidth("");
                            Console.WriteLine("\n" + currentShape.getShapeAttribute());
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("\n" + currentShape.getShapeAttribute());
                        }
                        shapesList.Add(currentShape.getShapeAttribute());
                        break;

                    case "d":
                        Console.WriteLine("\nProcessing drawing a line...");
                        Console.WriteLine("Would you like to stick with the default ellipse size?\n'y' for yes or 'n' for no\n");

                        currentShape = shapeFactory.generateShape("line");
                        userPick = Console.ReadLine();

                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape = shapeFactory.generateShape("line");
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in 3 numbers: first being x1, second being x2, third being y1, fourth being y2");
                            string x1 = Console.ReadLine();
                            string x2 = Console.ReadLine();
                            string y1 = Console.ReadLine();
                            string y2 = Console.ReadLine();
                            currentShape = new Line(x1, x2, y1, y2);
                        }

                        userPick = "";
                        Console.WriteLine("\nWould you like to stick with the default line colour and line thickness size?\n'y' for yes or 'n' for no\n");
                        userPick = Console.ReadLine();
                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape.setFill("");
                            currentShape.setStroke("");
                            currentShape.setStrokeWidth("");
                            Console.WriteLine("\n" + currentShape.getShapeAttribute());
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("\n" + currentShape.getShapeAttribute());
                        }
                        shapesList.Add(currentShape.getShapeAttribute());
                        break;

                    case "e":
                        Console.WriteLine("\nProcessing drawing a polyline...");
                        Console.WriteLine("Would you like to stick with the default polyline size?\n'y' for yes or 'n' for no\n");

                        currentShape = shapeFactory.generateShape("polyline");
                        userPick = Console.ReadLine();

                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape = shapeFactory.generateShape("polyline");
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in the points: eg.'20, 20 40, 25 60, 40 80, 120 120, 140 200, 180'");
                            string points = Console.ReadLine();
                            currentShape = new Polyline(points);
                        }

                        userPick = "";
                        Console.WriteLine("\nWould you like to stick with the default polyline colour and line thickness size?\n'y' for yes or 'n' for no\n");
                        userPick = Console.ReadLine();
                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape.setFill("");
                            currentShape.setStroke("");
                            currentShape.setStrokeWidth("");
                            Console.WriteLine(currentShape.getShapeAttribute());
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine(currentShape.getShapeAttribute());
                        }
                        shapesList.Add(currentShape.getShapeAttribute());
                        break;

                    case "f":
                        Console.WriteLine("\nProcessing drawing a polygon...");
                        Console.WriteLine("Would you like to stick with the default polygon size?\n'y' for yes or 'n' for no\n");

                        currentShape = shapeFactory.generateShape("polygon");
                        userPick = Console.ReadLine();

                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape = shapeFactory.generateShape("polygon");
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in the points: eg.'220, 10 300, 210 170, 250 123, 234'.");
                            string points = Console.ReadLine();
                            currentShape = new Polygon(points);
                        }

                        userPick = "";
                        Console.WriteLine("\nWould you like to stick with the default polygon colour and line thickness size?\n'y' for yes or 'n' for no\n");
                        userPick = Console.ReadLine();
                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape.setFill("");
                            currentShape.setStroke("");
                            currentShape.setStrokeWidth("");
                            Console.WriteLine("\n" + currentShape.getShapeAttribute());
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("\n" + currentShape.getShapeAttribute());
                        }
                        shapesList.Add(currentShape.getShapeAttribute());
                        break;

                    case "g":
                        Console.WriteLine("\nProcessing drawing a path...");
                        Console.WriteLine("Would you like to stick with the default path size?\n'y' for yes or 'n' for no\n");

                        currentShape = shapeFactory.generateShape("path");
                        userPick = Console.ReadLine();

                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape = shapeFactory.generateShape("path");
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in the path: eg.'M150 0 L75 200 L225 200 Z'.");
                            string path = Console.ReadLine();
                            currentShape = new Path(path);
                        }

                        userPick = "";
                        Console.WriteLine("\nWould you like to stick with the default path colour and line thickness size?\n'y' for yes or 'n' for no\n");
                        userPick = Console.ReadLine();
                        if (userPick == "y") // gives user an option to choose if they want the default shape or create their own
                        {
                            currentShape.setFill("");
                            currentShape.setStroke("");
                            currentShape.setStrokeWidth("");
                            Console.WriteLine("\n" + currentShape.getShapeAttribute());
                        }
                        else if (userPick == "n")
                        {
                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("\n" + currentShape.getShapeAttribute());
                        }
                        shapesList.Add(currentShape.getShapeAttribute());
                        break;

                    case "m": // sends user back to menu
                        getMenu();
                        break;

                    case "l":
                        exit();
                        finish = true;
                        System.Environment.Exit(1); // had this so the user can completely end the program
                        break;

                    default:
                        Console.WriteLine("\nPlease try again.\n");
                        break;
                }
                userChoice = "";
                createChoices();
                //https://www.c-sharpcorner.com/UploadFile/c25b6d/CSharp-ArrayList/
                foreach (object obj in shapesList) // this is to check if the strings are actually getting stored in the arraylist
                {
                    Console.WriteLine("\n" + obj + "\n");  // as user inputs more shapes, it shows the list of shapes they currently have
                }
            }
        }


        /*originally wanted user to select which index of the arraylist they want to update; to different a different shape or specific values but decided to let user update the whole shape if they want*/
        static void updateShapes()
        {
            ArrayList shapesList1 = shapesList; // https://www.geeksforgeeks.org/copy-elements-of-one-arraylist-to-another-arraylist-in-java/
            Console.WriteLine("\nPlease choose which index of the arraylist you want to update.\ne.g. If you type in 1 then the second one on the list is to be updated.");
            foreach (object obj in shapesList1)
            { // this is to print out my list so user can see what shape they want to update
                Console.WriteLine("\n" + obj);
            }
            Console.WriteLine("");

            int index = Convert.ToInt32(Console.ReadLine()); // https://stackoverflow.com/questions/24443827/reading-an-integer-from-user-input
            if (index >= 0 && index < shapesList.Count)
            { // ensures the index number 0 or bigger than total elements of arraylist and not more than it
                Console.WriteLine("\nSelect the shape update from the shape list:\n[a] Rectangle\n[b] Circle\n[c] Ellipse\n[d] Line\n[e] Polyline\n[f] Polygon\n[g] Path\n[m] Back to Menu\n[n] Exit\n");
                bool close = false;
                string input = "";
                while (close == false) // everything is kept in a while loop
                {
                    input = (Console.ReadLine() + "").ToLower(); // user input set to lower case
                    switch (input)
                    {
                        //switch statement with options so user input can input what they want to do
                        case "a": // case 'a' lets user change their chosen shape to a rectangle
                            Console.WriteLine("\nType in 4 numbers: first being x, second being y, third being height, fourth being width.\n");
                            string x = Console.ReadLine();
                            string y = Console.ReadLine();
                            string height = Console.ReadLine();
                            string width = Console.ReadLine();
                            currentShape = new Rectangle(x, y, height, width);

                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.\n");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("");

                            string change = currentShape.getShapeAttribute();
                            shapesList1.RemoveAt(index); // the original shape at the index the user chosen is removed
                            shapesList1.Insert(index, change); // the new shape they user created is put in that index instead
                            Console.WriteLine("Your shape has been updated. Here is the list now....."); printOutList(); break;

                        case "b": // case 'b' lets user change their chosen shape to a circle
                            Console.WriteLine("\nType in 3 numbers: first being cx, second being cy, third being radius\n");
                            string cx = Console.ReadLine();
                            string cy = Console.ReadLine();
                            string radius = Console.ReadLine();
                            currentShape = new Circle(cx, cy, radius);

                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.\n");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("");

                            change = currentShape.getShapeAttribute();
                            shapesList1.RemoveAt(index); // the original shape at the index the user chosen is removed
                            shapesList1.Insert(index, change); // the new shape they user created is put in that index instead
                            Console.WriteLine("Your shape has been updated. Here is the list now....."); printOutList(); break;

                        case "c":  // case 'c' lets user change their chosen shape to an ellipse
                            Console.WriteLine("\nType in 4 numbers: first being cx, second being cy, third being rx, fourth being ry.\n");
                            cx = Console.ReadLine();
                            cy = Console.ReadLine();
                            string rx = Console.ReadLine();
                            string ry = Console.ReadLine();
                            currentShape = new Ellipse(cx, cy, rx, ry);

                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.\n");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("");

                            change = currentShape.getShapeAttribute();
                            shapesList1.RemoveAt(index); // the original shape at the index the user chosen is removed
                            shapesList1.Insert(index, change); // the new shape they user created is put in that index instead 
                            Console.WriteLine("Your shape has been updated. Here is the list now....."); printOutList(); break;

                        case "d": // case 'd' lets user change their chosen shape to a line
                            Console.WriteLine("\nType in 3 numbers: first being x1, second being x2, third being y1, fourth being y2.\n");
                            string x1 = Console.ReadLine();
                            string x2 = Console.ReadLine();
                            string y1 = Console.ReadLine();
                            string y2 = Console.ReadLine();
                            currentShape = new Line(x1, x2, y1, y2);

                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.\n");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("");

                            change = currentShape.getShapeAttribute();
                            shapesList1.RemoveAt(index); // the original shape at the index the user chosen is removed
                            shapesList1.Insert(index, change); // the new shape they user created is put in that index instead
                            Console.WriteLine("Your shape has been updated. Here is the list now....."); printOutList(); break;

                        case "e": // case 'e' lets user change their chosen shape to a polyline
                            Console.WriteLine("\nType in the points: eg.'20, 20 40, 25 60, 40 80, 120 120, 140 200, 180'.\n");
                            string points = Console.ReadLine();
                            currentShape = new Polyline(points);

                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.\n");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("");

                            change = currentShape.getShapeAttribute();
                            shapesList1.RemoveAt(index); // the original shape at the index the user chosen is removed
                            shapesList1.Insert(index, change); // the new shape they user created is put in that index instead
                            Console.WriteLine("Your shape has been updated. Here is the list now....."); printOutList(); break;

                        case "f": // case 'f' lets user change their chosen shape to a polygon
                            Console.WriteLine("\nType in the points: eg.'220, 10 300, 210 170, 250 123, 234'.\n");
                            points = Console.ReadLine();
                            currentShape = new Polygon(points);

                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.\n");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("");

                            change = currentShape.getShapeAttribute();
                            shapesList1.RemoveAt(index); // the original shape at the index the user chosen is removed
                            shapesList1.Insert(index, change); // the new shape they user created is put in that index instead
                            Console.WriteLine("Your shape has been updated. Here is the list now....."); printOutList(); break;

                        case "g": // case 'a' lets user change their chosen shape to a path
                            Console.WriteLine("\nType in the path: eg.'M150 0 L75 200 L225 200 Z'.\n");
                            string path = Console.ReadLine();
                            currentShape = new Path(path);

                            Console.WriteLine("\nType in the colour, stroke colour and stroke-width.\n");
                            styles.chooseStyles(currentShape);
                            Console.WriteLine("");

                            change = currentShape.getShapeAttribute();
                            shapesList1.RemoveAt(index); // the original shape at the index the user chosen is removed
                            shapesList1.Insert(index, change); // the new shape they user created is put in that index instead
                            Console.WriteLine("Your shape has been updated. Here is the list now....."); printOutList(); break;

                        case "m": getMenu(); break;
                        case "n": close = exit(); break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nShape is not in the list.\nSending you back to menu....."); getMenu();
            }
        }

        static void deleteShapes()
        {
            ArrayList shapesList1 = shapesList; // https://www.geeksforgeeks.org/copy-elements-of-one-arraylist-to-another-arraylist-in-java/
            foreach (object obj in shapesList1) // this is to print out my list so user can see what shape they want to update
            {
                Console.WriteLine("\n" + obj + "\n");
            }

            if (shapesList1.Count > 0)
            {
                Console.WriteLine("\nPlease choose which shape you want to delete.\ne.g. If you type in 1 then the second one on the list is to be deleted");
                int index = Convert.ToInt32(Console.ReadLine()); // https://stackoverflow.com/questions/24443827/reading-an-integer-from-user-input
                if (index > shapesList1.Count)
                { // ensures the index number is not bigger that the actual total number of elements in the arraylist
                    Console.WriteLine("\nIndex not in the array list.");
                    getMenu();
                }
                else
                {
                    shapesList.RemoveAt(index); // remove the shape at index __ in my arraylist
                    Console.WriteLine("\nThe elements in ArrayList are:\n"); // displaying the elements in ArrayList
                    foreach (string str in shapesList1)
                    {
                        Console.WriteLine(str + "\n");
                    }
                    getMenu();
                }
            }
            else
            { //arraylist has no elements
                Console.WriteLine("\nYou have no elements in your list.\nGoing back to menu.....");
                getMenu();
            }
        }

        static void printOutList() // this method prints out the list of shapes
        {   // creating a whole new arraylist and set it to original arraylist so it can have contents from createShapes() method
            ArrayList shapesList1 = shapesList; // https://www.geeksforgeeks.org/copy-elements-of-one-arraylist-to-another-arraylist-in-java/
            if (shapesList1.Count > 0)
            { // if the arraylist has elements
                foreach (object obj in shapesList1) // this is to print out my list
                {
                    Console.WriteLine("\n" + obj + "\n");
                }
                getMenu();
            }
            else
            { //arraylist has no elements
                Console.WriteLine("\nYou have no elements in your list.\nGoing back to menu.....");
                getMenu();
            }
        }

        static void export()
        { // this method outputs your arraylist into an svg file
            ArrayList shapesList1 = shapesList;
            string shapes = "";
            for (int i = 0; i < shapesList.Count; i++)
            {
                shapes = shapesList[i].ToString();
                Console.WriteLine(shapesList1[i]);
            }
            Console.WriteLine("\nPlease name your file...\n"); // allow user to name their own svg file 
            string fileName = Console.ReadLine();

            //var file = new FileStream(@"./Assignment.svg", FileMode.OpenOrCreate);
            var file = new FileStream(@"./" + fileName + ".svg", FileMode.OpenOrCreate); // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-create-a-file-or-folder
            var standardOutput = Console.Out;
            StreamWriter writer = new StreamWriter(file);
            Console.SetOut(writer);
            using (writer)
            {
                // canvas start https://jenkov.com/tutorials/svg/svg-viewport-view-box.html
                String start = "<?xml version = \"1.0\" standalone = \"no\"?>\n<svg width = \"1000\" height = \"1000\" version = \"1.1\" viewBox = \"0 0 200 200\" xmlns = \"http://www.w3.org/2000/svg\">";
                Console.WriteLine(start);
                for (int i = 0; i < shapesList1.Count; i++) // what is inside my arraylist is inserted into my svg file
                {
                    shapes = shapesList1[i].ToString();
                    Console.WriteLine(shapesList1[i]);
                }
                String end = "</svg>";
                Console.WriteLine(end); // output svg file
                writer.Close();
                Environment.Exit(1);
            }
        }

        static void getMenu() // this method is merely calling the createShapes() method so it could show the user the commands they could choose
        {
            Console.WriteLine("\nUse any of these commands:");
            Console.WriteLine("[1] Create shapes.");
            Console.WriteLine("[2] Update shapes.");
            Console.WriteLine("[3] Delete shapes.");
            Console.WriteLine("[4] Print out list.");
            Console.WriteLine("[5] Modify index.");
            Console.WriteLine("[6] Export svg.");
            Console.WriteLine("[7] Exit the app.\n");

            //doesn't necessarily need user input but user should be able to modify the shapes
            //decided to do user input to make it easier for myself
            bool close = false;
            String input = "";
            while (close == false)
            {
                input = (Console.ReadLine() + "").ToLower(); // anything the user types in will be set to lower case
                switch (input)
                {
                    //switch statement with options so user input can input what they want to do
                    case "1": createShapes(); break;
                    case "2": updateShapes(); break;
                    case "3": deleteShapes(); break;
                    case "4": printOutList(); break;
                    case "5": modIndex(); break;
                    case "6": export(); break;
                    case "7": close = exit(); Environment.Exit(0); break;
                }
            }
        }

        static bool exit() // this method allows the user to exit the program
        {
            Console.WriteLine("\nOkay see you next time!!!\n");
            return true;
        }

        //don't forget to include z-index information about all shapes on the canvas
        public static ArrayList swap(ArrayList shapesList1, String a, String b) //place in order a first then b
        {
            shapesList1 = shapesList;
            for (int i = 0; i < shapesList1.Count; i++) //z-index is the CSS property that controls the stacking order of overlapping elements on a page
            {
                if (shapesList1[i].Equals(a))
                {
                    Console.WriteLine(shapesList1[i] + " = " + a);
                    shapesList1[i] = b;
                }
                else if (shapesList1[i].Equals(b))
                {
                    Console.WriteLine(shapesList1[i] + " = " + b);
                    shapesList1[i] = a;
                }
            }
            return shapesList1;
        }
        //user should be able to modify any shape's z index
        static void modIndex() // this method allows user to input two indexes; first index being the shape the users wants moved and the lather being the new position for that shape
        {
            ArrayList shapesList1 = shapesList;
            Console.WriteLine("\nYour current list looks like this....");
            foreach (object obj in shapesList1) // this is to print out my list
            {
                Console.WriteLine("\n" + obj + "\n");
            }
            if (shapesList1.Count >= 2)
            { // made sure that there are 2 or more strings in my arraylist so the modify z-index can actually work
                Console.WriteLine("\nFrom the list, swap any shape from one position to another in the list.\nPlease type in an index number for the shape you want to have transferred.");
                int index1 = Convert.ToInt32(Console.ReadLine()); // https://stackoverflow.com/questions/24443827/reading-an-integer-from-user-input --> takes in integer
                string indexString1 = shapesList1[index1].ToString();
                Console.WriteLine("\nPlease type in an index number for the shape you want to be transferred to in the list.\n");
                int index2 = Convert.ToInt32(Console.ReadLine()); // https://stackoverflow.com/questions/24443827/reading-an-integer-from-user-input --> takes in integer
                string indexString2 = shapesList1[index2].ToString();

                shapesList1 = swap(shapesList1, indexString1, indexString2); // called swap method
                Console.WriteLine("\nYour new list is looking like this....."); printOutList();
                getMenu();
            }
            else
            { // arraylist has no elements
                Console.WriteLine("\nYou don't have enough elements in your list.\nGoing back to menu.....");
                getMenu();
            }
        }
    }
}