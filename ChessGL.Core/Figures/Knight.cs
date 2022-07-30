namespace ChessGL.Core.Figures
{
    class Knight : Figure
    {
        public Knight(bool white, Cell defaultCell = null)
        {
            moveTypes.Add(new MoveKnight());
            this.white = white;
            this.defaultCell = defaultCell;
        }
    }
}
