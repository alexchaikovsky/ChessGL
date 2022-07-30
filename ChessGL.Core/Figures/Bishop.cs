using ChessGL.Core.Moves;

namespace ChessGL.Core.Figures
{
    public class Bishop : Figure
    {
        public Bishop(PieceColor pieceColor) : base(pieceColor, new[] {new MoveDiag()})
        {
        }
    }
}