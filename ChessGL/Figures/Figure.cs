using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ChessGL;
using System.Diagnostics;

namespace ChessGL.Figures
{
    public abstract class Figure : SelectableEntity
    {
        Texture2D texture;
        Single resizeRate = 0.15f;
        protected Point defaultPosition;
        public bool white;

        public void LoadTexture(Texture2D texture)
        {
            this.texture = texture;
            this.pixelSize = (int)(resizeRate * texture.Width);
            this.Selectable = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, Position.ToVector2(), null, Color.White, 0, new Vector2(pixelSize / 2, pixelSize / 2), 0.15f, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, Position.ToVector2(), null, Color.White, 0, new Vector2(0, 0), 0.15f, SpriteEffects.None, 1);
        }
        //public bool PointInFigureArea(Point point)
        //{
        //    int AreaXL = (int)(Position.X - texture.Width * resizeRate / 2);
        //    int AreaXR = (int)(Position.Y + texture.Height * resizeRate / 2);
        //    int AreaYL = (int)(Position.X - texture.Width * resizeRate / 2);
        //    int AreaYR = (int)(Position.Y + texture.Height * resizeRate / 2 );
        //    Debug.WriteLine(point.ToString());
        //    Debug.WriteLine($"W = {texture.Width}, H = {texture.Height}");
        
        //    if (point.X >= AreaXL / 2 && point.X <= AreaXR)
        //    {
        //        if (point.Y >= AreaYL - texture.Height / 2 && point.Y <= AreaYR)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        public virtual bool PossibleMove()
        {

            return false;
        }

        public virtual void ToDefaultPosition()
        {
            Position = defaultPosition;
        }
        public override string MyName()
        {
            return $"Figure {this.ToString()} Position: {Position.ToString()}";
        }
        public void CellClickEvent(object sender, CellEventArgs e)
        {
            if (Selected)
            {
                if (sender is Cell)
                {
                    Cell cell = sender as Cell;


                    if (Position != cell.Position )
                    {
                        if (cell.figure != null)
                        {
                            if (cell.figure.white != this.white)
                            {
                                Position = cell.Position;
                                cell.figure = this;
                                Selected = false;
                                Debug.WriteLine($"MOVED {this.ToString()} TO CELL {cell.row}{(char)cell.col}");
                            }
                        }
                        else
                        {
                            Position = cell.Position;
                            cell.figure = this;
                            Selected = false;
                            Debug.WriteLine($"MOVED {this.ToString()} TO CELL {cell.row}{(char)cell.col}");
                        }
                        
                    }
                    
                }
            }
            else
            {
                Cell cell = sender as Cell;
                if (Position == cell.Position)
                {
                    //Position = cell.Position;
                    if (cell.figure != null)
                    {
                        if (this.white != cell.figure.white)
                        {
                            Active = false;
                        }
                        Selected = false;
                        Debug.WriteLine($"FIGURE {this.ToString()} ON CELL {cell.row}{(char)cell.col}");
                    }
                }
                
            }
        }
        public bool Active { get; set; }
        public override void MouseClickEvent(object sender, MouseClickEventArgs e)
        {
            if (sender is Game)
            {
                switch (e.clickNumber)
                {
                    case 1:
                        //Debug.WriteLine($"figure case 1");
                        if (PointInEntityArea(e.point) && !Selected)
                        {
                            e.startingFigure = this as Figure;

                            Selected = true;
                            Debug.WriteLine($"SELECTED {this.MyName()}");
                            CallAnswerEvent();
                        }
                        break;
                    case 2:
                        //Debug.WriteLine($"figure case 2");
                        if (Selected)
                        {
                            if (this is Figure)
                            {
                                e.startingFigure = this as Figure;
                            }
                            //Position = e.point;
                            Selected = false;
                            Debug.WriteLine($"MOVED {this.MyName()}");
                        }
                        break;
                }
            }
        }

    }
}
