using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGL.Control
{
    interface IUserController
    {
        public abstract void UserControllerSelectionEvent(object sender, UserControllerEventArgs e);
    }
}