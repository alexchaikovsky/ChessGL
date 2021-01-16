using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ChessGL.Moves
{
    public abstract class SelectableEntity : ISelectableEntity
    {
        protected int pixelSize;
        public bool Selected { get; set; }
        public bool Selectable { get; set; }
        public virtual Point Position { get; set; }
        public virtual string MyName()
        {
            return this.ToString();
        }
        public bool PointInEntityArea(Point point)
        {
            //int AreaXL = (int)(Position.X - pixelSize / 2);
            //int AreaXR = (int)(Position.Y + pixelSize / 2);
            //int AreaYL = (int)(Position.X - pixelSize / 2);
            //int AreaYR = (int)(Position.Y + pixelSize / 2);
            int AreaXL = Position.X;
            int AreaXR = Position.X + pixelSize;
            int AreaYL = Position.Y;
            int AreaYR = Position.Y + pixelSize;
            //Debug.WriteLine(point.ToString());
            //Debug.WriteLine($"W = {pixelSize}, H = {pixelSize}");

            if (point.X >= AreaXL && point.X <= AreaXR)
            {
                if (point.Y >= AreaYL && point.Y <= AreaYR)
                {
                    return true;
                }
            }
            return false;
        }
        public void MouseClickEvent(object sender, MouseClickEventArgs e)
        {
            if (sender is Game)
            {
                if (PointInEntityArea(e.point))
                {
                    if (e.mouse.LeftButton == ButtonState.Pressed)
                    {
                        this.Selected = true;
                        Debug.WriteLine($"My name {this.MyName()}");
                        //
                    }
                }
            }
        }
    }
}
