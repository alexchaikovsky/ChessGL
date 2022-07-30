using System.Drawing;
using ChessGL.Core.Figures;

namespace ChessGL.Core.Board;

public class Cell
{
    public int row;
    public int col;
    public Figure? Figure { get; private set; }
    public Cell GetCopy()
    {
        var cell = new Cell()
        {
            Figure = Figure,
            col = col,
            row = row,
        };
        return cell;
    }

    public bool Empty => Figure is not null;

    public void AddFigure(Figure figure)
    {
        Figure = figure;
    }
    
    public string MyName()
    {
        return $"CELL {row}{(char) col} Position: {0}";
    }

    public override string ToString()
    {
        return $"{(char) col}{row}";
    }
}