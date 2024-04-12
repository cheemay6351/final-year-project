namespace CS264_Assignment_4_factoryAssignment4
{
    class Circle : Shape
    {
        int cx, cy, r;

        public Circle() // default circle
        {
            cx = 50;
            cy = 50;
            r = 35;
        }

        public Circle(int cx, int cy, int r) // for specifying parametes for shapes
        {
            this.cx = cx;
            this.cy = cy;
            this.r = r;
        }

        public override string showSVG()
        {
            return "<circle cx = \"" + cx + "\" cy = \"" + cy + "\" r = \"" + r + "\" fill = \"" + getFill() + "\" stroke = \"" + getStroke() + "\" stroke-width = \"" + getStrokeWidth() + "\"/>";
        }
    }
}