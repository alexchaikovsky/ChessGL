using ChessGL.Core.Moves;

namespace ChessGL.Core.Figures
{
    public class Rook : Figure
    {
        public Rook(PieceColor pieceColor) : base(pieceColor, new[] {new MoveStraight()})
        {
        }
    }
}