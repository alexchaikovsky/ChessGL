using ChessGL.Moves;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using ChessGL.Board;
namespace ChessGL.Figures
{
    public class Queen : Figure
    {
        public Queen(bool white, Cell defaultCell = null)
        {
            Init();
            moveTypes.Add(new MoveDiag());
            moveTypes.Add(new MoveStraight());
            this.white = white;
            this.defaultCell = defaultCell;
        }
        public override bool CheckMove(Cell start, Cell end)
        {
            if (start.row - end.row == 0 || start.col - end.col == 0) return true;
            if (Math.Abs(start.row - end.row) == Math.Abs(start.col % 96 - end.col % 96)) return true;
            return false;
        }
        //public override List<Cell> FindMove(Cell startingCell, Desk desk)
        //{
        //    var path = new List<Cell>();
        //    path.AddRange(moveStraight.ShowPath(this, desk.board, startingCell));
        //    path.AddRange(moveDiag.ShowPath(this, desk.board, startingCell));
        //    return path;
        //}
    }
}
