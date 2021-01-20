using ChessGL.Figures;
using System.Collections.Generic;

namespace ChessGL.Moves
{
    public abstract class Move
    {
        //void ShowPath();
        public static bool InBounds(int index)
        {
            return index >= 0 && index <= 7;

        }

        //public virtual List<Cell> ShowPath(Figure figure, List<List<Cell>> board, Cell pathStartingCell)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
