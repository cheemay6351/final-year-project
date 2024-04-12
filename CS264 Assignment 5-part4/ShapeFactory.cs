namespace CS264_Assignment_4_factoryAssignment4
{
    public class ShapeFactory // shape factory class that generates shapes that derive from shape base class
    {
        public Shape generateShape(string type)
        {
            switch (type)
            {
                case "circle":
                    { return new Circle(); }
                case "rectangle":
                    { return new Rectangle(); }
                case "ellipse":
                    { return new Ellipse(); }
                case "line":
                    { return new Line(); }
                case "polyline":
                    { return new Polyline(); }
                case "polygon":
                    { return new Polygon(); }
                case "path":
                    { return new Path(); }
            }
            return null;
        }
    }
}