using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;

namespace ChessGL.Views
{
    interface IView : IDrawable
    {
        //void Draw(SpriteBatch spritebatch);
        void Update();
        public bool Show { get; set; }
    }
}
