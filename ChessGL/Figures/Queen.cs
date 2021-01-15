using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGL.Figures
{
    class Queen : Figure
    {
        public override void ToDefaultPosition()
        {
            this.Position = new Point(100, 100); ;
        }
    }
}
