using System;
using System.Collections.Generic;
//contract for what each shape class must have/contain

namespace CS264_Assignment_5_factoryAssignment2
{
    public interface Shape
    {
        void setFill(string fill);
        void setStroke(string stroke);
        void setStrokeWidth(string strokewidth);
        string getShapeAttribute(); //returns the svg string to get added into the list
    }
}