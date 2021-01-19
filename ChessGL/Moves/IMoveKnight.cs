using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Figures;

namespace ChessGL.Moves
{
    interface IMoveKnight : IMove
    {
        public List<Cell> ShowPath(Figure figure, List<List<Cell>> board, Cell pathStartingCell)
        {
            var path = new List<Cell>();
            int col = pathStartingCell.col % 96 - 1, row = Math.Abs(pathStartingCell.row - 8);
            int tryCol = col, tryRow = row;

            //for (int i = 1; i <= 2; i++)
            //{
            //    for (int j = 1; j <= 2; j++)
            //    {
            //        if (i != j)
            //        {

            //        }
            //    }
            //}

            tryCol += 1; tryRow += 2;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    board[tryRow][tryCol].Show = true;
                    path.Add(board[tryRow][tryCol]);
                }
            }

            tryCol = col; tryRow = row;
            tryCol -= 1; tryRow += 2;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    board[tryRow][tryCol].Show = true;
                    path.Add(board[tryRow][tryCol]);
                }
            }

            tryCol = col; tryRow = row;
            tryCol -= 2; tryRow += 1;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    board[tryRow][tryCol].Show = true;
                    path.Add(board[tryRow][tryCol]);
                }
            }
            tryCol = col; tryRow = row;
            tryCol -= 2; tryRow -= 1;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    board[tryRow][tryCol].Show = true;
                    path.Add(board[tryRow][tryCol]);
                }
            }
            tryCol = col; tryRow = row;
            tryCol -= 1; tryRow -= 2;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    board[tryRow][tryCol].Show = true;
                    path.Add(board[tryRow][tryCol]);
                }
            }
            tryCol = col; tryRow = row;
            tryCol += 1; tryRow -= 2;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    board[tryRow][tryCol].Show = true;
                    path.Add(board[tryRow][tryCol]);
                }
            }
            tryCol = col; tryRow = row;
            tryCol += 2; tryRow -= 1;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    board[tryRow][tryCol].Show = true;
                    path.Add(board[tryRow][tryCol]);
                }
            }
            tryCol = col; tryRow = row;
            tryCol += 2; tryRow += 1;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    board[tryRow][tryCol].Show = true;
                    path.Add(board[tryRow][tryCol]);
                }
            }
            return path;
        }
    }
}
