using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Control.Buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ChessGL.Control;

namespace ChessGL.Menu
{
    class StartMenu
    {
        TwoStageMouse mouse;
        StartTestMatchButton startTestMatchButton;
        StartEngineMatchButton startEngineMatchButton;
        Point e;
        public StartMenu()
        {

            startTestMatchButton = new StartTestMatchButton();
            startTestMatchButton.Position = new Point(100, 100);
            startTestMatchButton.StartingMatch = false;

            startEngineMatchButton = new StartEngineMatchButton();
            startEngineMatchButton.Position = new Point(100, 300);
            startEngineMatchButton.StartingMatch = false;

            mouse = new TwoStageMouse();
        }
        public void LoadButtons(Texture2D testTexture, Texture2D engineTexture)
        {
            startTestMatchButton.LoadTexture(testTexture);
            MenuMouseClickEvent += startTestMatchButton.MenuMouseClickEvent;

            startEngineMatchButton.LoadTexture(engineTexture);
            MenuMouseClickEvent += startEngineMatchButton.MenuMouseClickEvent;
        }
        public int Update()
        {
            var newMouse = Mouse.GetState();
            //var kstate = Keyboard.GetState();
            //MouseClickEvent(this, new MouseClickEventArgs { point = mouse.Position, mouse = mouse });

            int mouseAnswer = mouse.CheckClick(newMouse);
            e = newMouse.Position;

            if (mouseAnswer == 1)
            {
                
                OnMenuMouseClick(this, e);
                if (startEngineMatchButton.StartingMatch) return 2;
                if (startTestMatchButton.StartingMatch) return 1;
            }
            mouse.firstClick = true;
            return 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            startTestMatchButton.Draw(spriteBatch);
            startEngineMatchButton.Draw(spriteBatch);

        }
        protected virtual void OnMenuMouseClick(StartMenu menu, Point e)
        {
            MenuMouseClickEvent?.Invoke(this, e);
        }
        public event EventHandler<Point> MenuMouseClickEvent;
    }
}
