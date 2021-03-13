using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ChessGL.Control;

namespace ChessGL.Views
{
    class BaseView : IView
    {
        List<IDrawable> drawables = new List<IDrawable>();
        UserController controller;
        SpriteBatch spriteBatch;
        public Texture2D Texture { get; set; }
        Point IDrawable.Position { get; set; }
        public bool Show { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public BaseView(SpriteBatch spriteBatch, UserController controller)
        {
            this.controller = controller;
            this.spriteBatch = spriteBatch;
        }
        public void AddItem(IDrawable item)
        {
            drawables.Add(item);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Show)
            {
                foreach (var item in drawables)
                {
                    item.Draw(spriteBatch);
                }
            }
        }
        public void SubscribeSelectables()
        {
            //
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
