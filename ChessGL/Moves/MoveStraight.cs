using ChessGL.Figures;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace ChessGL.Moves
{
    public class MoveStraight : Move, IMove
    {
        public List<Cell> ShowPath(Figure figure, List<List<Cell>> board, Cell pathStartingCell, bool show)
        {
            int col = pathStartingCell.col % 96 - 1, row = Math.Abs(pathStartingCell.row - 8);
            var path = new List<Cell>();
            Debug.WriteLine($"{board.Count}, {board[0].Count}\nrow={row},col={col}, cell={pathStartingCell.row}{(char)pathStartingCell.col}");
            for (int i = col + 1; i < 8; i++) //moveleft
            {
                //Debug.WriteLine("Checking" + board[row][i].ToString());
                if (!board[row][i].Empty)
                {
                    //if (board[row][i].figure.white ^ figure.white)
                    if (figure.CanEat(board[row][i].figure))
                    {
                        path.Add(board[row][i]);
                        board[row][i].Show = show;
                    }
                    break;
                }
                path.Add(board[row][i]);
                board[row][i].Show = show;
            }
            Debug.Write("left");
            for (int i = col - 1; i >= 0; i--) //moveright
            {
                //Debug.WriteLine("Checking" + board[row][i].ToString());
                if (!board[row][i].Empty)
                {
                    //if (board[row][i].figure.white ^ figure.white)
                    if (figure.CanEat(board[row][i].figure))
                    {
                        path.Add(board[row][i]);
                        board[row][i].Show = show;
                    }
                    break;
                }
                path.Add(board[row][i]);
                board[row][i].Show = show;
            }
            Debug.Write("right");
            for (int i = row + 1; i < 8; i++) //moveup
            {
                //Debug.WriteLine("Checking" + board[i][col].ToString());
                if (!board[i][col].Empty)
                {
                    //if (board[i][col].figure.white ^ figure.white)
                    if (figure.CanEat(board[i][col].figure))
                    {
                        path.Add(board[i][col]);
                        board[i][col].Show = show;
                    }
                    break;
                }
                path.Add(board[i][col]);
                board[i][col].Show = show;
            }
            Debug.Write("up");
            for (int i = row - 1; i >= 0; i--) //movedowm
            {
                //Debug.WriteLine("Checking" + board[i][col].ToString());
                if (!board[i][col].Empty)
                {
                    //if (board[i][col].figure.white ^ figure.white)
                    if (figure.CanEat(board[i][col].figure))
                    {
                        path.Add(board[i][col]);
                        board[i][col].Show = show;
                    }
                    break;
                }
                path.Add(board[i][col]);
                board[i][col].Show = show;
            }
            Debug.WriteLine("down");
            return path;
        }
        
    }
}
