namespace CS264_Assignment_4_factoryAssignment4
{
    class Polygon : Shape
    {
        public String poly { get; set; }

        public Polygon() // default polygon
        {
            poly = "50 160 55 180 70 180 60 190 65 205 50 195 35 205 40 190 30 180 45 180";
        }

        public Polygon(String poly) // for specifying parametes for shapes
        {
            this.poly = poly;
        }

        public override string showSVG()
        {
            return "<polygon points = \"" + poly + "\" stroke = \"" + getStroke() + "\" stroke-width = \"" + getStrokeWidth() + "\" fill = \"" + getFill() + "\"/>";
        }
    }
}