using ChessGL.Figures;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ChessGL.Moves
{
    public class Desk
    {
        public List<List<Cell>> board;
        public List<List<Cell>> originalPositions;
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
        public void UpdateTexturesSize(Single resizeOption)
        {
            size = (int)(162 * resizeOption);
        }
        public List<Cell> ShowPath(Cell pathStartingCell, Figure figure)
        {
            return figure.FindMove(pathStartingCell, this);
            //Debug.WriteLine($"{board.Count}, {board[0].Count}\n{board[1][2].ToString()}");
            //var path = new List<Cell>();
            //if (figure is IMoveStraight)
            //{
            //    figure.PrintDebug();
            //    IMoveStraight moveFigure = figure as IMoveStraight;
            //    path.AddRange(moveFigure.ShowPath(figure, board, pathStartingCell));
            //}
            //if (figure is IMoveDiag)
            //{
            //    figure.PrintDebug();
            //    IMoveDiag moveFigure = figure as IMoveDiag;
            //    path.AddRange(moveFigure.ShowPath(figure, board, pathStartingCell));
            //}
            
            //if (figure is IMoveKnight)
            //{
            //    figure.PrintDebug();
            //    IMoveKnight moveFigure = figure as IMoveKnight;
            //    path.AddRange(moveFigure.ShowPath(figure, board, pathStartingCell));
            //}
            //if (figure is IMoveKing)
            //{
            //    figure.PrintDebug();
            //    IMoveKing moveFigure = figure as IMoveKing;
            //    path.AddRange(moveFigure.ShowPath(figure, board, pathStartingCell));
            //}
            //var figurePath = new List<Cell>();
            //foreach (var row in board)
            //{
            //    foreach (var cell in row)
            //    {
            //        if (figure.PossibleMove(pathStartingCell, cell))
            //        {
            //            //figurePath.Add(cell);
            //            cell.Show = true;
            //        }
            //    }
            //}
            //return path;
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
