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
        public override void ToDefaultPosition()
        {
            this.Position = new Point(200, 100); ;
        }
    }
}
