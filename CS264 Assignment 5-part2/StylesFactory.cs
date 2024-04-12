using System;
namespace CS264_Assignment_5_factoryAssignment2
{
    public class StylesFactory // code extracted from og assignment 2 here to make it look much cleaner since all shapes have access to this method
    {
        public static Shape currentShape;
        public void chooseStyles(Shape currentShape2)
        {
            // ensure that the currentShape == curentShape because we don't want to have a seperate shape with nothing for the styles
            currentShape = currentShape2;

            string fillColour = Console.ReadLine();
            string strokeColour = Console.ReadLine();
            string strokeSize = Console.ReadLine();
            currentShape.setFill(fillColour);
            currentShape.setStroke(strokeColour);
            currentShape.setStrokeWidth(strokeSize);
        }
    }
}