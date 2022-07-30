using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;
using ChessGL.Board;
using ChessGL.Core.Board;

namespace ChessGL.Control.Buttons
{
    public class PreviousPositionButton : InterfaceButton
    {
        Desk desk;
        public PreviousPositionButton (Desk desk)
        {
            this.desk = desk;
            //pixelSize = 100;
        }
        public override void Action()
        {
            desk.MoveBack();
            //foreach (var row in desk.board)
            //{
            //    foreach(var cell in row)
            //    {
            //        cell.figure?.ToDefaultPosition();
            //    }
            //}
        }
    }
}
