namespace CS264_Assignment_5_factoryAssignment2
{
    public class Polyline : Shape //inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        private string points;
        private string fill = ""; // shape colour
        private string stroke = ""; // outline colour
        private string strokewidth = ""; //shape thickness

        public Polyline()
        {
            this.points = "60 110 65 120 70 115 75 130 80 125 85 140 90 135 95 150 100 145";
        }
        public Polyline(string points)
        {
            this.points = points;
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
            return "<polyline points = " + "\"" + points + "\"" + " stroke = " + "\"" + stroke + "\"" + " stroke-width = " + "\"" + strokewidth + "\"" + " fill = " + "\"" + fill + "\"" + "/>";
        }
    }

}