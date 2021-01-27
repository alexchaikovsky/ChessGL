using ChessGL.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGL.Menu
{
    abstract class BaseMenu : IDrawable
    {
        protected TwoStageMouse mouse;
        protected Point e;
        public Single ResizeOption { get; set; }
        public Texture2D Texture { get; set; }
        public Point Position { get; set; }

        protected virtual void OnMenuMouseClick(StartMenu menu, Point e)
        {
            MenuMouseClickEvent?.Invoke(this, e);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position.ToVector2(), null, Color.White, 0, new Vector2(0, 0), ResizeOption, SpriteEffects.None, 1);
        }

        public event EventHandler<Point> MenuMouseClickEvent;
    }
}
