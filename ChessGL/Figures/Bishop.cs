using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;

namespace ChessGL.Figures
{
    public class Bishop : Figure, IMoveDiag
    {
        public Bishop(bool white, Cell defaultCell = null)
        {
            this.white = white;
            this.defaultCell = defaultCell;
        }
    }
}
