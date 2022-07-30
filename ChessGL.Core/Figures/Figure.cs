using System.Diagnostics;
using System.Drawing;
using ChessGL.Core.Board;

namespace ChessGL.Core.Figures;

public abstract class Figure
{
    public IReadOnlyList<IMove> MoveTypes { get; }
    public PieceColor PieceColor { get; init; }

    protected Figure(PieceColor pieceColor, IReadOnlyList<IMove> moveTypes)
    {
        PieceColor = pieceColor;
        MoveTypes = moveTypes;
    }

    public bool CanEat(Figure figure)
    {
        if (figure == null)
        {
            return false;
        }
        //if (figure is King && figure.white ^ this.white)
        //{
        //    (figure as King).UnderAttack = true;
        //    return false;

        //}
        return figure.PieceColor != PieceColor;
    }

    public bool CanMoveOnCell(Cell cell) => cell.Empty || cell.Figure.PieceColor != PieceColor;

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
}