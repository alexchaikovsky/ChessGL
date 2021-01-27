using Microsoft.Xna.Framework;
using ChessGL.Moves;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ChessGL.Board;

namespace ChessGL.Figures
{
    public class King : Figure
    {
        public Texture2D attackedTexture;
        List <IMove> attackMoves;
        CheckKing checkKing;
        public Rook leftRook;
        public Rook rightRook;
        public Cell leftCell;
        public Cell rightCell;

        public bool UnderAttack { get; set; }
        public King(bool white, Cell defaultCell)
        {
            Init();
            moveTypes.Add(new MoveKing());
            
            attackMoves = new List<IMove>();
            attackMoves.Add(new MoveStraight());
            attackMoves.Add(new MoveDiag());
            attackMoves.Add(new MovePawn());
            attackMoves.Add(new MoveKnight());
            attackMoves.Add(new MoveKing());
            checkKing = new CheckKing(white, attackMoves);
            checkKing.Move(defaultCell);
            UnderAttack = false;
            Moved = false;
            Castled = false;

            this.white = white;
            this.defaultCell = defaultCell;
            if (white)
            {
                thisTexturePath = "white_king";
            }
            else
            {
                this.defaultPosition = new Point(100, 100);
            }
        }
        public bool Moved { get; set; }
        public bool Castled { get; set; }
        public void AddRooks(Rook left, Rook right, Cell leftCell, Cell rightCell)
        {
            leftRook = left;
            rightRook = right;
            this.leftCell = leftCell;
            this.rightCell = rightCell;
        }

        public void Castle(bool left)
        {
            if (left) {
                leftRook.Move(leftRook.cell, leftCell);
            }
            else
            {
                rightRook.Move(rightRook.cell, rightCell);
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (UnderAttack)
            {
                spriteBatch.Draw(attackedTexture, Position.ToVector2(), null, Color.White, 0, new Vector2(0, 0), 0.15f, SpriteEffects.None, 1);
            }
            spriteBatch.Draw(texture, Position.ToVector2(), null, Color.White, 0, new Vector2(0, 0), 0.15f, SpriteEffects.None, 1);
        }
        public bool IsAttacked(Desk desk)
        {
            var attackPaths = checkKing.FindMove(cell, desk, false);
            foreach(var attackCell in attackPaths)
            {
                
                if (!attackCell.Empty)
                {
                    //attackCell.figure.PrintDebug();
                    var attackPath = attackCell.figure.FindMove(attackCell, desk, false);
                    var attacks = attackPath.FindAll(x => x.figure is King && x.figure.white == white);
                    if (attacks.Count != 0)
                    {
                        //UnderAttack = true;
                        return true;
                    }
                }
            }
            //UnderAttack = false;
            return false;
        }
    }
}
