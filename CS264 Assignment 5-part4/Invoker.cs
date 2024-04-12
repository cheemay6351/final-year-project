namespace CS264_Assignment_4_factoryAssignment4
{
    public class Invoker
    {
        private Stack<Command> undo;
        private Stack<Command> redo;

        public int UndoCount { get => undo.Count; }
        public int RedoCount { get => redo.Count; }

        public Invoker()
        {
            Reset();
        }

        public void Reset()
        {
            undo = new Stack<Command>();
            redo = new Stack<Command>();
        }

        public void Action(Command command)
        {
            // undo-redo stacks needs to be updated
            undo.Push(command);  // save command to the undo command
            redo.Clear();        // once a new command is issued, the redo stack clears

            // determine the command 'addShapeCommand' or 'deleteAllShapesCommand'
            Type t = command.GetType();
            if (t.Equals(typeof(addShapeCommand)))
            {
                command.Do();
            }
            if (t.Equals(typeof(deleteAllShapesCommand)))
            {
                command.Do();
            }
        }

        // Undo
        public void Undo()
        {
            if (undo.Count > 0) // if the undo stack has shapes inside then...
            {
                Command c = undo.Pop(); c.Undo(); redo.Push(c);
            }
            else
            {
                Console.WriteLine("\nThere are no shapes to undo.");
            }
        }

        // Redo
        public void Redo()
        {
            if (redo.Count > 0) // if the redo stack has shapes inside then...
            {
                Command c = redo.Pop(); c.Do(); undo.Push(c);
            }
            else
            {
                Console.WriteLine("\nUnable to redo anymore shapes.");
            }
        }
    }
}