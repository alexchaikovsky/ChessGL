using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Figures;

namespace ChessGL.Moves
{
    interface IMove
    {
        bool Move(Figure figure, Cell startingCell, Cell endingCell)
        {
          
            return false;
        }
    }
}
