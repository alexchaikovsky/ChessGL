using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGL.Figures
{
    class Figure : ISelectableEntity
    {
        Texture2D texture;
        public virtual Point Position { get; set; }
        public bool Selected { get; set; }
        public bool Selectable { get; set; }

        public void LoadTexture(Texture2D texture)
        {
            this.texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position.ToVector2(), null, Color.White, 0, new Vector2(texture.Width / 2, texture.Height / 2), 0.15f, SpriteEffects.None, 1);
        }
        public bool PointInFigureArea(Point point)
        {
            if (point.X >= Position.X && point.X <= Position.X + texture.Width)
            {
                if (point.Y >= Position.Y && point.Y <= Position.Y + texture.Height)
                {
                    return true;
                }
            }
            return false;
        }
        public bool PossibleMove()
        {

            return false;
        }

        public virtual void ToDefaultPosition()
        {
        }
        
    }
}
