using ChessGL.Board;
using ChessGL.Core.Board;
using ChessGL.Figures;

namespace ChessGL.Player
{
    public interface IPlayer
    {
        public void Update();
        public bool IsPcPlayer { get; set; }
        public bool KingIsDead { get; set; }
        public void AddDesk(Desk desk);
    }
}
