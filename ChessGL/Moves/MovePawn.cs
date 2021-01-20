using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Figures;

namespace ChessGL.Moves
{
    public class MovePawn : Move, IMove
    {
        public List<Cell> ShowPath(Figure figure, List<List<Cell>> board, Cell pathStartingCell, bool show)
        {
            var path = new List<Cell>();
            int col = pathStartingCell.col % 96 - 1, row = Math.Abs(pathStartingCell.row - 8);

            int pathRow = row, pathCol = col;

            if (!figure.white)
            {
                if (figure.GetDefaultPosition() == pathStartingCell.Position)
                {
                    if (board[row + 2][col].Empty && board[row + 1][col].Empty)
                    {
                        board[row + 2][col].Show = show;
                        path.Add(board[row + 2][col]);
                    }
                }
                if (Move.InBounds(++pathRow))
                {
                    if (Move.InBounds(col + 1) && !board[pathRow][col + 1].Empty && figure.CanEat(board[pathRow][col + 1].figure))
                    {
                        board[pathRow][col + 1].Show = show;
                        path.Add(board[pathRow][col + 1]);
                    }
                    if (Move.InBounds(col - 1) && !board[pathRow][col - 1].Empty && figure.CanEat(board[pathRow][col - 1].figure))
                    {
                        board[pathRow][col - 1].Show = show;
                        path.Add(board[pathRow][col - 1]);
                    }
                    if (Move.InBounds(col) && board[pathRow][col].Empty)
                    {
                        board[pathRow][col].Show = show;
                        path.Add(board[pathRow][col]);
                    }
                }
            }
            else
            {
                if (figure.GetDefaultPosition() == pathStartingCell.Position)
                {
                    if (board[row - 2][col].Empty && board[row - 1][col].Empty)
                    {
                        board[row - 2][col].Show = show;
                        path.Add(board[row - 2][col]);
                    }
                }
                if (Move.InBounds(--pathRow))
                {
                    if (Move.InBounds(col + 1) && !board[pathRow][col + 1].Empty && figure.CanEat(board[pathRow][col + 1].figure))
                    {
                        board[pathRow][col + 1].Show = show;
                        path.Add(board[pathRow][col + 1]);
                    }
                    if (Move.InBounds(col - 1) && !board[pathRow][col - 1].Empty && figure.CanEat(board[pathRow][col - 1].figure))
                    {
                        board[pathRow][col - 1].Show = show;
                        path.Add(board[pathRow][col - 1]);
                    }
                    if (Move.InBounds(col) && board[pathRow][col].Empty)
                    {
                        board[pathRow][col].Show = show;
                        path.Add(board[pathRow][col]);
                    }
                }

            }
            return path;
        }
    }
}
