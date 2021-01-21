using ChessGL.Figures;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ChessGL.Figures;

namespace ChessGL.Board
{
    public class Desk
    {
        public List<List<Cell>> board;
        public List<List<Cell>> originalPositions;
        King whiteKing;
        King blackKing;
        int size;
        int whitePerspective; // 1 if player plays white else -1
        bool deskRotated;
        public Desk(Single resizeOption = 1, int whitePerspective = -1)
        {
            this.whitePerspective = whitePerspective;

            
            
            board = new List<List<Cell>>();

            int firstCellX = 32;
            int firstCellY = 33;
            var point = new Point(firstCellX, firstCellY);
            size = (int)(162 * resizeOption);
            for (int i = 8; i >= 1; i--)

            {

                var row = new List<Cell>();
                for (int j = 97; j <= 104; j++)
                {
                    var cell = new Cell(point, size);
                    cell.row = i;
                    cell.col = j;
                    cell.Empty = true;
                    row.Add(cell);

                    point.X += size;
                    //Debug.WriteLine($"CELL {row}{(char)cell.col}\nPosition: {cell.Position.ToString()}");
                }
                point.X = firstCellX;
                point.Y += size;
                board.Add(row);
            }

        }
        public void AddKings(King whiteKing, King blackKing)
        {
            this.whiteKing = whiteKing;
            this.blackKing = blackKing;
        }
        public void UpdateTexturesSize(Single resizeOption)
        {
            size = (int)(162 * resizeOption);
        }
        bool KingsAttacked()
        {
            return whiteKing.IsAttacked(this) || blackKing.IsAttacked(this);
        }
        public void PlaceCell(Cell cell)
        {
            int col = cell.col % 96 - 1, row = Math.Abs(cell.row - 8);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == row && j == col)
                    {
                        if (board[i][j].figure != null)
                        {
                            cell.figure = board[i][j].figure;
                            cell.figure.cell = cell;
                            //board[i][j].figure.cell = cell;
                        }
                        board[i][j] = cell;
                    }
                }
            }

        } 
        public List<Cell> ShowPath(Cell pathStartingCell, Figure figure)
        {
            var possibleMoves = figure.FindMove(pathStartingCell, this);
            //List<Cell> kingSafeMoves = new List<Cell>();
            //for (int i = 0; i < possibleMoves.Count; i++)
            //{

            //    Cell testCell = possibleMoves[i].GetCopy();
            //    Cell savedCell = possibleMoves[i].GetCopy();
            //    Debug.WriteLine(testCell.MyName());
            //    PlaceCell(testCell);
            //    //normalCell = tryCell;
            //    figure.Move(figure.cell, testCell, testCell.figure);


            //        if (figure.white)
            //        {
            //            if (!whiteKing.IsAttacked(this))
            //            {
            //                kingSafeMoves.Add(savedCell);
            //            }

            //        }
            //        else
            //        {
            //            if (!blackKing.IsAttacked(this))
            //            {
            //                kingSafeMoves.Add(savedCell);
            //            }

            //    }
            //    PlaceCell(savedCell);
            //}
            //return kingSafeMoves;
            return possibleMoves;
        }
        public void ShutPath()
        {
            foreach (var row in board)
            {
                foreach (var cell in row)
                {
                    cell.Show = false;
                }
            }
        }
        public void ToDefaultSet()
        {
            foreach(var row in board)
            {
                foreach(var cell in row)
                {
                    cell.Empty = true;
                    cell.figure = null;
                }
            }
        }
        
        public void RotateBoard()
        {
            var tmpBoard = new List<List<Cell>>();
            
            var tmpBoardPositions = new List<List<Point>>();
           
            //var tmpBoardPoint = new List<List<Point>>();
            foreach (var row in board)
            {
                var tmpRow = new List<Cell>();
                foreach (var cell in row)
                {
                    Cell tmpCell = new Cell(cell.Position, size);
                    tmpRow.Add(tmpCell);
                }
                tmpRow.Reverse();
                tmpBoard.Add(tmpRow);
            }
            tmpBoard.Reverse();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i][j].Position = tmpBoard[i][j].Position;
                    if (board[i][j].figure != null)
                    {
                        board[i][j].figure.Position = tmpBoard[i][j].Position;
                    }
                }
            }
            return;

            //if (!deskRotated)
            //{
            //    for (int i = 0; i < 4; i++)
            //    {
            //        Debug.WriteLine($"row{i} pos changed saved to tmp");
            //        var tmpRowPositions = new List<Point>();
            //        for (int j = 0; j < 8; j++)
            //        {
            //            //Debug.WriteLine($"row{i}col{j} pos changed, pos saved");
            //            //Cell tmpCell = new Cell(board[i][j].Position, size);
            //            Point tmpPosition = new Point(board[i][j].Position.X, board[i][j].Position.Y);
            //            //Debug.WriteLine($"{board[i][j].ToString()}old pos {board[i][j].Position} new pos {board[7 - i][j].Position}");
            //            board[i][j].Position = board[7 - i][j].Position;
            //            if (board[i][j].figure != null)
            //            {
                            
            //                //Debug.WriteLine($"moved {board[i][j].figure.MyName()} white={board[i][j].figure.white}");
            //                board[i][j].figure.Position = board[7 - i][j].Position;
            //            }
            //            tmpRowPositions.Add(tmpPosition);
            //            //tmpRow.Add(tmpCell);
            //        }
            //        tmpBoardPositions.Add(tmpRowPositions);
            //        //tmpBoard.Add(tmpRow);
            //    }
            //    foreach(var row in tmpBoardPositions)
            //    {
            //        Debug.WriteLine($"row count {row.Count}");
            //        foreach(var point in row)
            //        {
            //            Debug.WriteLine(point.ToString());
            //        }
            //    }
            //    for (int i = 4; i < 8; i++)
            //    {
            //        Debug.WriteLine($"row{i} pos changed (from tmp)");
            //        for (int j = 0; j < 8; j++)
            //        {
            //            //tmpRow.Add(board[i][j]);
            //            //Debug.WriteLine($"row{i}col{j} pos changed (from tmp)");
            //            //Debug.WriteLine($"{board[i][j].ToString()} old pos {board[i][j].Position} new pos {tmpBoard[7 - i][j].Position}");
            //            //board[i][j].Position = tmpBoard[7 - i][j].Position;
            //            board[i][j].Position = tmpBoardPositions[7 - i][j];
            //            if (board[i][j].figure != null)
            //            {
            //                //Debug.WriteLine($"moved {board[i][j].figure.MyName()} white={board[i][j].figure.white}");
            //                //board[i][j].figure.Position = tmpBoard[7 - i][j].Position;
            //                board[i][j].figure.Position = tmpBoardPositions[7 - i][j];
            //            }
            //        }
            //    }
            //    deskRotated = true;
            //}
            //return;
        }
    }
}
