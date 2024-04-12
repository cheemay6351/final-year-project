namespace CS264_Assignment_5_factoryAssignment2
{
    public class Ellipse : Shape //inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        private string cx; //circle x
        private string cy;//circle y
        private string rx; //radius x
        private string ry;
        private string fill = ""; // shape colour
        private string stroke = ""; //outline colour
        private string strokewidth = ""; //shape thickness

        public Ellipse()
        {
            this.cx = "75";
            this.cy = "75";
            this.rx = "20";
            this.ry = "10";
        }
        public Ellipse(string cx, string cy, string rx, string ry)
        {
            this.cx = cx;
            this.cy = cy;
            this.rx = rx;
            this.ry = ry;
        }
        public void setFill(string fill)
        {
            if (fill == "")
            {
                this.fill = "blue";
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
            return "<ellipse cx = " + "\"" + cx + "\"" + " cy = " + "\"" + cy + "\"" + " rx = " + "\"" + rx + "\"" + " ry = " + "\"" + ry + "\"" + " stroke = " + "\"" + stroke + "\"" + " stroke-width = " + "\"" + strokewidth + "\"" + " fill = " + "\"" + fill + "\"" + "/>";
        }
    }
}
