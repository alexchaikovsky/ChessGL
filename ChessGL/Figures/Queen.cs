using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ChessGL;
using ChessGL.Moves;

namespace ChessGL.Figures
{
    public class Queen : Figure
    {
        public Queen(bool white)
        {
            this.white = white;
            if (white)
            {
                this.defaultPosition = new Point(100, 500);
            }
            else
            {
                this.defaultPosition = new Point(100, 100);
            }
        }
        public override bool CheckMove(Cell start, Cell end)
        {
            if (start.row - end.row == 0 || start.col - end.col == 0) return true;
            if (Math.Abs(start.row - end.row) == Math.Abs(start.col % 96 - end.col % 96)) return true;
            return false;

        }
    }
}
