namespace CS264_Assignment_5_factoryAssignment2
{
    public class Path : Shape //inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        private string path;
        private string fill = ""; // shape colour
        private string stroke = ""; //outline colour
        private string strokewidth = ""; //shape thickness

        public Path()
        {
            this.path = "M20,230 Q40,205 50,230 T90,230";
        }
        public Path(string path)
        {
            this.path = path;
        }
        public void setFill(string fill)
        {
            if (fill == "")
            {
                this.fill = "green";
            }
            else
            {
                this.fill = fill;
            }
        }
        public void setStroke(string stroke)
        {
            if (stroke == "")
            {
                this.stroke = "brown";
            }
            else
            {
                this.stroke = stroke;
            }
        }
        public void setStrokeWidth(string strokewidth)
        {
            if (strokewidth == "")
            {
                this.strokewidth = "1";
            }
            else
            {
                this.strokewidth = strokewidth;
            }
        }
        public string getShapeAttribute()
        {
            //svg representation
            return "<path d = " + "\"" + path + "\"" + " stroke = " + "\"" + stroke + "\"" + " stroke-width = " + "\"" + strokewidth + "\"" + " fill = " + "\"" + fill + "\"" + "/>";
        }
    }

}