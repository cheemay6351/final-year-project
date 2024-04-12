namespace CS264_Assignment_4_factoryAssignment4
{
    class Rectangle : Shape
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public Rectangle() // default rectangle
        {
            x = 10;
            y = 10;
            width = 30;
            height = 30;
        }

        public Rectangle(int x, int y, int width, int height) // for specifying parametes for shapes
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public override string showSVG()
        {
            return "<rect x = \"" + x + "\" y = \"" + y + "\" width = \"" + width + "\" height = \"" + height + "\" fill = \"" + getFill() + "\" stroke = \"" + getStroke() + "\" stroke-width = \"" + getStrokeWidth() + "\"/>";
        }
    }
}