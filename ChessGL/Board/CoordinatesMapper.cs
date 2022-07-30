using Microsoft.Xna.Framework;

namespace ChessGL.Board;

public class CoordinatesMapper
{
    private Point _boardCoords;
    private (int width, int height) _size;

    public CoordinatesMapper(Point boardCoords, (int width, int height) size)
    {
        _boardCoords = boardCoords;
        _size = size;
    }

    public (int row, int col) GetSelectedCellId(Point point)
    {
        return (0, 0);
    }
}