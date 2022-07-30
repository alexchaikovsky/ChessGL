using ChessGL.Core.Board;
using ChessGL.Core.Figures;

namespace ChessGL.Core
{
    public interface IMove
    {
        List<Cell> ShowPath(Figure figure, List<List<Cell>> board, Cell pathStartingCell, bool show = true);
    }
}
