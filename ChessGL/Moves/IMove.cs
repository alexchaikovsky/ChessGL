using ChessGL.Figures;

namespace ChessGL.Moves
{
    interface IMove
    {
        //void ShowPath();
        public bool InBounds(int index)
        {
            return index >= 0 && index <= 7;

        }
    }
}
