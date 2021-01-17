using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace ChessGL.Figures
{
    class King : Figure
    {
        public King (bool white)
        {
            this.white = white;
            if (white)
            {
                thisTexturePath = "white_king";
            }
            else
            {
                this.defaultPosition = new Point(100, 100);
            }
        }
    }
}
