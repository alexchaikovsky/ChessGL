using Microsoft.Xna.Framework;

namespace ChessGL;

public interface IMovable
{
    void Move(Point newPosition);
}