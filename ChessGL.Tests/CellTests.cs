using ChessGL.Player;
using ChessGL.Figures;
using ChessGL.Board;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Xunit;

namespace ChessGL.Tests
{
    public class CellTests
    {
        [Fact]
        public void CanBeClicked()
        {
            PcPlayer player = new PcPlayer();
            var desk = new Desk();
            desk.WhitesTurn = true;
            player.AddDesk(desk);

            Cell cell = desk.board[6][1];
            player.SubscribeCell(cell);
            var positionChange = new PositionChange();
            player.Invoke(new MouseClickEventArgs() { point = cell.Position, clickNumber = 1, positionChange = positionChange});
            Assert.Equal(cell, positionChange.startingCell);
        }
    }
}
