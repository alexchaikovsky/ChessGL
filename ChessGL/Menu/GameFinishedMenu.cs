using ChessGL.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGL.Menu
{
    class GameFinishedMenu : BaseMenu
    {
        GameFinishedMenu(Texture2D texture, Point position)
        {
            Texture = texture;
            Position = position;
            mouse = new TwoStageMouse();

        }
    }
}
