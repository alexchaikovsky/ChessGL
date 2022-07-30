using ChessGL.Base;
using ChessGL.Core;
using ChessGL.Figures;
using Microsoft.Xna.Framework;

namespace ChessGL.Board;

public class GameObject<TModel>
{
    public IRepresentation Representation { get; set; }
    public Point Position { get; set; }
    public TModel Model { get; set; }
}