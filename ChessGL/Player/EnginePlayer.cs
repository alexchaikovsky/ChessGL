using System;
using System.Collections.Generic;
using System.Text;
using ChessGL.Board;
using Stockfish;
using Stockfish.NET;
using System.Diagnostics;

namespace ChessGL.Player
{
    class EnginePlayer : Player
    {
        IStockfish stockfish;
        public EnginePlayer(Desk desk)
        {
            this.desk = desk;
            stockfish = new Stockfish.NET.Stockfish(@"E:\SHARP\stockfish_12_win_x64_bmi2\stockfish_20090216_x64_bmi2.exe");
            
        }

        public void UpdatePosition()
        {
            //string[] history = new string[desk.history.];
            //var lastPositionChange = desk.PeekMove();
            //Debug.WriteLine($"Update Pos{lastPositionChange.GetStartingCell().ToString()}{lastPositionChange.GetEndingCell().ToString()}");
            foreach (var pos in desk.GetHistoryAsStringArray())
            {
                Debug.WriteLine(pos);
            }
            stockfish.SetPosition(desk.GetHistoryAsStringArray());
         
        }

        public override void MakeMove()
        {
            var positionChange = new PositionChange();
            var bestMove = stockfish.GetBestMove();

            Debug.WriteLine("Stockfish best move: " + bestMove);
            string startString = bestMove.Substring(0, 2);
            string endString = bestMove.Substring(2, 2);

            foreach (var row in desk.board)
            {
                foreach (var cell in row)
                {
                    if (cell.ToString() == startString)
                    {
                        positionChange.startingCell = cell;
                        positionChange.startingFigure = cell.figure;
                    }
                    if (cell.ToString() == endString)
                    {
                        positionChange.endingCell = cell;
                        positionChange.endingFigure = cell.figure;
                    }
                }
            }
            
            positionChange.MakeChange();
            desk.AddPositionChange(positionChange);
            desk.WhitesTurn = true;
        }

        public void Update()
        {
            
        }
    }
}
