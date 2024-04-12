namespace CS264_Assignment_5_factoryAssignment3 // took reference from https://www.youtube.com/watch?v=C8YDxHCPmgY&ab_channel=JohnKeating & notes.cs
{
    public class Path : Shape // inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        String svg = ""; String path;
        public Path() // default path
        {
            path = "M20,230 Q40,205 50,230 T90,230";
        }

        public Path(String path) // for specifying parameters for shapes
        {
            this.path = path;
            setShapeAttribute();
        }

        public String getShapeAttribute() // get
        {
            return svg;
        }

        public void setShapeAttribute() // set
        {
            svg = "<path d = \"" + path + getStyles();
        }

        public override string draw()
        {
            setShapeAttribute();
            string draw = "<path d = \"" + path + getStyles(); return draw;
        }
        public void shapeDrawn()
        {
            Console.WriteLine(getShapeAttribute());
            Console.WriteLine("Added Path (d = {0}) added ", path, getStroke(), getFill(), getStrokeWidth());
        }
    }
}