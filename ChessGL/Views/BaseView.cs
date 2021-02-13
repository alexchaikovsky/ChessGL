using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ChessGL.Control;

namespace ChessGL.Views
{
    class BaseView : IDrawable
    {
        List<IDrawable> drawables = new List<IDrawable>();
        UserController contoller;
        public Texture2D Texture { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Point Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public BaseView(SpriteBatch spriteBatch, UserController contoller)
        {

        }
        public void AddItem(IDrawable item)
        {
            drawables.Add(item);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in drawables)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
