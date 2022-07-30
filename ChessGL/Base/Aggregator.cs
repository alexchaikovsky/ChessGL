using System.Collections.Generic;
using ChessGL.Figures;

namespace ChessGL.Base;

public class Aggregator
{
    // desk, menu buttons
    private readonly IReadOnlyList<SelectableEntity> _entities;

    public Aggregator(IReadOnlyList<SelectableEntity> entities)
    {
        _entities = entities;
    }

    public void HandleClick(Click click)
    {
        foreach (var selectableEntity in _entities)
        {
            if (selectableEntity.PointInEntityArea(click.Position))
            {
                selectableEntity.ExecuteAction(click);
            }
        }
    }
}