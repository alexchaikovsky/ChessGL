using ChessGL.Board;
using ChessGL.Core.Board;
using ChessGL.Core.Figures;
using ChessGL.Figures;
using ChessGL.Moves;

using Xunit;

namespace ChessGL.Tests
{
    public class PositionChangeTests
    {

        [Fact]
        public void CanMakeChange()
        {
            var desk = new Desk();
            var whitePawn = new Pawn(true, desk.board[6][1]);
            whitePawn.Move(desk.board[6][1]);

            var positionChange = new PositionChange() { startingCell = whitePawn.cell, startingFigure = whitePawn, endingCell = desk.board[6][2], endingFigure = null };

            positionChange.MakeChange();

            Assert.Equal(whitePawn.cell, desk.board[6][2]);
            Assert.Equal(whitePawn, desk.board[6][2].Figure);
        }
        [Fact]
        public void CanEatFigure()
        {
            var desk = new Desk();
            var whitePawn = new Pawn(true, desk.board[6][1]);
            whitePawn.Move(desk.board[6][1]);
            
            

            var blackPawn = new Pawn(false, desk.board[5][2]);
            blackPawn.Move(desk.board[5][2]);

            var positionChange = new PositionChange() { 
                startingCell = whitePawn.cell, 
                startingFigure = whitePawn, 
                endingCell = blackPawn.cell, 
                endingFigure = blackPawn };

            positionChange.MakeChange();

            Assert.Equal(whitePawn.cell, desk.board[5][2]);
            Assert.Equal(whitePawn, desk.board[5][2].Figure);
            Assert.False(blackPawn.Active);
        }
        [Fact]
        public void CanReverseMove()
        {
            var desk = new Desk();
            var whitePawn = new Pawn(true, desk.board[6][1]);
            whitePawn.Move(desk.board[6][1]);
            whitePawn.Active = true;

            var positionChange = new PositionChange() { 
                startingCell = whitePawn.cell, 
                startingFigure = whitePawn, 
                endingCell = desk.board[6][2], 
                endingFigure = null };

            positionChange.MakeChange();
            positionChange.ReverseChange();

            Assert.Equal(whitePawn.cell, desk.board[6][1]);
            Assert.Equal(whitePawn, desk.board[6][1].Figure);
            Assert.True(whitePawn.Active);
        }
        [Fact]
        public void CanReverseEatMove()
        {
            var desk = new Desk();
            var whitePawn = new Pawn(true, desk.board[6][1]);
            whitePawn.Move(desk.board[6][1]);
            whitePawn.Active = true;
            var blackPawn = new Pawn(false, desk.board[5][2]);
            blackPawn.Move(desk.board[5][2]);
            blackPawn.Active = true;
            var positionChange = new PositionChange()
            {
                startingCell = whitePawn.cell,
                startingFigure = whitePawn,
                endingCell = blackPawn.cell,
                endingFigure = blackPawn
            };

            positionChange.MakeChange();
            positionChange.ReverseChange();

            Assert.Equal(whitePawn.cell, desk.board[6][1]);
            Assert.Equal(whitePawn, desk.board[6][1].Figure);

            Assert.Equal(blackPawn.cell, desk.board[5][2]);
            Assert.Equal(blackPawn, desk.board[5][2].Figure);

            Assert.True(blackPawn.Active);
            Assert.True(whitePawn.Active);
        }
        [Fact]
        public void CanCastleLeft()
        {
            var desk = new Desk();
            var rook = new Rook(true, desk.board[7][0]);
            rook.Move(desk.board[7][0]);
            
            var king = new King(true, desk.board[5][2]);
            king.Move(desk.board[5][2]);
            king.leftRook = rook;
            king.leftCell = desk.board[7][3];

            var positionChange = new PositionChange()
            {
                startingCell = desk.board[7][4],
                startingFigure = king,
                endingCell = desk.board[7][2],
                endingFigure = null
            };
            Assert.Null(desk.board[7][1].Figure);
            Assert.Null(desk.board[7][2].Figure);
            positionChange.MakeChange();

            Assert.Equal(king.cell, desk.board[7][2]);
            Assert.Equal(king, desk.board[7][2].Figure);

            Assert.Equal(rook, desk.board[7][3].Figure);
            Assert.Equal(rook.cell, desk.board[7][3]);

        }
        [Fact]
        public void CanReverseLeftCastle()
        {
            var desk = new Desk();
            var rook = new Rook(true, desk.board[7][0]);
            rook.Move(desk.board[7][0]);

            var king = new King(true, desk.board[5][2]);
            king.Move(desk.board[5][2]);
            king.leftRook = rook;
            king.leftCell = desk.board[7][3];

            var positionChange = new PositionChange()
            {
                startingCell = desk.board[7][4],
                startingFigure = king,
                endingCell = desk.board[7][2],
                endingFigure = null
            };
            Assert.Null(desk.board[7][1].Figure);
            Assert.Null(desk.board[7][2].Figure);

            positionChange.MakeChange();
            positionChange.ReverseChange();

            Assert.Equal(king.cell, desk.board[7][4]);
            Assert.Equal(king, desk.board[7][4].Figure);

            Assert.Equal(rook, desk.board[7][0].Figure);
            Assert.Equal(
                rook.cell, desk.board[7][0]);
        }

        public void Test()
        {
            var vkats = new string[] {"vkatotusya", "vkatotusya"};
		
            var x1 = () => true ? doVkat() : doVkatout();
            var x2 = () => {
                fun1();
                fun2();
            };
            var x3 = () => 1 != 0 ? x2() : setVkat(true);
            var x4 = (string vkat) => {
                x1();
                x3();
            };
		
            vkats.ForEach(x4);
        }
    }
}
