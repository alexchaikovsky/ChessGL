using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;

namespace ChessGL.Figures
{
    class Knight : Figure, IMoveKnight
    {
        public Knight(bool white, Cell defaultCell = null)
        {
            this.white = white;
            this.defaultCell = defaultCell;
        }
    }
}
