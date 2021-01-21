using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Figures;
using ChessGL.Board;
namespace ChessGL.Moves
{
    public interface IMove
    {
        List<Cell> ShowPath(Figure figure, List<List<Cell>> board, Cell pathStartingCell, bool show = true);
    }
}
