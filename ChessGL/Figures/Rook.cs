using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;

namespace ChessGL.Figures
{
    public class Rook : Figure, IMoveStraight
    {
        public Rook(bool white, Cell defaultCell = null)
        {
            this.white = white;
            this.defaultCell = defaultCell;
        }
    }
}
