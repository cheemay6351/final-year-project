namespace CS264_Assignment_5_factoryAssignment3
{
    public class StylesFactory : Shape
    {
        public void chooseStyles(Shape s, String type)
        {
            Console.WriteLine("\nThe default styles for this {0} are: <stroke = {1}, fill = {2}, stroke-width = {3}", type.ToLower(), s.getStroke(), s.getFill(), s.getStrokeWidth() + ">");
            Console.WriteLine("Do you wish to change it?");
            if (userDecision())
            {
                Console.WriteLine("\nSet {0} styles:\n", type.ToLower());
                Console.WriteLine("stroke:");
                String stroke = Console.ReadLine();
                Console.WriteLine("\nfill:");
                String fill = Console.ReadLine();
                Console.WriteLine("\nstroke-width:");
                String strokeWidth = Console.ReadLine();

                s.setStyles(stroke, fill, strokeWidth);
            }
        }

        public void chooseLineStyles(Shape s, String type)
        {
            Console.WriteLine("\nThe default styles for this {0} are: <stroke = {1}, fill = {2}", type.ToLower(), s.getStroke(), s.getFill() + ">");
            Console.WriteLine("Do you wish to change it?");
            if (userDecision())
            {
                Console.WriteLine("\nSet {0} styles:\n", type.ToLower());
                Console.WriteLine("stroke:");
                String stroke = Console.ReadLine();
                Console.WriteLine("\nfill:");
                String fill = Console.ReadLine();

                s.setLineStyles(stroke, fill);
            }
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
    }
}