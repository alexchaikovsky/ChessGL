using ChessGL.Figures;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using ChessGL.Board;
using ChessGL.Player;

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
        public virtual void CallAnswerEvent()
        {
            return;
        }
        public virtual void Action()
        {
            return;
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
        public virtual void MouseClickEvent(object sender, MouseClickEventArgs e)
        {
            if (sender is PcPlayer)
            {
                Debug.WriteLine("clickonentity");
                if (PointInEntityArea(e.point))
                {
                    Debug.WriteLine("in area");
                    this.Action();
                }
                
            }
        }
    }
}
