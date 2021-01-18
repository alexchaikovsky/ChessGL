using ChessGL.Moves;
using Microsoft.Xna.Framework;
using System;

namespace ChessGL.Figures
{
    public class Queen : Figure, IMoveStraight, IMoveDiag
    {
        public Queen(bool white, Cell defaultCell = null)
        {
            this.white = white;
            this.defaultCell = defaultCell;
        }
        public override bool CheckMove(Cell start, Cell end)
        {
            if (start.row - end.row == 0 || start.col - end.col == 0) return true;
            if (Math.Abs(start.row - end.row) == Math.Abs(start.col % 96 - end.col % 96)) return true;
            return false;

        }
    }
}
