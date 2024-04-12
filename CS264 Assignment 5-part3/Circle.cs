namespace CS264_Assignment_5_factoryAssignment3 // took reference from https://www.youtube.com/watch?v=C8YDxHCPmgY&ab_channel=JohnKeating & notes.cs
{
    public class Circle : Shape // inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        String svg = "";
        int cx, cy, r;

        public Circle() // default circle
        {
            cx = 50;
            cy = 50;
            r = 35;
        }

        public Circle(int cx, int cy, int r) // for specifying parameters for shapes
        {
            this.cx = cx;
            this.cy = cy;
            this.r = r;
            setShapeAttribute();
        }

        public String getShapeAttribute() // get
        {
            return svg;
        }

        public void setShapeAttribute() // set
        {
            svg = "<circle cx = \"" + cx + "\" cy = \"" + cy + "\" r = \"" + r + getStyles();
        }

        public override String draw()
        {
            setShapeAttribute();
            String draw = "<circle cx = \"" + cx + "\" cy = \"" + cy + "\" r = \"" + r + getStyles(); return draw;
        }

        public void shapeDrawn() // when adding shape into canvas, this line pops up
        {
            Console.WriteLine(getShapeAttribute());
            Console.WriteLine("Circle added: (x = {0}, y = {1}, r = {2}) added ", cx, cy, r, getStroke(), getFill(), getStrokeWidth());
        }
    }
}