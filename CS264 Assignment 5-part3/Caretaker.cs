namespace CS264_Assignment_5_factoryAssignment3 // took reference from https://www.youtube.com/watch?v=C8YDxHCPmgY&ab_channel=JohnKeating & notes.cs
{
    public class Caretaker // canvas class can be considered the caretaker (only difference is that caretaker has undo and redo)
    {
        // two lists: one for the undid items and one for the redo functions
        public List<Memento> history = new List<Memento>(); // list to store all shapes
        private List<Memento> redoList = new List<Memento>(); // list for all the stored data

        public Caretaker(Memento canvas)
        {
            history.Add(canvas);
        }

        // add, remove, draw mementos
        public void addMemento(Memento canvas)
        {
            history.Add(canvas);
        }

        public void removeMemento()
        {
            history.RemoveAt(history.Count - 1);
        }

        public String drawMemento()
        {
            return history.ToArray()[history.Count - 1].drawShapes();
        }

        public void undo() // for data to be stored - functions that were done being undone
        {
            // save item
            if (history.Count > 1) // make sure there are at least one in the list
            {
                Memento canvas = history.ToArray()[history.Count - 1]; // take off last shape

                history.RemoveAt(history.Count - 1); // removes item from history list

                redoList.Add(canvas); // adds to the redoList
            }
        }

        public void redo() // for data stored - functions that were undone being redone
        {
            // save item
            if (redoList.Count > 0) // make sure there are stuff in the redoList
            {
                Memento canvas = redoList.ToArray()[redoList.Count - 1]; // take off last shape

                redoList.RemoveAt(redoList.Count - 1); // removes item from redoList

                history.Add(canvas); // adds to history list - canvas stack
            }
        }

        public int getSize()
        {
            return history.Count; // ignore the empty canvas
        }
    }
}