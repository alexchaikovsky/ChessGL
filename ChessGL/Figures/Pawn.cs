using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;

namespace ChessGL.Figures
{
    class Pawn : Figure
    {
        public Pawn(bool white)
        {
            this.white = white;
            if (white)
            {
            }
            else
            {
                thisTexturePath = "black_pawn";
            }
        }
        public override bool CheckMove(Cell start, Cell end)
        {
            if (start.row - end.row == -1)
            {
                return (start.col - end.col == 0 && end.Empty) || (Math.Abs(start.col - end.col) == 1 && !end.Empty);
            }
            return false;
           
        }
    }
}
