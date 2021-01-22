using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Moves;
using ChessGL.Figures;
using System.Diagnostics;

namespace ChessGL.Board
{
    public class PositionChange
    {
        Cell startingCell;
        Cell endingCell;
        Figure startingFigure;
        Figure endingFigure;
        public PositionChange()
        {
            this.startingCell = null;
            this.endingCell = null;
            this.startingFigure = null;
            this.endingFigure = null;
        }
        public PositionChange(Cell startingCell, Cell endingCell, Figure startingFigure, Figure endingFigure)
        {
            this.startingCell = startingCell;
            this.endingCell = endingCell;
            this.startingFigure = startingFigure;
            this.endingFigure = endingFigure;
        }
        public void SetNull()
        {
            this.startingCell = null;
            this.endingCell = null;
            this.startingFigure = null;
            this.endingFigure = null;
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
            return false;
            //return FigureSelected() && endingFigure != null;
        }
        public void MakeChange()
        {
            if (FigureAttacking())
            {
                startingFigure.Move(startingCell, endingCell, endingFigure);
            }
            else
            {
                startingFigure.Move(startingCell, endingCell);
            }
        }
        public void ReverseChange()
        {
            startingFigure.Move(endingCell, startingCell);
            if (endingFigure!= null)
            {
                endingFigure.Active = true;
                endingFigure.cell = endingCell;
                endingFigure.Move(endingCell);
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
