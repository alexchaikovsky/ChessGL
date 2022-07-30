using ChessGL.Base;
using ChessGL.Core.Board;
using ChessGL.Figures;

namespace ChessGL.Board;

public class GameArea : SelectableEntity
{
    public GameObject<Desk> Desk { get; set; }
    public override void ExecuteAction(Click click)
    {
        var cellId = new CoordinatesMapper(Desk.Position, (100, 100)).GetSelectedCellId(click.Position);
        Desk.Model.AddEvent(new DeskEvent {CellPosition = cellId});
    }
}