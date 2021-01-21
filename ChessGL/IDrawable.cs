using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace ChessGL
{
    interface IDrawable
    {
        void Draw(SpriteBatch spriteBatch);
    }
}
