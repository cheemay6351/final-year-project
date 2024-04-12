namespace CS264_Assignment_4_factoryAssignment4
{
    class Path : Shape
    {
        public String path { get; set; }

        public Path() // default path
        {
            path = "M20,230 Q40,205 50,230 T90,230";
        }

        public Path(String path) // for specifying parametes for shapes
        {
            this.path = path;
        }

        public override string showSVG()
        {
            return "<path d = \"" + path + "\" stroke = \"" + getStroke() + "\" stroke-width = \"" + getStrokeWidth() + "\" fill = \"" + getFill() + "\"/>";
        }
    }
}