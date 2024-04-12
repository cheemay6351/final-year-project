namespace CS264_Assignment_5_factoryAssignment3 // took reference from https://www.youtube.com/watch?v=C8YDxHCPmgY&ab_channel=JohnKeating & notes.cs
{
    public class Ellipse : Shape // inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        String svg = "";
        int x, y, x2, y2;
        public Ellipse() // default ellipse
        {
            x = 75;
            y = 75;
            x2 = 20;
            y2 = 5;
        }

        public Ellipse(int x, int y, int x2, int y2) // for specifying parameters for shapes
        {
            this.x = x;
            this.y = y;
            this.x2 = x2;
            this.y2 = y2;
            setShapeAttribute();
        }

        public String getShapeAttribute() // get
        {
            return svg;
        }

        public void setShapeAttribute() // set
        {
            svg = "<ellipse cx = \"" + x + "\" cy = \"" + y + "\" rx = \"" + x2 + "\" ry = \"" + y2 + getStyles();
        }

        public override string draw()
        {
            setShapeAttribute();
            string draw = "<ellipse cx = \"" + x + "\" cy = \"" + y + "\" rx = \"" + x2 + "\" ry = \"" + y2 + getStyles(); return draw;
        }

        public void setLineStroke()
        {
            setShapeAttribute();
        }

        public void shapeDrawn() // when adding shape into canvas, this line pops up
        {
            Console.WriteLine(getShapeAttribute());
            Console.WriteLine("Ellipse added: (cx = {0}, cy = {1}, rx = {2}, ry = {3}) added ", x, y, x2, y2, getStroke(), getFill(), getStrokeWidth());
        }
    }
}