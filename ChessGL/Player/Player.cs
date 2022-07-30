using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Board;
using ChessGL.Core.Board;

namespace ChessGL.Player
{
    public abstract class Player
    {
        //TwoStageMouse mouse;
        protected Desk desk;
        public bool White { get; set; }
        public virtual void MakeMove()
        {

        }
    }
        
}
