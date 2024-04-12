namespace CS264_Assignment_4_factoryAssignment4
{
    class Polyline : Shape
    {
        public String poly { get; set; }

        public Polyline() // default polyline
        {
            poly = "60 110 65 120 70 115 75 130 80 125 85 140 90 135 95 150 100 145";
        }

        public Polyline(String poly) // for specifying parametes for shapes
        {
            this.poly = poly;
        }

        public override string showSVG()
        {
            return "<polyline points = \"" + poly + "\" stroke = \"" + getStroke() + "\" stroke-width = \"" + getStrokeWidth() + "\" fill = \"" + getFill() + "\"/>";
        }
    }
}