using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGL.Control.Buttons
{
    class StartTestMatchButton : InterfaceButton
    {
        public bool StartingMatch { get; set; }
        public override void Action()
        {
            StartingMatch = true;
            return;
        }
    }
}
