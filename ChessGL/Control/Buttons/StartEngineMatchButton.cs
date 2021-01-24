using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGL.Control.Buttons
{
    class StartEngineMatchButton : InterfaceButton
    {
        public bool StartingMatch { get; set; }
        public override void Action()
        {
            StartingMatch = true;
            return;
        }
    }
}
