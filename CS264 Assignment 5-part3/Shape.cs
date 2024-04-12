namespace CS264_Assignment_5_factoryAssignment3 // took reference from https://www.youtube.com/watch?v=C8YDxHCPmgY&ab_channel=JohnKeating & notes.cs
{
    public class Shape
    {
        string stroke = "2", fill = "blue", strokeWidth = "3";
        public virtual string draw() // override the svg file of that shape
        {
            return "";
        }

        // getters
        public string getStyles()
        {
            return "\" stroke = \"" + this.stroke + "\" fill = \"" + this.fill + "\" stroke-width = \"" + this.strokeWidth + "\"/>";
        }

        public string getLineStyles() // this is for line shape specifically as they are lines and have no need for fill
        {
            return "\" stroke = \"" + this.stroke + "\" stroke-width = \"" + this.strokeWidth + "\"/>";
        }

        public string getStroke()
        {
            return this.stroke;
        }

        public string getFill()
        {
            return this.fill;
        }

        public string getStrokeWidth()
        {
            return this.strokeWidth;
        }

        // setters
        public void setStyles(string stroke, string fill, string strokeWidth)
        {
            this.stroke = stroke;
            this.fill = fill;
            this.strokeWidth = strokeWidth;
        }

        public void setLineStyles(string stroke, string strokeWidth) // this is for line shape specifically as they are lines and have no need for fill
        {
            this.stroke = stroke;
            this.strokeWidth = strokeWidth;
        }

        public void setDefaultStroke()
        {
            this.stroke = "green";
        }
    }
}