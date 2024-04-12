namespace CS264_Assignment_5_factoryAssignment3 // took reference from https://www.youtube.com/watch?v=C8YDxHCPmgY&ab_channel=JohnKeating & notes.cs
{
    public class Polyline : Shape // inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        String svg = ""; String poly;
        public Polyline() // default polyline
        {
            poly = "60 110 65 120 70 115 75 130 80 125 85 140 90 135 95 150 100 145";
        }

        public Polyline(String poly) // for specifying parameters for shapes
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
            svg = "<polyline points = \"" + poly + getStyles();
        }

        public override string draw()
        {
            setShapeAttribute();
            string draw = "<polyline points = \"" + poly + getStyles(); return draw;
        }
        public void shapeDrawn()
        {
            Console.WriteLine(getShapeAttribute());
            Console.WriteLine("Added Polyline (points = {0}) added ", poly, getStroke(), getFill(), getStrokeWidth());
        }
    }
}