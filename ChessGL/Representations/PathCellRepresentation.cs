using ChessGL.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGL.Representations;

public class PathCellRepresentation : IRepresentation
{
    private readonly Texture2D _texture;
    private readonly int _pixelSize;
    private readonly SpriteBatch _spriteBatch;

    private Point _position;

    public PathCellRepresentation(SpriteBatch spriteBatch, Texture2D texture, int pixelSize)
    {
        _spriteBatch = spriteBatch;
        _texture = texture;
        _pixelSize = pixelSize;
    }

    public void Draw()
    {
        _spriteBatch.Draw(_texture, _position.ToVector2() + new Vector2(_pixelSize / 3, _pixelSize / 3), null, Color.White, 0, new Vector2(0, 0), 0.03f, SpriteEffects.None, 1);
    }
}