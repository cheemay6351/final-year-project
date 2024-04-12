namespace CS264_Assignment_5_factoryAssignment3 // took reference from https://www.youtube.com/watch?v=C8YDxHCPmgY&ab_channel=JohnKeating & notes.cs
{
    public class Line : Shape // inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        String svg = "";
        int x1, x2, y1, y2;
        public Line() // default line
        {
            x1 = 10;
            x2 = 60;
            y1 = 110;
            y2 = 80;
        }

        public Line(int x1, int x2, int y1, int y2) // for specifying parameters for shapes
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
            setShapeAttribute();
        }

        public String getShapeAttribute() // get
        {
            return svg;
        }

        public void setShapeAttribute() // set
        {
            svg = "<line x1 = \"" + x1 + "\" x2 = \"" + x2 + "\" y1 = \"" + y1 + "\" y2 = \"" + y2 + getLineStyles();
        }

        public override string draw()
        {
            setShapeAttribute();
            string draw = "<line x1 = \"" + x1 + "\" x2 = \"" + x2 + "\" y1 = \"" + y1 + "\" y2 = \"" + y2 + getLineStyles(); return draw;
        }
        public void shapeDrawn()
        {
            Console.WriteLine(getShapeAttribute());
            Console.WriteLine("Line added: (x1 = {0}, x2 = {1}, y1 = {2}, y2 = {3}) added ", x1, x2, y1, y2, getStroke(), getStrokeWidth());
        }
    }


}