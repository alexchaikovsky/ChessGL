using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;

namespace ChessGL.Figures
{
    class Knight : Figure
    {
        public Knight(bool white, Cell defaultCell = null)
        {
            Init();
            moveTypes.Add(new MoveKnight());
            this.white = white;
            this.defaultCell = defaultCell;
        }
    }
}
