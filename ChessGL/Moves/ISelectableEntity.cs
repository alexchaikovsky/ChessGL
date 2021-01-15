using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGL.Moves
{
    interface ISelectableEntity
    {
        public bool Selected { get; set; }
        bool Selectable { get; set; }
    }
}
