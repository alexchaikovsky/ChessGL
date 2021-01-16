using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGL.Moves
{
    public class Desk
    {
        public List<List<Cell>> board;
        public Desk()
        {
            board = new List<List<Cell>>();
            int rowCh = 1;
            int colCh = 97;
            var point = new Point(48, 18);
            int size = 162;
            for (int i = 1; i <= 8; i++)
            
            {
     
                var row = new List<Cell>();
                for (int j = 97; j <= 105; j++)
                {
                    var cell = new Cell(point, size);
                    cell.row = i;
                    cell.col = j;
                    row.Add(cell);

                    point.X += size;

                }
                point.Y += size;
                board.Add(row);
            }
        }
    }
}
