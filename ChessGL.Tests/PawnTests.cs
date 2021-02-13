using ChessGL.Player;
using ChessGL.Figures;
using ChessGL.Board;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Xunit;

namespace ChessGL.Tests
{
    public class PawnTests
    {
        [Fact]
        public void FindsCorrectPath()
        {
            var desk = new Desk();
            var pawn = new Pawn(true, desk.board[6][1]);
            pawn.Move(desk.board[6][1]);
            pawn.Active = true;
            pawn.Move(desk.board[6][1], desk.board[5][1]);
            Assert.Single(pawn.FindMove(desk.board[5][1], desk));
            Assert.Same(desk.board[4][1], pawn.FindMove(desk.board[5][1], desk)[0]);

        }
        [Fact]
        public void FindsCorrectAttackPath()
        {
            var desk = new Desk();
            var pawn = new Pawn(true, desk.board[6][1]);
            pawn.Move(desk.board[6][1]);
            pawn.Active = true;
            pawn.Move(desk.board[6][1], desk.board[5][1]);

            var enemyPawn1 = new Pawn(false, desk.board[4][0]);
            enemyPawn1.Move(desk.board[4][0]);
            enemyPawn1.Active = true;

            var enemyPawn2 = new Pawn(false, desk.board[4][2]);
            enemyPawn2.Move(desk.board[4][2]);
            enemyPawn2.Active = true;

            Assert.Equal(3, pawn.FindMove(desk.board[5][1], desk).Count);

        }
        [Fact]
        public void FindsCorrectPathFromDefaultPosition()
        {
            var desk = new Desk();
            var pawn = new Pawn(true, desk.board[6][1]);
            pawn.Move(desk.board[6][1]);
            pawn.Active = true;

            Assert.Equal(2, pawn.FindMove(desk.board[6][1], desk).Count);

        }
        // TODO: en passant
    }
}
