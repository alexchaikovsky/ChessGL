using System;
using System.Collections.Generic;
using System.Diagnostics;
using ChessGL.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ChessGL.Board;
using ChessGL.Figures;

namespace ChessGL.Player
{
    public class PcPlayer : Player, IPlayer
    {
        TwoStageMouse mouse;
        MouseClickEventArgs e;
        public bool IsPcPlayer { get; set; }
        
        //public PcPlayer(Desk desk)
        public PcPlayer()
        {
            //this.desk = desk;
            mouse = new TwoStageMouse();
            e = new MouseClickEventArgs();
            e.positionChange = new PositionChange();
            KingIsDead = false;
            IsPcPlayer = true;
        }
        public bool KingIsDead { get; set; }
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
                
                Debug.WriteLine("\n====\n=====\nPLAYER MOVE" +
                    "\n====\n=====\n");
            }
        }
        public void MoveFigure()
        {
            desk.ShutPath();

            e.clickNumber = 2;
            Invoke(e);
            

            if (e.positionChange.FigureSelected() && e.positionChange.IsSelectionCorrect())
            {
                if (desk.currentPath.Contains(e.positionChange.GetEndingCell()))
                {
                    e.positionChange.MakeChange();
                    //desk.WhitesTurn = !desk.WhitesTurn;
                    desk.AddPositionChange(e.positionChange);
                    e.positionChange = new PositionChange();
                    desk.WhitesTurn = !desk.WhitesTurn;
                }
                else if (desk.currentPath.Count == 0)
                {
                    KingIsDead = true;
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
                e.clickNumber = 1;
                e.positionChange.SetNull();

            }
            else if (e.positionChange.SelectedFigureIsWhite() != desk.WhitesTurn || !e.positionChange.IsSelectionCorrect())
            {
                e.positionChange.UndoSelection();
                mouse.firstClick = true;
                e.clickNumber = 1;
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
        public void SubscribeButtons(Match match)
        {
            MouseClickEvent += match.previousPositionButton.MouseClickEvent;
            MouseClickEvent += match.rotateBoardButton.MouseClickEvent;
        }
        public void CheckFigureSubscription(Figure figure)
        {
            if (!figure.Active) { if (figure.Subcribed) MouseClickEvent -= figure.MouseClickEvent; figure.Subcribed = false; }
            else { if (!figure.Subcribed) MouseClickEvent += figure.MouseClickEvent; figure.Subcribed = true; }
        }
        public void SubscribeCell(Cell cell)
        {
            MouseClickEvent += cell.MouseClickEvent;
        }
        public void AddDesk(Desk desk)
        {
            this.desk = desk;
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
