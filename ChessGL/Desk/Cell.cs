﻿using Microsoft.Xna.Framework;
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
        Texture2D texture;
        SpriteBatch spriteBatch;
        
        public int row;
        public int col;
        public Figure? figure;
        public Cell(Point position, int size)
        {
            Position = position;
            //this.name = name;
            this.pixelSize = size;
            //Show = true;
            
        }
        public bool Show { get; set; }
        public virtual void LoadTexture(Texture2D texture)
        {
            this.texture = texture;
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
                //if (PointInEntityArea(e.point)) {
                //    Debug.WriteLine($"UNSELECTABLE {this.MyName()}");
                //    e.endingCell = this;
                    
                //}
                switch (e.clickNumber)
                {
                    case 1:
                        if (PointInEntityArea(e.point))
                        {
                            e.startingCell = this;
                            Debug.WriteLine($"1st click CELL {this.MyName()}");
                        }
                        break;
                    case 2:
                        if (PointInEntityArea(e.point))
                        {
                            e.endingCell = this;
                            Debug.WriteLine($"2nd click CELL {this.MyName()}");
                        }
                        break;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, Position.ToVector2(), null, Color.White, 0, new Vector2(pixelSize / 2, pixelSize / 2), 0.15f, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, Position.ToVector2() + new Vector2(this.pixelSize / 3, this.pixelSize / 3), null, Color.White, 0, new Vector2(0, 0), 0.03f, SpriteEffects.None, 1);
        }
    }
    public class CellEventArgs : EventArgs
    {
        public Figure? figure;
        
    }
}