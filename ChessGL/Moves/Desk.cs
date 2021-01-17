using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ChessGL.Moves
{
    public class Desk
    {
        public List<List<Cell>> board;
        int size;
        public Desk(Single resizeOption = 1)
        {
            board = new List<List<Cell>>();
            int rowCh = 1;
            int colCh = 97;
            int firstCellX = 32;
            int firstCellY = 33;
            var point = new Point(firstCellX, firstCellY);
            size = (int)(162*resizeOption);
            for (int i = 8; i >= 1; i--)
            
            {
     
                var row = new List<Cell>();
                for (int j = 97; j <= 105; j++)
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
        public void UpdateTexturesSize(Single resizeOption)
        {
            size = (int)(162 * resizeOption);
        }
    }
}
