using ChessGL.Core.Board;
using ChessGL.Core.Figures;

namespace ChessGL.Core.Moves
{
    public class MoveStraight : Move, IMove
    {
        public List<Cell> ShowPath(Figure figure, List<List<Cell>> board, Cell pathStartingCell, bool show)
        {
            int col = pathStartingCell.col % 96 - 1, row = Math.Abs(pathStartingCell.row - 8);
            var path = new List<Cell>();
 
            for (var i = col + 1; i < 8; i++) //moveleft
            {
                if (figure.CanMoveOnCell(board[row][i]))
                {
                    path.Add(board[row][i]);
                }
            }
            
            for (int i = col - 1; i >= 0; i--) //moveright
            {
                if (figure.CanMoveOnCell(board[row][i]))
                {
                    path.Add(board[row][i]);
                }
            }
            for (int i = row + 1; i < 8; i++) //moveup
            {
                if (figure.CanMoveOnCell(board[i][col]))
                {
                    path.Add(board[i][col]);
                }
            }
            
            for (int i = row - 1; i >= 0; i--) //movedowm
            {
                if (figure.CanMoveOnCell(board[i][col]))
                {
                    path.Add(board[i][col]);
                }
            }
            return path;
        }
        
    }
}
