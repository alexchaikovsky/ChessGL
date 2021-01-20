using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;

namespace ChessGL.Figures
{
    public class Bishop : Figure
    {
        public Bishop(bool white, Cell defaultCell = null)
        {
            Init();
            moveTypes.Add(new MoveDiag());
            this.white = white;
            this.defaultCell = defaultCell;
        }
    }
}
