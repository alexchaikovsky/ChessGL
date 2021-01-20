using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGL.Figures
{
    class CheckKing : Figure
    {
        public CheckKing(bool white, List<IMove> attackMoves)
        {
            this.white = white;
            moveTypes = attackMoves;
        }
        public override Point GetDefaultPosition()
        {
            return new Point(0,0);
        }
    }
}
