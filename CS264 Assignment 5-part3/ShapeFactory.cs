namespace CS264_Assignment_5_factoryAssignment3
{
    public class ShapeFactory // shape factory class that generates shapes that derive from shape base class
    {
        public Shape generateShape(string type) // this was referenced from the tutorial by Mark
        {
            switch (type)
            {
                case "A circle":
                    { return new Circle(); }
                case "A rectangle":
                    { return new Rectangle(); }
                case "An ellipse":
                    { return new Ellipse(); }
                case "A line":
                    { return new Line(); }
                case "A polyline":
                    { return new Polyline(); }
                case "A polygon":
                    { return new Polygon(); }
                case "A path":
                    { return new Path(); }
            }
            return null;
        }
    }
}