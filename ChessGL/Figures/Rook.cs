using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;

namespace ChessGL.Figures
{
    public class Rook : Figure
    {
        public Rook(bool white, Cell defaultCell = null)
        {
            Init();
            moveTypes.Add(new MoveStraight());
            this.white = white;
            this.defaultCell = defaultCell;
        }
    }
}
