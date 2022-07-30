using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Threading;

using ChessGL.Control;
using ChessGL.Board;
using ChessGL.Control.Buttons;
using ChessGL.Core.Board;
using ChessGL.Core.Figures;
using ChessGL.Player;
using Figure = ChessGL.Figures.Figure;

namespace ChessGL
{
    public class Match
    {
        PositionChange currentChange;
        public RotateBoardButton rotateBoardButton;
        public PreviousPositionButton previousPositionButton;

        Texture2D deskTexture;
        MouseClickEventArgs e;
        Game game;

        Queen whiteQueen;
        King whiteKing;
        King blackKing;

        SpriteFont font;
        int lastLength;

        string message = "Init";
        List<Figure> figureList;
        Desk desk;
        //PcPlayer pcPlayer;
        //EnginePlayer enginePlayer;
        IPlayer whitesPlayer;
        IPlayer blacksPlayer;

        private SpriteBatch _spriteBatch;
        public bool MatchEnded { get; set; }
        public Match(Game game, SpriteBatch spriteBatch, IPlayer whitesPlayer, IPlayer blacksPlayer)
        {
            this._spriteBatch = spriteBatch;
            this.game = game;
            //mouse = new TwoStageMouse();
            desk = new Desk(0.7f);
            figureList = new List<Figure>();
            e = new MouseClickEventArgs();
            currentChange = new PositionChange();
            e.positionChange = currentChange;
            //pcPlayer = new PcPlayer(desk);
            //enginePlayer = new EnginePlayer(desk);
            this.whitesPlayer = whitesPlayer;
            this.blacksPlayer = blacksPlayer;
            this.whitesPlayer.AddDesk(desk);
            this.blacksPlayer.AddDesk(desk);
            MatchEnded = false;
            MoveMade = false;
            lastLength = 0;
        }
        public bool MoveMade { get; set; }
        public void CreateFigures()
        {
            
            var blackQueen = new Queen(false, desk.board[0][3]);
            blackQueen.Move(desk.board[0][3]);
            blackQueen.LoadTexture(game.Content.Load<Texture2D>("black_queen"));
            figureList.Add(blackQueen);

            blackKing = new King(false, desk.board[0][4]);
            blackKing.Move(desk.board[0][4]);
            blackKing.LoadTexture(game.Content.Load<Texture2D>("black_king"));
            blackKing.attackedTexture = game.Content.Load<Texture2D>("king_attacked");
            figureList.Add(blackKing);
            
            whiteQueen = new Queen(true, desk.board[7][3]);
            //whiteQueen.Position = new Point(100, 100);
            whiteQueen.Move(desk.board[7][3]);
            whiteQueen.LoadTexture(game.Content.Load<Texture2D>("white_queen"));
            
            figureList.Add(whiteQueen);

            whiteKing = new King(true, desk.board[7][4]);
            //whiteKing.Position = new Point(200, 100);
            whiteKing.LoadTexture(game.Content.Load<Texture2D>("white_king"));
            whiteKing.attackedTexture = game.Content.Load<Texture2D>("king_attacked");
            whiteKing.Move(desk.board[7][4]);
            figureList.Add(whiteKing);
            desk.AddKings(whiteKing, blackKing);
            var whiteBishop1 = new Bishop(true, desk.board[7][5]);
            whiteBishop1.Move(desk.board[7][5]);
            whiteBishop1.LoadTexture(game.Content.Load<Texture2D>("white_bishop"));
            figureList.Add(whiteBishop1);
            var whiteBishop2 = new Bishop(true, desk.board[7][2]);
            whiteBishop2.Move(desk.board[7][2]);
            whiteBishop2.LoadTexture(game.Content.Load<Texture2D>("white_bishop"));
            figureList.Add(whiteBishop2);

            var blackBishop1 = new Bishop(false, desk.board[0][5]);
            blackBishop1.Move(desk.board[0][5]);
            blackBishop1.LoadTexture(game.Content.Load<Texture2D>("black_bishop"));
            figureList.Add(blackBishop1);
            var blackBishop2 = new Bishop(false, desk.board[0][2]);
            blackBishop2.Move(desk.board[0][2]);
            blackBishop2.LoadTexture(game.Content.Load<Texture2D>("black_bishop"));
            figureList.Add(blackBishop2);

            var whiteRook1 = new Rook(true, desk.board[7][7]);
            whiteRook1.Move(desk.board[7][7]);
            whiteRook1.LoadTexture(game.Content.Load<Texture2D>("white_rook"));
            figureList.Add(whiteRook1);
            var whiteRook2 = new Rook(true, desk.board[7][0]);
            whiteRook2.Move(desk.board[7][0]);
            whiteRook2.LoadTexture(game.Content.Load<Texture2D>("white_rook"));
            figureList.Add(whiteRook2);

            var blackRook1 = new Rook(false, desk.board[0][7]);
            blackRook1.Move(desk.board[0][7]);
            blackRook1.LoadTexture(game.Content.Load<Texture2D>("black_rook"));
            figureList.Add(blackRook1);
            var blackRook2 = new Rook(false, desk.board[0][0]);
            blackRook2.Move(desk.board[0][0]);
            blackRook2.LoadTexture(game.Content.Load<Texture2D>("black_rook"));
            figureList.Add(blackRook2);

            var whiteKnight1 = new Knight(true, desk.board[7][6]);
            whiteKnight1.Move(desk.board[7][6]);
            whiteKnight1.LoadTexture(game.Content.Load<Texture2D>("white_knight"));
            figureList.Add(whiteKnight1);
            var whiteKnight2 = new Knight(true, desk.board[7][1]);
            whiteKnight2.Move(desk.board[7][1]);
            whiteKnight2.LoadTexture(game.Content.Load<Texture2D>("white_knight"));
            figureList.Add(whiteKnight2);

            var blackKnight1 = new Knight(false, desk.board[0][6]);
            blackKnight1.Move(desk.board[0][6]);
            blackKnight1.LoadTexture(game.Content.Load<Texture2D>("black_knight"));
            figureList.Add(blackKnight1);
            var blackKnight2 = new Knight(false, desk.board[0][1]);
            blackKnight2.Move(desk.board[0][1]);
            blackKnight2.LoadTexture(game.Content.Load<Texture2D>("black_knight"));
            figureList.Add(blackKnight2);


            //Init pawns
            for (int i = 0; i < 8; i++)
            {
                var blackPawn = new Pawn(false, desk.board[1][i]);
                //blackPawn.white = ;
                blackPawn.LoadTexture(game.Content.Load<Texture2D>(blackPawn.thisTexturePath));
                //desk.board[6][i].figure = blackPawn;
                //desk.board[6][i].Empty = false;
                //blackPawn.Position = desk.board[6][i].Position;
                blackPawn.Move(desk.board[1][i]);
                //Debug.WriteLine($"Pawn {i} Pos{blackPawn.Position.ToString()}");
                figureList.Add(blackPawn);

            }
            for (int i = 0; i < 8; i++)
            {
                var whitePawn = new Pawn(true, desk.board[6][i]);
                whitePawn.LoadTexture(game.Content.Load<Texture2D>(whitePawn.thisTexturePath));
                whitePawn.Move(desk.board[6][i]);
                //Debug.WriteLine($"Pawn {i} Pos{whitePawn.Position.ToString()}");
                figureList.Add(whitePawn);

            }
            foreach (var figure in figureList)
            {
                //figure.ToDefaultPosition();
                //pcPlayer.MouseClickEvent += figure.MouseClickEvent;
                if (figure.white) whitesPlayer.CheckFigureSubscription(figure);
                else blacksPlayer.CheckFigureSubscription(figure);
                //this.MouseClickEvent += figure.MouseClickEvent;
                figure.Subcribed = true;
                figure.Active = true;

            }
            foreach (var row in desk.board)
            {
                foreach (var cell in row)
                {
                    // figure.ToDefaultPosition();
                    //pcPlayer.MouseClickEvent += cell.MouseClickEvent;
                    //this.MouseClickEvent += cell.MouseClickEvent;
                    whitesPlayer.SubscribeCell(cell);
                    blacksPlayer.SubscribeCell(cell);
                    cell.LoadTexture(game.Content.Load<Texture2D>("green_circle"), game.Content.Load<Texture2D>("frame"));
                    //foreach (var figure in figureList) {
                    //    cell.CellClickEvent += figure.CellClickEvent;
                    // }
                }
            }
            desk.board[7][3].Figure = whiteQueen;
            desk.board[7][3].Empty = false;
            whiteQueen.Position = desk.board[7][3].Position;
            //desk.board[7][4].figure = whiteKing;
            //desk.board[7][4].Empty = false;

            whiteKing.AddRooks(whiteRook2, whiteRook1, desk.board[7][3], desk.board[7][5]);
            blackKing.AddRooks(blackRook2, blackRook1, desk.board[0][3], desk.board[0][5]);

            deskTexture = game.Content.Load<Texture2D>("desk");
            //whiteQueenTexture = Content.Load<Texture2D>("white_queen");
            //whiteQueen.LoadTexture(game.Content.Load<Texture2D>("white_queen"));
            //whiteKing.LoadTexture(Content.Load<Texture2D>("white_king"));
            //blackPawn.LoadTexture(Content.Load<Texture2D>("black_pawn"));

            font = game.Content.Load<SpriteFont>("basicFont");

        }

