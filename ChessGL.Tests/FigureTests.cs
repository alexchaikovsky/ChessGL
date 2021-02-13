using ChessGL.Player;
using ChessGL.Figures;
using ChessGL.Board;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Xunit;

namespace ChessGL.Tests
{
    public class FigureTests
    {
        [Fact]
        public void CanBeSubscribed()
        {
            PcPlayer player = new PcPlayer();
            var desk = new Desk();
            desk.WhitesTurn = true;
            player.AddDesk(desk);

            var pawn = new Pawn(true, desk.board[6][1]);
            pawn.Move(desk.board[6][1]);
            pawn.Active = true;

            player.CheckFigureSubscription(pawn);
            Assert.True(pawn.Subcribed);
        }
        [Fact]
        public void CanBeClicked()
        {
            PcPlayer player = new PcPlayer();
            var desk = new Desk();
            desk.WhitesTurn = true;
            player.AddDesk(desk);

            var pawn = new Pawn(true, desk.board[6][1]);
            pawn.Move(desk.board[6][1]);
            pawn.Active = true;

            player.CheckFigureSubscription(pawn);
            player.e.point = pawn.Position + new Point(10, 10);

            var testPositionChange = new PositionChange();
            player.Invoke(new MouseClickEventArgs() { point = desk.board[6][1].Position, clickNumber = 1, positionChange = testPositionChange });
            Assert.Equal(pawn, testPositionChange.startingFigure);
            Assert.True(pawn.Selected);
        }
        [Fact]
        public void CanMakeSimpleMove()
        {
            var desk = new Desk();
            var pawn = new Pawn(true, desk.board[6][1]);
            pawn.Move(desk.board[6][1]);
            pawn.Active = true;

            pawn.Move(desk.board[5][1]);

            Assert.Equal(desk.board[5][1], pawn.cell);
            Assert.Equal(pawn, desk.board[5][1].figure);

        }
        [Fact]
        public void CanMakeNormalMove()
        {
            var desk = new Desk();
            var pawn = new Pawn(true, desk.board[6][1]);
            pawn.Move(desk.board[6][1]);
            pawn.Active = true;

            pawn.Move(desk.board[6][1], desk.board[5][1]);

            Assert.Equal(desk.board[5][1], pawn.cell);
            Assert.Equal(pawn, desk.board[5][1].figure);

        }
        [Fact]
        public void CanMakeAttackMove()
        {
            var desk = new Desk();
            var pawn = new Pawn(true, desk.board[6][1]);
            pawn.Move(desk.board[6][1]);

            var enemyPawn = new Pawn(false, desk.board[5][2]);
            pawn.Move(desk.board[5][2]);
            enemyPawn.Active = true;

            pawn.Move(desk.board[6][1], desk.board[5][2], enemyPawn);

            Assert.Equal(desk.board[5][2], pawn.cell);
            Assert.Equal(pawn, desk.board[5][2].figure);

            Assert.False(enemyPawn.Active);

        }
    }
}
