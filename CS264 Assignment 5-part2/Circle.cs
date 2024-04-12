namespace CS264_Assignment_5_factoryAssignment2
{
    public class Circle : Shape //inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        private string cx;
        private string cy;
        private string r; // radius
        private string fill = ""; // shape colour
        private string stroke = ""; // outline colour
        private string strokewidth = ""; // stroke thickness

        public Circle() // default circle
        {
            this.cx = "25";
            this.cy = "75";
            this.r = "20";
        }
        public Circle(string cx, string cy, string r) // if user wants to input......
        {
            this.cx = cx;
            this.cy = cy;
            this.r = r;
        }
        public void setFill(string fill) // default colour is 'yellow'
        {
            if (fill == "")
            {
                this.fill = "pink";
            }
            else
            {
                this.fill = fill;
            }
        }
        public void setStroke(string stroke) // default stroke colour is 'black'
        {
            if (stroke == "")
            {
                this.stroke = "black";
            }
            else
            {
                this.stroke = stroke;
            }
        }
        public void setStrokeWidth(string strokewidth) // default stroke thickness is '2'
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
            // svg representation
            return "<circle cx = " + "\"" + cx + "\"" + " cy = " + "\"" + cy + "\"" + " r = " + "\"" + r + "\"" + " stroke = " + "\"" + stroke + "\"" + " stroke-width = " + "\"" + strokewidth + "\"" + " fill = " + "\"" + fill + "\"" + "/>";
        }
    }
}
