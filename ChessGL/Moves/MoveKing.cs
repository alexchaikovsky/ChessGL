using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Figures;
using ChessGL.Board;

namespace ChessGL.Moves
{
    public class MoveKing : Move, IMove
    {
        public List<Cell> ShowPath(Figure figure, List<List<Cell>> board, Cell pathStartingCell, bool show)
        {
            var path = new List<Cell>();
            int col = pathStartingCell.col % 96 - 1, row = Math.Abs(pathStartingCell.row - 8);
            int tryCol = col, tryRow = row;
            
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (!(i == row && j == col) && InBounds(i) && InBounds(j))
                    {
                        if (board[i][j].Empty || figure.CanEat(board[i][j].figure))
                        {
                            board[i][j].Show = show;
                            path.Add(board[i][j]);
                        }
                    }
                }
            }
            
            return path;
        }
    }
}
