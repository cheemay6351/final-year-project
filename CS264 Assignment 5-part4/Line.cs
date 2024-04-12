namespace CS264_Assignment_4_factoryAssignment4
{
    class Line : Shape
    {
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }

        public Line() // default line
        {
            x1 = 10;
            x2 = 60;
            y1 = 110;
            y2 = 80;
        }

        public Line(int x1, int y1, int x2, int y2) // for specifying parametes for shapes
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public override string showSVG()
        {
            return "<line x1 = \"" + x1 + "\" x2 = \"" + x2 + "\" y1 = \"" + y1 + "\" y2 = \"" + y2 + "\" stroke = \"" + getStroke() + "\" stroke-width = \"" + getStrokeWidth() + "\"/>";
        }
    }
}