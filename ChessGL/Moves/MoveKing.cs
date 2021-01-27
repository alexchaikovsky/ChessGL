using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Figures;
using ChessGL.Board;
using System.Diagnostics;

namespace ChessGL.Moves
{
    public class MoveKing : Move, IMove
    {
        public List<Cell> ShowPath(Figure figure, List<List<Cell>> board, Cell pathStartingCell, bool show)
            // TODO: add castling
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
                            //board[i][j].Show = show;
                            path.Add(board[i][j]);
                        }
                    }
                }
            }
            if (pathStartingCell.Position == figure.GetDefaultPosition())
            {
                bool leftCastle = false;
                bool rightCastle = false;

                if (board[row][0].figure is Rook)
                {
                    leftCastle = true;
                    for (int i = 1; i < col; i++)
                    {
                        Debug.WriteLine($"i={i} Checking {board[row][i]}");
                        if (!(board[row][i].figure == null))
                        {
                            Debug.WriteLine("not empty");
                            leftCastle = false;
                            
                        }
                    }
                }
                if (board[row][7].figure is Rook) {
                    rightCastle = true;
                    for (int i = col + 1; i < 7; i++)
                    {
                        Debug.WriteLine($"i={i} Checking {board[row][i]}");
                        if (!(board[row][i].figure == null))
                        {
                            Debug.WriteLine("not empty");
                            rightCastle = false;
                        }
                    }
                }

                if (leftCastle) path.Add(board[row][col - 2]);
                if (rightCastle) path.Add(board[row][col + 2]);
                Debug.WriteLine($"lc {leftCastle} rc {rightCastle}");
                //if (board[row][])
            }
            //if (pathStartingCell.Position == figure.GetDefaultPosition())
            //{
            //    for (int i = 5; i < 7; i++)
            //    {
            //        if (board[row])
            //    }
            //}

            return path;
        }
    }
}
