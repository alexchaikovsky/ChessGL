using Microsoft.Xna.Framework;
using ChessGL.Moves;

namespace ChessGL.Figures
{
    class King : Figure, IMoveStraight, IMoveDiag
    {
        public King(bool white, Cell defaultCell)
        {
            this.white = white;
            this.defaultCell = defaultCell;
            if (white)
            {
                thisTexturePath = "white_king";
            }
            else
            {
                this.defaultPosition = new Point(100, 100);
            }
        }
    }
}
