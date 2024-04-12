namespace CS264_Assignment_4_factoryAssignment4
{
    class Ellipse : Shape
    {
        public int x { get; set; }
        public int y { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public Ellipse() // default ellipse
        {
            x = 75;
            y = 75;
            x2 = 20;
            y2 = 5;
        }

        public Ellipse(int x, int y, int x2, int y2) // for specifying parametes for shapes
        {
            this.x = x;
            this.y = y;
            this.x2 = x2;
            this.y2 = y2;
        }

        public override string showSVG()
        {
            return "<ellipse cx = \"" + x + "\" cy = \"" + y + "\" rx = \"" + x2 + "\" ry = \"" + y2 + "\" stroke = \"" + getStroke() + "\" stroke-width = \"" + getStrokeWidth() + "\" fill = \"" + getFill() + "\"/>";
        }
    }
}