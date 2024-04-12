namespace CS264_Assignment_5_factoryAssignment3 // took reference from https://www.youtube.com/watch?v=C8YDxHCPmgY&ab_channel=JohnKeating & notes.cs
{
    public class Polygon : Shape // inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        String svg = ""; String poly;
        public Polygon() // default polygon
        {
            poly = "50 160 55 180 70 180 60 190 65 205 50 195 35 205 40 190 30 180 45 180";
        }

        public Polygon(String poly) // for specifying parameters for shapes
        {
            this.poly = poly;
            setShapeAttribute();
        }

        public String getShapeAttribute() // get
        {
            return svg;
        }

        public void setShapeAttribute() // set
        {
            svg = "<polygon points = \"" + poly + getStyles();
        }

        public override string draw()
        {
            setShapeAttribute();
            string draw = "<polygon points = \"" + poly + getStyles(); return draw;
        }
        public void shapeDrawn()
        {
            Console.WriteLine(getShapeAttribute());
            Console.WriteLine("Polygon added: (points = {0}) added ", poly, getStroke(), getFill(), getStrokeWidth());
        }
    }
}