        public void LoadButtons()
        {
            rotateBoardButton = new RotateBoardButton(desk);
            rotateBoardButton.LoadTexture(game.Content.Load<Texture2D>("rotate_board"));
            rotateBoardButton.Position = desk.board[3][7].Position + new Point(150, 100);
            //pcPlayer.MouseClickEvent += rotateBoardButton.MouseClickEvent;

            previousPositionButton = new PreviousPositionButton(desk);
            previousPositionButton.LoadTexture(game.Content.Load<Texture2D>("back_arrow"));
            previousPositionButton.Position = desk.board[0][7].Position + new Point(150, 100);

            whitesPlayer.SubscribeButtons(this);
            blacksPlayer.SubscribeButtons(this);
            //pcPlayer.MouseClickEvent += previousPositionButton.MouseClickEvent;
            
        }

        public void Update()
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //{
            //    //_graphics.ToggleFullScreen();
            //    _graphics.PreferredBackBufferWidth = 1000;
            //    _graphics.PreferredBackBufferHeight = 1000;
            //}
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.R))
            {
                desk.ToDefaultSet();
                foreach (var figure in figureList)
                {
                    if (!figure.Active)
                    {
                        // TODO: Check reset
                        //pcPlayer.MouseClickEvent += figure.MouseClickEvent;
                        figure.Active = true;
                    }
                    //whitesMove = true;
                    figure.ToDefaultPosition();
                }
            }


           
            if (whitesPlayer.KingIsDead || blacksPlayer.KingIsDead)
            {
                MatchEnded = true;
            }
            if (desk.WhitesTurn)
            {
                whitesPlayer.Update();
                //desk.KingsAttacked();
            }
            else
            {
                blacksPlayer.Update();
                //desk.KingsAttacked();
                

            }
            if (desk.GetHistoryAsStringArray().Length != lastLength)
            {
                if (desk.KingsAttacked())
                {
                    int whitePossibleMovesNumber = 0; int blackPossibleMovesNumber = 0;

                    foreach (var figure in figureList)
                    {
                        if (figure.white && figure.Active)
                        whitePossibleMovesNumber += desk.ShowPath(figure.cell, figure).Count;
                        else if (!figure.white && figure.Active) blackPossibleMovesNumber += desk.ShowPath(figure.cell, figure).Count;
                    }
                    if (whitePossibleMovesNumber == 0)
                    {
                        //MatchEnded = true;
                        Debug.WriteLine("WHITE LOSE!");
                    }
                    else if (blackPossibleMovesNumber == 0)
                    {
                        //MatchEnded = true;
                        Debug.WriteLine("BLACK LOSE!");
                    }
                }
                
                message = desk.GetHistoryAsString();
                //message = "";
                //message += " X: " + selectedFigure?.Position.X.ToString() + " Y: " + selectedFigure?.Position.Y.ToString() + " ";
                //message += "WhitesMove = " + desk.WhitesTurn.ToString();
                foreach (var figure in figureList)
                {
                    if (figure.white) whitesPlayer.CheckFigureSubscription(figure);
                    else blacksPlayer.CheckFigureSubscription(figure);
                }
                lastLength = desk.GetHistoryAsStringArray().Length;
            }
        }

        public void Draw()
        {
            _spriteBatch.Draw(deskTexture, new Vector2(0, 30), null, Color.White, 0, new Vector2(0, 0), 0.7f, SpriteEffects.None, 0);
            foreach (var row in desk.board)
            {
                foreach (var cell in row)
                {
                    if (cell.Show)
                    {
                        cell.Draw(_spriteBatch);
                    }
                }
            }
            foreach (var figure in figureList)
            {
                if (figure.Active)
                {
                    figure.Draw(_spriteBatch);
                }
            }
            rotateBoardButton.Draw(_spriteBatch);
            previousPositionButton.Draw(_spriteBatch);
            _spriteBatch.DrawString(font, message, new Vector2(0, 0), Color.White);
            //_spriteBatch.DrawString(font, whitesMove.ToString(), new Vector2(800, 0), Color.White);
        }

    }
}
