using System;
using System.Collections; // arraylist
namespace CS264_Assignment_5_factoryAssignment2
{
    //best to inherit from a general shape
    public class Canvas
    {
        public ArrayList shapesList { get; set; }
        public string shape;
        public Canvas()
        {
            this.shapesList = shapesList;
        }
        public void AddShape(string shape)
        {
            shapesList.Add(shape);
            this.shapesList = shapesList;
        }
        public void ShapesDrawnList()
        {
            foreach (var shape in shapesList)
            {
                Console.WriteLine(shape);
            }
        }
        public void DeleteAllShapes()
        {
            shapesList.Clear();
            this.shapesList = shapesList;
        }
    }
}
