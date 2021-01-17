using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using ChessGL.Figures;

namespace ChessGL.Moves
{
    class TwoStageMouse
    {
        MouseState lastMouseState;
        bool mousePressed;
        bool firstClick;
        public TwoStageMouse()
        {
            lastMouseState = new MouseState();
            mousePressed = false;
            firstClick = true;
        }
        public int CheckClick(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
            {
                mousePressed = true;
                lastMouseState = mouseState;
                //Debug.WriteLine("Click");
                if (firstClick)
                {
                    firstClick = false;
                    Debug.WriteLine("1st Click");
                    return 1;
                }
                else
                {
                    firstClick = true;
                    Debug.WriteLine("2nd Click");
                    return 2;
                }
                //MouseClickEvent(this, new MouseClickEventArgs { point = mouse.Position, mouse = mouse });
                //Debug.WriteLine("Click");
            }


            if (mouseState.LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed)
            {
                mousePressed = false;
                Debug.WriteLine("Release");
                lastMouseState = mouseState;
                return -1;
            }
            
            return 0;
        }
    }
}
