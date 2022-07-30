using System.Collections.Generic;
using System.Linq;
using ChessGL.Base;
using ChessGL.Core;

namespace ChessGL.Representations;

public class DeskRepresentation
{
    private IReadOnlyList<IRepresentation> _cells;
    private IReadOnlyList<IRepresentation> _figures;

    public DeskRepresentation(IReadOnlyList<IRepresentation> cells, IReadOnlyList<IRepresentation> figures)
    {
        _cells = cells;
        _figures = figures;
    }
    
    public IEnumerable<IRepresentation> GetRepresentations(Click click) => _cells.Where(x => x.)
}