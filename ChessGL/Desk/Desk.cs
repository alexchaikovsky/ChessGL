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
        int size;
        int whitePerspective; // 1 if player plays white else -1
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
            Debug.WriteLine($"{board.Count}, {board[0].Count}\n{board[1][2].ToString()}");
            var path = new List<Cell>();
            if (figure is IMoveStraight)
            {
                figure.PrintDebug();
                IMoveStraight moveFigure = figure as IMoveStraight;
                path.AddRange(moveFigure.ShowPath(figure, board, pathStartingCell));
            }
            if (figure is IMoveDiag)
            {
                figure.PrintDebug();
                IMoveDiag moveFigure = figure as IMoveDiag;
                path.AddRange(moveFigure.ShowPath(figure, board, pathStartingCell));
            }
            if (figure is IMovePawn)
            {
                figure.PrintDebug();
                IMovePawn moveFigure = figure as IMovePawn;
                path.AddRange(moveFigure.ShowPath(figure, board, pathStartingCell));
            }
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
            return path;
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
    }
}
