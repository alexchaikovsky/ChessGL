using ChessGL.Core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace ChessGL.Representations;

public abstract class FigureRepresentation : IRepresentation, IMovable
{
    private readonly SpriteBatch _spriteBatch;
    private readonly Texture2D _figureTexture;

    protected Point Position;

    float resizeRate = 0.15f;

    public FigureRepresentation(SpriteBatch spriteBatch, Texture2D figureTexture, Point defaultPosition)
    {
        _spriteBatch = spriteBatch;
        _figureTexture = figureTexture;
        Position = defaultPosition;
    }

    public void Draw()
    {
        _spriteBatch.Draw(_figureTexture, Position.ToVector2(), null, Color.White, 0, new Vector2(0, 0), 0.15f, SpriteEffects.None, 1);
    }

    public void Move(Point newPosition)
    {
        Position = newPosition;
    }
}