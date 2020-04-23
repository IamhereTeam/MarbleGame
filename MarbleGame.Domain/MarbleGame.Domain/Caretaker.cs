using System;
using System.Linq;
using System.Collections.Generic;

namespace MarbleGame.Domain
{
    public class Caretaker
    {
        private List<IBoardMemento> _mementos = new List<IBoardMemento>();

        private IBoard _board = null;

        public Caretaker(IBoard board)
        {
            this._board = board;
        }

        public void Backup()
        {
            this._mementos.Add(this._board.Save());
        }

        public void Undo()
        {
            if (this._mementos.Count == 0)
            {
                return;
            }

            var memento = this._mementos.Last();
            this._mementos.Remove(memento);

            try
            {
                this._board.Restore(memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
        }
    }
}