using ChessGL.Core;
using ChessGL.Moves;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChessGL.Representations;

public class EmptyCellRepresentation : IRepresentation
{
    private readonly Texture2D _frameTexture;
    private readonly SpriteBatch _spriteBatch;

    private Point _position;

    public EmptyCellRepresentation(Texture2D frameTexture, SpriteBatch spriteBatch)
    {
        _frameTexture = frameTexture;
        _spriteBatch = spriteBatch;
    }

    public void Draw()
    {
        _spriteBatch.Draw(_frameTexture, _position.ToVector2() + new Vector2(0, 5), null, Color.White, 0, new Vector2(0, 0), 0.3f, SpriteEffects.None, 1);
    }
}