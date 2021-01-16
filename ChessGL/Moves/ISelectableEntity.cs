using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGL.Moves
{
    interface ISelectableEntity
    {
        public bool Selected { get; set; }
        bool Selectable { get; set; }
    }
}
