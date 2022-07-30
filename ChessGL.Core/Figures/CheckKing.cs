namespace ChessGL.Core.Figures
{
    class CheckKing : Figure
    {
        public CheckKing(bool white, List<IMove> attackMoves)
        {
            this.white = white;
            moveTypes = attackMoves;
        }
        public override Point GetDefaultPosition()
        {
            return new Point(0,0);
        }
    }
}
