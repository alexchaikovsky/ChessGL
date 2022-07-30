using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Figures;
using ChessGL.Menu;
using ChessGL.Moves;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGL.Control
{
    public abstract class InterfaceButton : SelectableEntity
    {
        Texture2D texture;
        public void LoadTexture(Texture2D texture)
        {
            
            this.texture = texture;
            pixelSize = (int)(texture.Width * 0.15f);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, Position.ToVector2(), null, Color.White, 0, new Vector2(pixelSize / 2, pixelSize / 2), 0.15f, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, Position.ToVector2(), null, Color.White, 0, new Vector2(0, 0), 0.15f, SpriteEffects.None, 1);
        }

        public void MenuMouseClickEvent (object sender, Point e)
        {
            if (sender is StartMenu)
            {
                if (PointInEntityArea(e))
                {
                    ExecuteAction(e);
                }
            }
        }
    }
}
