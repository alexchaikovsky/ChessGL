using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGL.Figures
{
    class Figure
    {
        Texture2D texture;
        public virtual Point FigurePosition {
        get
            {
                return FigurePosition;
            }
        set
            {
                FigurePosition = value;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, FigurePosition.ToVector2(), null, Color.White, 0, new Vector2(texture.Width / 2, texture.Height / 2), 0.15f, SpriteEffects.None, 1);
        }
    }
}
