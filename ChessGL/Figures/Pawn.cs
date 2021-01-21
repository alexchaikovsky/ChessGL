using ChessGL.Moves;
using System;
using System.Collections.Generic;
using ChessGL.Board;
namespace ChessGL.Figures
{
    class Pawn : Figure
    {
        
        public Pawn(bool white, Cell defaultCell)
        {
            this.white = white;
            this.defaultCell = defaultCell;
            //this.moveTypes = new List<IMove>();
            Init();
            moveTypes.Add(new MovePawn());

            if (white)
            {
                thisTexturePath = "white_pawn";
            }
            else
            {
                thisTexturePath = "black_pawn";
            }
        }
        public override bool CheckMove(Cell start, Cell end)
        {
            if (start.row - end.row == -1)
            {
                return (start.col - end.col == 0 && end.Empty) || (Math.Abs(start.col - end.col) == 1 && !end.Empty);
            }
            return false;

        }
        
    }
}
