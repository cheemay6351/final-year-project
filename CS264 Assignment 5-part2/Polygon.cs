namespace CS264_Assignment_5_factoryAssignment2
{
    public class Polygon : Shape //inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        private string points;
        private string fill = ""; // shape colour
        private string stroke = ""; //outline colour
        private string strokewidth = ""; //shape thickness

        public Polygon()
        {
            this.points = "50 160 55 180 70 180 60 190 65 205 50 195 35 205 40 190 30 180 45 180";
        }
        public Polygon(string points)
        {
            this.points = points;

        }
        public void setFill(string fill)
        {
            if (fill == "")
            {
                this.fill = "orange";
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
            return "<polygon points = " + "\"" + points + "\"" + " stroke = " + "\"" + stroke + "\"" + " stroke-width = " + "\"" + strokewidth + "\"" + " fill = " + "\"" + fill + "\"" + "/>";
        }
    }
}