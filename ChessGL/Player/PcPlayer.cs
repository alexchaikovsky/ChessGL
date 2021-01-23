using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ChessGL.Board;

namespace ChessGL.Player
{
    public class PcPlayer : Player
    {
        TwoStageMouse mouse;
        MouseClickEventArgs e;
        Desk desk;
        public PcPlayer(Desk desk)
        {
            this.desk = desk;
            mouse = new TwoStageMouse();
            e = new MouseClickEventArgs();
            e.positionChange = new PositionChange();
        }
        
        public void Invoke(MouseClickEventArgs e)
        {
            MouseClickEvent(this, e);
        }
        public void Update()
        {
            var newMouse = Mouse.GetState();
            //var kstate = Keyboard.GetState();
            //MouseClickEvent(this, new MouseClickEventArgs { point = mouse.Position, mouse = mouse });

            int mouseAnswer = mouse.CheckClick(newMouse);
            e.point = newMouse.Position;
            e.mouse = newMouse;
            if (mouseAnswer == 1)
            {
                SelectFigure();
            }
            else if (mouseAnswer == 2)
            {
                MoveFigure();
            }
        }
        public void MoveFigure()
        {
            desk.ShutPath();

            e.clickNumber = 2;
            Invoke(e);
            

            if (e.positionChange.FigureSelected())
            {
                if (desk.currentPath.Contains(e.positionChange.GetEndingCell()))
                {
                    e.positionChange.MakeChange();
                    desk.WhitesTurn = !desk.WhitesTurn;
                    desk.AddPositionChange(e.positionChange);
                    e.positionChange = new PositionChange();
                }

            }

            e.positionChange.SetNull();
        }
        public void SelectFigure()
        {
            
            e.clickNumber = 1;
            Invoke(e);
            if (!e.positionChange.FigureSelected())
            {

                mouse.firstClick = true;
                e.positionChange.SetNull();

            }
            else if (e.positionChange.SelectedFigureIsWhite() != desk.WhitesTurn || !e.positionChange.IsSelectionCorrect())
            {
                e.positionChange.UndoSelection();
                mouse.firstClick = true;
                e.positionChange.SetNull();
            }
            else
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                desk.currentPath = desk.ShowPath(e.positionChange.GetStartingCell(), e.positionChange.GetStartingFigure());
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                //Debug.WriteLine($"ElapsedMS::{elapsedMs}");
                if (desk.currentPath.Count == 0)
                {
                    mouse.firstClick = true;
                    e.positionChange.SetNull();
                }
            }
        }

        protected virtual void OnMouseClick(PcPlayer pcPlayer, MouseClickEventArgs e)
        {
            MouseClickEvent?.Invoke(this, e);
        }
        public event EventHandler<MouseClickEventArgs> MouseClickEvent;

    }
    public class MouseClickEventArgs : EventArgs
    {
        public Point point;
        public MouseState mouse;
        public int clickNumber;
        public PositionChange positionChange;
    }
}
