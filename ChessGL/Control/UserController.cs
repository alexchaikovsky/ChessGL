using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ChessGL.Control
{
    class UserController
    {
        TwoStageMouse mouse;

        public UserController()
        {
            mouse = new TwoStageMouse();
        }

        public int CheckClick()
        {
            return mouse.CheckClick(new MouseState());
        }
        protected virtual void OnMouseClick(UserController userController, UserControllerEventArgs e)
        {
            MouseClickEvent?.Invoke(this, e);
        }
        public event EventHandler<UserControllerEventArgs> MouseClickEvent;
    }
}
