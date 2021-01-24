using ChessGL.Board;
using ChessGL.Figures;

namespace ChessGL.Player
{
    public interface IPlayer
    {
        public void Update();
        public bool IsPcPlayer { get; set; }
        public void SubscribeButtons(Match match);
        public void CheckFigureSubscription(Figure figure);
        public void SubscribeCell(Cell cell);
        public bool KingIsDead { get; set; }
        public void AddDesk(Desk desk);
    }
}
