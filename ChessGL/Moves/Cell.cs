using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ChessGL;
using ChessGL.Figures;
using System;
using System.Diagnostics;

namespace ChessGL.Moves
{
    public class Cell : SelectableEntity
    {
       // private Point position;
        public int row;
        public int col;
        public Figure? figure;
        public Cell(Point position, int size)
        {
            Position = position;
            //this.name = name;
            this.pixelSize = size;
        }
        
        public bool Empty { get; set; }
        public override string MyName()
        {
            return $"CELL {row}{(char)col} Position: {Position.ToString()}";
        }
        public override void CallAnswerEvent()
        {
            //OnCellClick(this,new CellEventArgs() {figure = this.figure});
            if (figure != null)
            {
                figure.Selected = true;

            }
        }
        protected virtual void OnCellClick(Cell cell, CellEventArgs e)
        {
            CellClickEvent?.Invoke(this, e);
        }
        public event EventHandler<CellEventArgs> CellClickEvent;


        public override void MouseClickEvent(object sender, MouseClickEventArgs e)
        {
            if (sender is Game)
            {
                if (PointInEntityArea(e.point)) {
                    Debug.WriteLine($"UNSELECTABLE {this.MyName()}");
                    e.endingCell = this;
                    
                }
                //switch (e.clickNumber)
                //{
                //    case 1:
                //        if (PointInEntityArea(e.point))
                //        {
                //            e.startingCell = this as Cell;

                //            //Selected = true;
                //            Debug.WriteLine($"1st click CELL {this.MyName()}");
                //            //CallAnswerEvent();
                //        }
                //        break;
                //    case 2:
                //        if (PointInEntityArea(e.point))
                //        {
                //            e.endingCell = this as Cell;
                //            //Position = e.point;
                //            //Selected = false;
                //            Debug.WriteLine($"2nd click CELL {this.MyName()}");
                //        }
                //        break;
                //}
            }
        }
    }
    public class CellEventArgs : EventArgs
    {
        public Figure? figure;
        
    }
}
