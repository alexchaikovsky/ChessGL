using System.Diagnostics;
using ChessGL.Base;
using ChessGL.Moves;
using ChessGL.Player;
using Microsoft.Xna.Framework;

namespace ChessGL.Figures
{
    public abstract class SelectableEntity : ISelectableEntity
    {
        protected int pixelSize;

        public bool Selected { get; set; }
        public bool Selectable { get; set; }
        public Point Position { get; set; }
        public virtual void ExecuteAction(Click click)
        {
            Debug.WriteLine("called Action");
            return;
        }
        public bool PointInEntityArea(Point point)
        {
            int AreaXL = Position.X;
            int AreaXR = Position.X + pixelSize;
            int AreaYL = Position.Y;
            int AreaYR = Position.Y + pixelSize;
            //Debug.WriteLine(point.ToString());
            //Debug.WriteLine($"W = {pixelSize}, H = {pixelSize}");

            return point.X >= AreaXL && point.X <= AreaXR && point.Y >= AreaYL && point.Y <= AreaYR;
        }
    }
}
