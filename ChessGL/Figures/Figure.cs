using ChessGL.Moves;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace ChessGL.Figures
{
    public abstract class Figure : SelectableEntity
    {
        protected Cell defaultCell;
        Texture2D texture;
        Single resizeRate = 0.15f;
        protected Point defaultPosition;
        public bool white;
        public string thisTexturePath;

        //public Figure(bool white, Cell defaultCell)
        //{
        //    this.white = white;
        //    this.defaultCell = defaultCell;
        //}
        public bool CanEat(Figure figure)
        {
            if (figure == null)
            {
                return false;
            }
            return figure.white ^ this.white;
        }
        public Point GetDefaultPosition()
        {
            return defaultCell.Position;
        }
        public virtual void LoadTexture(Texture2D texture)
        {
            this.texture = texture;
            this.pixelSize = (int)(resizeRate * texture.Width);
            this.Selectable = true;
            this.Active = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, Position.ToVector2(), null, Color.White, 0, new Vector2(pixelSize / 2, pixelSize / 2), 0.15f, SpriteEffects.None, 1);
            spriteBatch.Draw(texture, Position.ToVector2(), null, Color.White, 0, new Vector2(0, 0), 0.15f, SpriteEffects.None, 1);
        }
        public bool PossibleMove(Cell start, Cell end)
        {
            if (start == null) Debug.WriteLine("start empty");
            if (end == null) Debug.WriteLine("end empty");
            return this.CheckMove(start, end);
        }
        public virtual bool CheckMove(Cell start, Cell end)
        {
            return true;
        }

        public virtual void ToDefaultPosition()
        {
            //Position = defaultPosition;
            Move(defaultCell);
        }
        public override string MyName()
        {
            return $"Figure {this.ToString()} Position: {Position.ToString()}";
        }
        public void PrintDebug()
        {
            Debug.WriteLine("Inside " + MyName());
        }

        public bool Move(Cell cell)
        {
            Debug.WriteLine("MOVE " + MyName() + $"CELL {cell.row}{(char)cell.col}");
            Position = cell.Position;
            cell.figure = this;
            cell.Empty = false;
            return true;
        }
        public bool Move(Cell start, Cell end)
        {
            Move(end);
            start.Empty = true;
            start.figure = null;
            return true;
        }
        public bool Move(Cell start, Cell end, Figure prev)
        {
            Move(start, end);
            prev.Active = false;
            Debug.WriteLine(prev.MyName() + "no more active");
            return true;
        }
        public void CellClickEvent(object sender, CellEventArgs e)
        {
            if (Selected)
            {
                if (sender is Cell)
                {
                    Cell cell = sender as Cell;


                    if (Position != cell.Position)
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
                            //Debug.WriteLine($"MOVED {this.MyName()}");
                        }
                        else
                        {
                            if (PointInEntityArea(e.point))
                            {
                                //Debug.WriteLine($"2ND CLICK {this.MyName()}");
                                e.endingFigure = this;
                            }
                        }
                        break;
                }
            }
        }

    }
}
