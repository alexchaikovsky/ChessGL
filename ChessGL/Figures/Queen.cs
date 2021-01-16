using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ChessGL;

namespace ChessGL.Figures
{
    public class Queen : Figure
    {
        public Queen(bool white)
        {
            this.white = white;
            if (white)
            {
                this.defaultPosition = new Point(100, 500);
            }
            else
            {
                this.defaultPosition = new Point(100, 100);
            }
        }
    }
}
