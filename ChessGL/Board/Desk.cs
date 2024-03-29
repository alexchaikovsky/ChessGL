﻿using ChessGL.Figures;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGL.Board
{
    public class Desk
    {
        public List<List<Cell>> board;
        public List<List<Cell>> originalPositions;
        public List<Cell> currentPath;
        List<string> stringHistory;
        Stack <PositionChange> history;
        Texture2D deskTexture;
        King whiteKing;
        King blackKing;
        int size;

        int whitePerspective; // 1 if player plays white else -1
        bool deskRotated;
        public bool WhitesTurn { get; set; }
        public string[] GetHistoryAsStringArray() 
        {
            return stringHistory.ToArray();
            
        }
        public string GetHistoryAsString()
        {
            string historyString = "";
            foreach (var pos in stringHistory)
            {
                historyString += pos;
                historyString += " ";
            }
            return historyString;
        }
        public Desk(Single resizeOption = 1, int whitePerspective = -1)
        {
            currentPath = new List<Cell>();
            this.whitePerspective = whitePerspective;
            history = new Stack<PositionChange>();
            
            WhitesTurn = true;
            board = new List<List<Cell>>();
            stringHistory = new List<string>();
            int firstCellX = 32;
            int firstCellY = 33;
            var point = new Point(firstCellX, firstCellY);
            size = (int)(162 * resizeOption);
            for (int i = 8; i >= 1; i--)

            {

                var row = new List<Cell>();
                for (int j = 97; j <= 104; j++)
                {
                    var cell = new Cell(point, size);
                    cell.row = i;
                    cell.col = j;
                    cell.Empty = true;
                    row.Add(cell);

                    point.X += size;
                    //Debug.WriteLine($"CELL {row}{(char)cell.col}\nPosition: {cell.Position.ToString()}");
                }
                point.X = firstCellX;
                point.Y += size;
                board.Add(row);
            }

        }
        public void AddPositionChange(PositionChange positionChange)
        {
            Debug.WriteLine("Added position");
            history.Push(positionChange);
            string lastMove = $"{positionChange.GetStartingCell().ToString()}{positionChange.GetEndingCell().ToString()}";
            stringHistory.Add(lastMove);
        }
        public void MoveBack()
        {
            Debug.WriteLine("called MoveBack()");
            if (history.Count != 0)
            {
                //WhitesTurn = !WhitesTurn;
                var prevPosition = history.Pop();
                prevPosition.ReverseChange();
                stringHistory.RemoveAt(stringHistory.Count - 1);
                
            }
        }
        public void AddKings(King whiteKing, King blackKing)
        {
            this.whiteKing = whiteKing;
            this.blackKing = blackKing;
        }
        public void UpdateTexturesSize(Single resizeOption)
        {
            size = (int)(162 * resizeOption);
        }
        public bool KingsAttacked()
        {
            bool whiteAttacked = whiteKing.IsAttacked(this);
            whiteKing.UnderAttack = whiteAttacked;
            bool blackAttacked = blackKing.IsAttacked(this);
            blackKing.UnderAttack = blackAttacked;
            return whiteAttacked || blackAttacked;
        }
        public PositionChange PeekMove()
        {
            return history.Peek();
        }
        public void PlaceCell(Cell cell)
        {
            int col = cell.col % 96 - 1, row = Math.Abs(cell.row - 8);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == row && j == col)
                    {
                        if (board[i][j].figure != null)
                        {
                            cell.figure = board[i][j].figure;
                            cell.figure.cell = cell;
                            //board[i][j].figure.cell = cell;
                        }
                        board[i][j] = cell;
                    }
                }
            }

        } 
        bool CheckNewPosition(PositionChange safeKingPositionChange, Figure figure)
        {
            safeKingPositionChange.MakeChange();
            if (figure.white)
            {
                if (!whiteKing.IsAttacked(this))
                {
                    safeKingPositionChange.ReverseChange();
                    //kingSafeMoves.Add(cell);\
                    return true;
                }
            }
            else
            {
                if (!blackKing.IsAttacked(this))
                {
                    safeKingPositionChange.ReverseChange();
                    return true;
                    //kingSafeMoves.Add(cell);
                }
            }
            safeKingPositionChange.ReverseChange();
            return false;

        }
        public List<Cell> ShowPath(Cell pathStartingCell, Figure figure)
        {
            var possibleMoves = figure.FindMove(pathStartingCell, this);
            //bool whiteKingAttacked = whiteKing.IsAttacked(this);
            //bool blackKingAttacked = blackKing.IsAttacked(this);
            List<Cell> kingSafeMoves = new List<Cell>();
            //Parallel.ForEach(possibleMoves, (cell) =>
            //{
            //    PositionChange safeKingPositionChange = new PositionChange(pathStartingCell, cell, figure, cell.figure);
            //    if (CheckNewPosition(safeKingPositionChange, figure))
            //    {
            //        kingSafeMoves.Add(cell);
            //    }
            //});
            // TODO: king under attack not glowing red
            Debug.WriteLine($"ALL POSSIBLE MOVES COUNT: {possibleMoves.Count}");
            foreach (var cell in possibleMoves)
            {
                PositionChange safeKingPositionChange = new PositionChange(pathStartingCell, cell, figure, cell.figure);
                if (CheckNewPosition(safeKingPositionChange, figure))
                {
                    kingSafeMoves.Add(cell);
                }
            }

            //KingsAttacked();
            ShutPath();
            foreach (var cell in kingSafeMoves) cell.Show = true;
            //whiteKing.UnderAttack = whiteKingAttacked;
            //blackKing.UnderAttack = blackKingAttacked;
            //KingsAttacked();
            return kingSafeMoves;
            //return possibleMoves;
        }
        public void ShutPath()
        {
            foreach (var row in board)
            {
                foreach (var cell in row)
                {
                    cell.Show = false;
                }
            }
        }
        public void ToDefaultSet()
        {
            foreach(var row in board)
            {
                foreach(var cell in row)
                {
                    cell.Empty = true;
                    cell.figure = null;
                }
            }
        }
        
        public void RotateBoard()
        {
            var tmpBoard = new List<List<Cell>>();
            
            var tmpBoardPositions = new List<List<Point>>();
           
            //var tmpBoardPoint = new List<List<Point>>();
            foreach (var row in board)
            {
                var tmpRow = new List<Cell>();
                foreach (var cell in row)
                {
                    Cell tmpCell = new Cell(cell.Position, size);
                    tmpRow.Add(tmpCell);
                }
                tmpRow.Reverse();
                tmpBoard.Add(tmpRow);
            }
            tmpBoard.Reverse();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board[i][j].Position = tmpBoard[i][j].Position;
                    if (board[i][j].figure != null)
                    {
                        board[i][j].figure.Position = tmpBoard[i][j].Position;
                    }
                }
            }
            return;
        }
    }
}
