using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ChessGL;
using System.Diagnostics;

namespace ChessGL.Figures
{
    public abstract class Figure : ISelectableEntity
    {
        Texture2D texture;
        Single resizeRate = 0.15f;
        protected Point defaultPosition;
        protected bool white;
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
            int AreaXL = (int)(Position.X - texture.Width * resizeRate / 2);
            int AreaXR = (int)(Position.Y + texture.Height * resizeRate / 2);
            int AreaYL = (int)(Position.X - texture.Width * resizeRate / 2);
            int AreaYR = (int)(Position.Y + texture.Height * resizeRate / 2 );
            Debug.WriteLine(point.ToString());
            Debug.WriteLine($"W = {texture.Width}, H = {texture.Height}");
        
            if (point.X >= AreaXL / 2 && point.X <= AreaXR)
            {
                if (point.Y >= AreaYL - texture.Height / 2 && point.Y <= AreaYR)
                {
                    return true;
                }
            }
            return false;
        }
        public virtual bool PossibleMove()
        {

            return false;
        }

        public virtual void ToDefaultPosition()
        {
            Position = defaultPosition;
        }
        public void MouseClickEvent(object sender, MouseClickEventArgs e)
        {
            if (sender is Game)
            {
                if (PointInFigureArea(e.point))
                {
                    if (e.mouse.LeftButton == ButtonState.Pressed)
                    {
                        this.Selected = true;
                        //
                    }
                }
            }
        } 
        
    }
}
