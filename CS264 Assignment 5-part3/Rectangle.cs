namespace CS264_Assignment_5_factoryAssignment3 // took reference from https://www.youtube.com/watch?v=C8YDxHCPmgY&ab_channel=JohnKeating & notes.cs
{
    public class Rectangle : Shape // inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        String svg = "";
        int x, y, width, height;
        public Rectangle() // default rectangle
        {
            x = 10;
            y = 10;
            width = 30;
            height = 30;
        }

        public Rectangle(int x, int y, int width, int height) // for specifying parametes for shapes
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            setShapeAttribute();
        }

        public String getShapeAttribute() // get
        {
            return svg;
        }

        public void setShapeAttribute() // set
        {
            svg = "<rect x = \"" + x + "\" y = \"" + y + "\" width = \"" + width + "\" height = \"" + height + getStyles();
        }

        public override string draw()
        {
            setShapeAttribute();
            string draw = "<rect x = \"" + x + "\" y = \"" + y + "\" width = \"" + width + "\" height = \"" + height + getStyles(); return draw;
        }
        public void shapeDrawn()
        {
            Console.WriteLine(getShapeAttribute());
            Console.WriteLine("Rectangle added: (x = {0}, y = {1}, width = {2}, height = {3}) added ", x, y, width, height, getStroke(), getFill(), getStrokeWidth());
        }
    }
}