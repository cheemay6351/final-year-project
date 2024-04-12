using System;
namespace CS264_Assignment_5_factoryAssignment2
{
    public class Rectangle : Shape //inheritance https://www.programiz.com/csharp-programming/inheritance#:~:text=In%20C%23%2C%20inheritance%20allows%20us,derived%20class%20(child%20or%20subclass)
    {
        public string x { get; set; }
        public string y { get; set; }
        public string width;
        public string height;
        public string fill; // shape colour
        public string stroke; // outline colour
        public string strokewidth; // stroke thickness

        public Rectangle() // default rectangle
        {
            this.x = "10";
            this.y = "10";
            this.height = "10";
            this.width = "10";
        }
        public Rectangle(string x, string y, string width, string height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void setFill(string fill) // default colour is 'yellow'
        {
            if (fill == "")
            {
                this.fill = "black";
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
                this.stroke = "yellow";
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
                this.strokewidth = "2";
            }
            else
            {
                this.strokewidth = strokewidth;
            }
        }
        public string getShapeAttribute()
        {
            // svg representation
            return "<rect x = " + "\"" + x + "\"" + " y = " + "\"" + y + "\"" + " height = " + "\"" + height + "\"" + " width = " + "\"" + width + "\"" + " stroke = " + "\"" + stroke + "\"" + " stroke-width = " + "\"" + strokewidth + "\"" + " fill = " + "\"" + fill + "\"" + "/>";
        }
    }
}