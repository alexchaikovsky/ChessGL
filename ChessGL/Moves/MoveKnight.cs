using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Figures;
using ChessGL.Board;
namespace ChessGL.Moves
{
    public class MoveKnight : Move, IMove
    {
        public List<Cell> ShowPath(Figure figure, List<List<Cell>> board, Cell pathStartingCell, bool show)
        {
            var path = new List<Cell>();
            int col = pathStartingCell.col % 96 - 1, row = Math.Abs(pathStartingCell.row - 8);
            int tryCol = col, tryRow = row;


            tryCol += 1; tryRow += 2;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    //board[tryRow][tryCol].Show = show;
                    path.Add(board[tryRow][tryCol]);
                }
            }

            tryCol = col; tryRow = row;
            tryCol -= 1; tryRow += 2;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    //board[tryRow][tryCol].Show = show;
                    path.Add(board[tryRow][tryCol]);
                }
            }

            tryCol = col; tryRow = row;
            tryCol -= 2; tryRow += 1;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    //board[tryRow][tryCol].Show = show;
                    path.Add(board[tryRow][tryCol]);
                }
            }
            tryCol = col; tryRow = row;
            tryCol -= 2; tryRow -= 1;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    //board[tryRow][tryCol].Show = show;
                    path.Add(board[tryRow][tryCol]);
                }
            }
            tryCol = col; tryRow = row;
            tryCol -= 1; tryRow -= 2;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    //board[tryRow][tryCol].Show = show;
                    path.Add(board[tryRow][tryCol]);
                }
            }
            tryCol = col; tryRow = row;
            tryCol += 1; tryRow -= 2;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    //board[tryRow][tryCol].Show = show;
                    path.Add(board[tryRow][tryCol]);
                }
            }
            tryCol = col; tryRow = row;
            tryCol += 2; tryRow -= 1;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    //board[tryRow][tryCol].Show = show;
                    path.Add(board[tryRow][tryCol]);
                }
            }
            tryCol = col; tryRow = row;
            tryCol += 2; tryRow += 1;
            if (InBounds(tryRow) && InBounds(tryCol))
            {
                if (board[tryRow][tryCol].Empty || figure.CanEat(board[tryRow][tryCol].figure))
                {
                    //board[tryRow][tryCol].Show = show;
                    path.Add(board[tryRow][tryCol]);
                }
            }
            return path;
        }
    }
}
