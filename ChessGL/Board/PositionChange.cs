using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;
using System.Diagnostics;
using ChessGL.Core.Figures;
using Figure = ChessGL.Figures.Figure;

namespace ChessGL.Board
{
    public class PositionChange
    {
        public Cell startingCell;
        public Cell endingCell;
        public Figure startingFigure;
        public Figure endingFigure;
        public PositionChange()
        {
            this.startingCell = null;
            this.endingCell = null;
            this.startingFigure = null;
            this.endingFigure = null;
            Castle = 0;
        }
        public PositionChange(Cell startingCell, Cell endingCell, Figure startingFigure, Figure endingFigure)
        {
            this.startingCell = startingCell;
            this.endingCell = endingCell;
            this.startingFigure = startingFigure;
            this.endingFigure = endingFigure;
            Castle = 0;
        }
        public void SetNull()
        {
            this.startingCell = null;
            this.endingCell = null;
            this.startingFigure = null;
            this.endingFigure = null;
            Castle = 0;
        }
        public bool IsSelectionCorrect()
        {
            // TODO: проверить выбор фигур (тест: при атаке черной пешкой короля при выборе ладьи а затем переключении на короля и при съедении пешки ладья перескакивает на место короля) 
            return (startingCell.figure == startingFigure && startingFigure.cell == startingCell) 
                && 
                (startingCell != endingCell && startingFigure != endingFigure);
        }
        public void SetStartingFigure(Figure figure)
        {
            startingFigure = figure;
        }
        public void SetEndingFigure(Figure figure)
        {
            endingFigure = figure;
        }
        public void SetStartingCell(Cell cell)
        {
            startingCell = cell;
        }
        public int Castle { get; set; }
        public void SetEndingCell(Cell cell)
        {
            endingCell = cell;
        }
        public bool FigureSelected()
        {
            return startingFigure != null;
        }
        public bool SelectedFigureIsWhite()
        {
            return startingFigure.white;
        }
        public void UndoSelection()
        {
            startingFigure.Selected = false;
        }
        public bool FigureAttacking()
        {
            if (endingFigure != null)
            {
                return endingFigure.white ^ startingFigure.white;
            }
            else if (endingCell.figure != null)
            {
                return endingCell.figure.white ^ startingFigure.white;
            }
            return false;
            //return FigureSelected() && endingFigure != null;
        }
        public void MakeChange()
        {
            Debug.WriteLine($"start {startingCell}{startingFigure.MyName()}\nend {endingCell} {endingCell.figure?.MyName()}");
            if (startingFigure is King)
            {
                var king = startingFigure as King;
                king.Moved = true;
                if (Math.Abs(endingCell.col - startingCell.col) == 2)
                {
                    startingFigure.Move(startingCell, endingCell);
                    
                    if (endingCell.col - startingCell.col == 2)
                    {
                        
                        king.Castle(left: false);
                        //board[row][7] move
                        //esle board[row][0]
                    }
                    else if(endingCell.col - startingCell.col == -2)
                    {
                        king.Castle(left: true);
                    }
                    king.Castled = true;
                    king.Moved = true;
                    Castle = endingCell.col - startingCell.col;
                    return;

                }
            }
            if (FigureAttacking())
            {
                //startingFigure.Move(startingCell, endingCell, endingFigure);
                startingFigure.Move(startingCell, endingCell, endingCell.figure);
            }
            else
            {
                startingFigure.Move(startingCell, endingCell);
            }
        }
        public void ReverseChange()
        {
            if (Castle != 0)
            {
                var king = startingFigure as King;
                //king.ToDefaultPosition();
                king.Move(endingCell, startingCell);
                if (Castle == -2)
                {

                    king.leftRook.Move(king.leftCell, king.leftRook.defaultCell);
                    king.leftCell.Empty = true;
                }
                else
                {
                    king.rightRook.Move(king.rightCell, king.rightRook.defaultCell);
                    king.rightCell.Empty = true;
                }
                endingCell.Empty = true;
                king.Moved = false;
                king.Castled = false;
                king.Active = true;
                
                Castle = 0;
                return;

            }
            startingFigure.Move(endingCell, startingCell);
            if (endingFigure != null)
            {
                endingFigure.Active = true;
                endingFigure.cell = endingCell;
                endingFigure.Move(endingCell);
            }
            else if (endingCell.figure != null)
            {
                endingCell.figure.Active = true;
                endingCell.figure.cell = endingCell;
                endingCell.figure.Move(endingCell);
            }
            //endingCell.figure = endingFigure;
            Debug.WriteLine("STARTF" + startingFigure.MyName()
                + "STARTCELL" + startingCell.MyName()
                + "ENDF" + endingFigure?.MyName()
                + "EDNCELL" + endingCell.MyName());
            
        }
        public Figure GetStartingFigure()
        {
            return startingFigure;
        }
        public Cell GetStartingCell()
        {
            return startingCell;
        }
        public Cell GetEndingCell()
        {
            return endingCell;
        }
    }
}
