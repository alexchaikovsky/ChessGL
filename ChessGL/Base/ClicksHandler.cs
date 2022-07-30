using System;
using ChessGL.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ChessGL.Base;

public class ClicksHandler : IUpdateable
{
    private readonly TwoStageMouse _mouse = new();

    public ClicksHandler()
    {
        
    }
    public void Update(GameTime gameTime)
    {
        var newMouse = Mouse.GetState();

        var clickType = _mouse.CheckClick(newMouse);
        
        

    }

    public bool Enabled { get; }
    public int UpdateOrder { get; }
    public event EventHandler<EventArgs> EnabledChanged;
    public event EventHandler<EventArgs> UpdateOrderChanged;
}