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
