using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Control;

namespace ChessGL.Player
{
    public abstract class Player
    {
        //TwoStageMouse mouse;
        public bool White { get; set; }
        public virtual void MakeMove()
        {

        }
    }
        
}
