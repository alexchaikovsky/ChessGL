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
        Texture2D Texture { get; set; }
        public Point Position { get; set; }
        void Draw(SpriteBatch spriteBatch);
    }
}
