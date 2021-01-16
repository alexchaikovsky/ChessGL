using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ChessGL;

namespace ChessGL.Moves
{
    public class Cell : SelectableEntity
    {
        private Point position;
        public int row;
        public int col; 
        public Cell(Point position, int size)
        {
            this.position = position;
            //this.name = name;
            this.pixelSize = size;
        }
        public Point CellPosition
        {
            get
            {
                return position;
            }
        }
        public bool Empty { get; set; }
        public override string MyName()
        {
            return $"CELL {row}{(char)col}\nPosition: {position.ToString()}";
        }

        //public void MouseClickEvent(object sender, MouseClickEventArgs e)
        //{
        //    if (sender is Game)
        //    {
        //        if (PointInFigureArea(e.point))
        //        {
        //            if (e.mouse.LeftButton == ButtonState.Pressed)
        //            {
        //                this.Selected = true;
        //                //
        //            }
        //        }
        //    }
        //}
    }
}
