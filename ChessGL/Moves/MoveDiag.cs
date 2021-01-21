using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using ChessGL.Figures;
using ChessGL.Board;
namespace ChessGL.Moves
{
    public class MoveDiag : IMove
    {
        public List<Cell> ShowPath(Figure figure, List<List<Cell>> board, Cell pathStartingCell, bool show)
        {
            int col = pathStartingCell.col % 96 - 1, row = Math.Abs(pathStartingCell.row - 8);
            var path = new List<Cell>();
            Debug.WriteLine($"{board.Count}, {board[0].Count}\nrow={row},col={col}, cell={pathStartingCell.row}{(char)pathStartingCell.col}");
            for (int i = col + 1; i < 8; i++) //moveleft
            {
                row++;
                if (row == 8) { break; }
                //Debug.WriteLine("Checking" + board[row][i].ToString());
                if (!board[row][i].Empty)
                {
                    if (board[row][i].figure.white ^ figure.white)
                    {
                        path.Add(board[row][i]);
                        board[row][i].Show = show;
                    }
                    break;
                }
                path.Add(board[row][i]);
                board[row][i].Show = show;
            }
            row = Math.Abs(pathStartingCell.row - 8);
            for (int i = col + 1; i < 8; i++) //moveleft
            {
                row--;
                if (row == -1) { break; }
                //Debug.WriteLine("Checking" + board[row][i].ToString());
                if (!board[row][i].Empty)
                {
                    if (board[row][i].figure.white ^ figure.white)
                    {
                        path.Add(board[row][i]);
                        board[row][i].Show = show;
                    }
                    break;
                }
                path.Add(board[row][i]);
                board[row][i].Show = show;
            }
            row = Math.Abs(pathStartingCell.row - 8);
            for (int i = col - 1; i >= 0; i--) //moveleft
            {
                row++;
                if (row == 8) { break; }
                //Debug.WriteLine("Checking" + board[row][i].ToString());
                if (!board[row][i].Empty)
                {
                    if (board[row][i].figure.white ^ figure.white)
                    {
                        path.Add(board[row][i]);
                        board[row][i].Show = show;
                    }
                    break;
                }
                path.Add(board[row][i]);
                board[row][i].Show = show;
            }
            row = Math.Abs(pathStartingCell.row - 8);
            for (int i = col - 1; i >= 0; i--) //moveleft
            {
                row--;
                if (row == -1) { break; }
                //Debug.WriteLine("Checking" + board[row][i].ToString());
                if (!board[row][i].Empty)
                {
                    if (board[row][i].figure.white ^ figure.white)
                    {
                        path.Add(board[row][i]);
                        board[row][i].Show = show;
                    }
                    break;
                }
                path.Add(board[row][i]);
                board[row][i].Show = show;
            }
            return path;
        }

    }
}
