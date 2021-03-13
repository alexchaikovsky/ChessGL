using ChessGL.Board;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGL.Control
{
    class UserControllerEventArgs : EventArgs
    {
        public Point Point { get; set; }
        public MouseState Mouse { get; set; }
        public PositionChange PositionChange { get; set; }
        public int ClickNumber { get; set; }
    }
}

