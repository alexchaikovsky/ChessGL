using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ChessGL.Moves;
namespace ChessGL.Control.Buttons
{
    class RotateBoardButton : InterfaceButton
    {
        Desk desk;
        public RotateBoardButton(Desk desk)
        {
            this.desk = desk;
            //pixelSize = 100;
        }
        public override void Action()
        {
            desk.RotateBoard();
        }
    }
}
