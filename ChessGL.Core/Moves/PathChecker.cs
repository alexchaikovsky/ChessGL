using ChessGL.Core.Board;

namespace ChessGL.Core.Moves;

public class PathChecker
{
    private readonly Desk _desk;

    public PathChecker(Desk desk)
    {
        _desk = desk;
    }

    public List<Cell> GetAllowedPath(Cell cell)
    {
        var moves = cell.Figure?.MoveTypes;
        return moves is null ? new List<Cell>() : moves.Select(x => x.ShowPath(cell.Figure, _desk.board, cell)).SelectMany(x => x).ToList();
    }
}