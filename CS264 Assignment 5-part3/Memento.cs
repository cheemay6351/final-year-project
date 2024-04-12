namespace CS264_Assignment_5_factoryAssignment3 // took reference from https://www.youtube.com/watch?v=C8YDxHCPmgY&ab_channel=JohnKeating & notes.cs
{
    public class Memento
    {
        Canvas shapes;
        public Memento(Canvas shapes)
        {
            this.shapes = shapes;
        }
        public Canvas getShapes()
        {
            return this.shapes;
        }
        public String drawShapes()
        {
            return shapes.draw();
        }
    }
}