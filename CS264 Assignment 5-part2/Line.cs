namespace CS264_Assignment_5_factoryAssignment2
{
    public class Line : Shape //inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        private string x1;
        private string x2;
        private string y1;
        private string y2;
        private string fill = ""; // shape colour
        private string stroke = ""; //outline colour
        private string strokewidth = ""; //shape thickness

        public Line()
        {
            this.x1 = "10";
            this.x2 = "50";
            this.y1 = "110";
            this.y2 = "150";
        }
        public Line(string x1, string x2, string y1, string y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
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
                this.stroke = "black";
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
            return "<line x1 = " + "\"" + x1 + "\"" + " y1 = " + "\"" + y1 + "\"" + " x2 = " + "\"" + x2 + "\"" + " y2 = " + "\"" + y2 + "\"" + " stroke = " + "\"" + stroke + "\"" + " stroke-width = " + "\"" + strokewidth + "\"" + " fill = " + "\"" + fill + "\"" + "/>";
        }
    }
}