using ChessGL.Figures;
using ChessGL.Moves;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ChessGL.Control.Buttons;

namespace ChessGL
{
    public class Game1 : Game
    {
        List<Cell> currentPath;

        RotateBoardButton rotateBoardButton;

        Texture2D queenTexture;
        Texture2D deskTexture;
        MouseClickEventArgs e;
        //private MouseState lastMouseState = new MouseState();
        TwoStageMouse mouse;
        bool entitySelected = false;
        bool whitesMove = true;
        bool mousePressed = false;
        //ISelectableEntity selectedEntity;
        Figure selectedFigure;

        Vector2 queenPosition;

        Queen whiteQueen;
        King whiteKing;
        //Pawn blackPawn;

        SpriteFont font;
        string pressed = "Pressed";
        string notPressed = "Not Pressed";

        string message = "Init";
        List<Figure> figureList;
        Desk desk;
        //MouseState mouse;



        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1000;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 1000;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
            //base.Window.
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            currentPath = new List<Cell>();
            mouse = new TwoStageMouse();
            desk = new Desk(0.7f);
            figureList = new List<Figure>();
            e = new MouseClickEventArgs();
            rotateBoardButton = new RotateBoardButton(desk);
            rotateBoardButton.LoadTexture(Content.Load<Texture2D>("rotate_board"));
            rotateBoardButton.Position = desk.board[3][7].Position + new Point(150, 100);
            MouseClickEvent += rotateBoardButton.MouseClickEvent;

            var blackQueen = new Queen(false, desk.board[0][3]);
            blackQueen.Move(desk.board[0][3]);
            blackQueen.LoadTexture(Content.Load<Texture2D>("black_queen"));
            figureList.Add(blackQueen);

            var blackKing = new King(false, desk.board[0][4]);
            blackKing.Move(desk.board[0][4]);
            blackKing.LoadTexture(Content.Load<Texture2D>("black_king"));
            blackKing.attackedTexture = Content.Load<Texture2D>("king_attacked");
            figureList.Add(blackKing);

            whiteQueen = new Queen(true, desk.board[7][3]);
            //whiteQueen.Position = new Point(100, 100);
            figureList.Add(whiteQueen);

            whiteKing = new King(true, desk.board[7][4]);
            //whiteKing.Position = new Point(200, 100);
            whiteKing.attackedTexture = Content.Load<Texture2D>("king_attacked");
            whiteKing.Move(desk.board[7][4]);
            figureList.Add(whiteKing);

            var whiteBishop1 = new Bishop(true, desk.board[7][5]);
            whiteBishop1.Move(desk.board[7][5]);
            whiteBishop1.LoadTexture(Content.Load<Texture2D>("white_bishop"));
            figureList.Add(whiteBishop1);
            var whiteBishop2 = new Bishop(true, desk.board[7][2]);
            whiteBishop2.Move(desk.board[7][2]);
            whiteBishop2.LoadTexture(Content.Load<Texture2D>("white_bishop"));
            figureList.Add(whiteBishop2);

            var blackBishop1 = new Bishop(false, desk.board[0][5]);
            blackBishop1.Move(desk.board[0][5]);
            blackBishop1.LoadTexture(Content.Load<Texture2D>("black_bishop"));
            figureList.Add(blackBishop1);
            var blackBishop2 = new Bishop(false, desk.board[0][2]);
            blackBishop2.Move(desk.board[0][2]);
            blackBishop2.LoadTexture(Content.Load<Texture2D>("black_bishop"));
            figureList.Add(blackBishop2);

            var whiteRook1 = new Rook(true, desk.board[7][7]);
            whiteRook1.Move(desk.board[7][7]);
            whiteRook1.LoadTexture(Content.Load<Texture2D>("white_rook"));
            figureList.Add(whiteRook1);
            var whiteRook2 = new Rook(true, desk.board[7][0]);
            whiteRook2.Move(desk.board[7][0]);
            whiteRook2.LoadTexture(Content.Load<Texture2D>("white_rook"));
            figureList.Add(whiteRook2);

            var blackRook1 = new Rook(false, desk.board[0][7]);
            blackRook1.Move(desk.board[0][7]);
            blackRook1.LoadTexture(Content.Load<Texture2D>("black_rook"));
            figureList.Add(blackRook1);
            var blackRook2 = new Rook(false, desk.board[0][0]);
            blackRook2.Move(desk.board[0][0]);
            blackRook2.LoadTexture(Content.Load<Texture2D>("black_rook"));
            figureList.Add(blackRook2);

            var whiteKnight1 = new Knight(true, desk.board[7][6]);
            whiteKnight1.Move(desk.board[7][6]);
            whiteKnight1.LoadTexture(Content.Load<Texture2D>("white_knight"));
            figureList.Add(whiteKnight1);
            var whiteKnight2 = new Knight(true, desk.board[7][1]);
            whiteKnight2.Move(desk.board[7][1]);
            whiteKnight2.LoadTexture(Content.Load<Texture2D>("white_knight"));
            figureList.Add(whiteKnight2);

            var blackKnight1 = new Knight(false, desk.board[0][6]);
            blackKnight1.Move(desk.board[0][6]);
            blackKnight1.LoadTexture(Content.Load<Texture2D>("black_knight"));
            figureList.Add(blackKnight1);
            var blackKnight2 = new Knight(false, desk.board[0][1]);
            blackKnight2.Move(desk.board[0][1]);
            blackKnight2.LoadTexture(Content.Load<Texture2D>("black_knight"));
            figureList.Add(blackKnight2);


            //Init pawns
            for (int i = 0; i < 8; i++)
            {
                var blackPawn = new Pawn(false, desk.board[1][i]);
                //blackPawn.white = ;
                blackPawn.LoadTexture(Content.Load<Texture2D>(blackPawn.thisTexturePath));
                //desk.board[6][i].figure = blackPawn;
                //desk.board[6][i].Empty = false;
                //blackPawn.Position = desk.board[6][i].Position;
                blackPawn.Move(desk.board[1][i]);
                Debug.WriteLine($"Pawn {i} Pos{blackPawn.Position.ToString()}");
                figureList.Add(blackPawn);

            }
            for (int i = 0; i < 8; i++)
            {
                var whitePawn = new Pawn(true, desk.board[6][i]);
                whitePawn.LoadTexture(Content.Load<Texture2D>(whitePawn.thisTexturePath));
                whitePawn.Move(desk.board[6][i]);
                //Debug.WriteLine($"Pawn {i} Pos{whitePawn.Position.ToString()}");
                figureList.Add(whitePawn);

            }
            foreach (var figure in figureList)
            {
                //figure.ToDefaultPosition();
                this.MouseClickEvent += figure.MouseClickEvent;

            }
            foreach (var row in desk.board)
            {
                foreach (var cell in row)
                {
                    // figure.ToDefaultPosition();
                    this.MouseClickEvent += cell.MouseClickEvent;
                    cell.LoadTexture(Content.Load<Texture2D>("green_circle"), Content.Load<Texture2D>("frame"));
                    //foreach (var figure in figureList) {
                    //    cell.CellClickEvent += figure.CellClickEvent;
                    // }
                }
            }
            desk.board[7][3].figure = whiteQueen;
            desk.board[7][3].Empty = false;
            whiteQueen.Position = desk.board[7][3].Position;
            desk.board[7][4].figure = whiteKing;
            desk.board[7][4].Empty = false;
            whiteKing.Position = desk.board[7][4].Position;


            //queenPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,_graphics.PreferredBackBufferHeight / 2);
            base.Initialize();
            base.Window.AllowUserResizing = true;
            //mouse = new MouseState();
        }

        private void Game1_MouseClickEvent(object sender, MouseClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void LoadContent()
        {
            deskTexture = Content.Load<Texture2D>("desk");

            whiteQueen.LoadTexture(Content.Load<Texture2D>("white_queen"));
            whiteKing.LoadTexture(Content.Load<Texture2D>("white_king"));
            //blackPawn.LoadTexture(Content.Load<Texture2D>("black_pawn"));

            font = Content.Load<SpriteFont>("basicFont");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                //_graphics.ToggleFullScreen();
                _graphics.PreferredBackBufferWidth = 1000;
                _graphics.PreferredBackBufferHeight = 1000;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.R))
            {
                desk.ToDefaultSet();
                foreach (var figure in figureList)
                {
                    if (!figure.Active)
                    {
                        MouseClickEvent += figure.MouseClickEvent;
                        figure.Active = true;
                    }
                    whitesMove = true;
                    figure.ToDefaultPosition();
                }
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                desk.RotateBoard();
                Debug.WriteLine("Desk rotated");
            }
                // TODO: Add your update logic here
            var newMouse = Mouse.GetState();
            //var kstate = Keyboard.GetState();
            //MouseClickEvent(this, new MouseClickEventArgs { point = mouse.Position, mouse = mouse });

            int mouseAnswer = mouse.CheckClick(newMouse);
            e.point = newMouse.Position;
            e.mouse = newMouse;
            if (mouseAnswer == 1)
            {
                message = "1st click";
                e.clickNumber = 1;
                MouseClickEvent(this, e);
                if (e.startingFigure == null)
                {
                    
                    mouse.firstClick = true;
                    e.startingCell = null;
                    e.endingCell = null;
                    e.endingFigure = null;
                    e.startingFigure = null;

                }
                else if (e.startingFigure.white != whitesMove) {
                    e.startingFigure.Selected = false;
                    mouse.firstClick = true;
                    e.startingCell = null;
                    e.endingCell = null;
                    e.endingFigure = null;
                    e.startingFigure = null;
                }
                else
                {
                    currentPath =  desk.ShowPath(e.startingCell, e.startingFigure);
                }

            }
            else if (mouseAnswer == 2)
            {
                desk.ShutPath();

                e.clickNumber = 2;
                MouseClickEvent(this, e);
                message = "2nd click";
                //Debug.WriteLine($"START {e.startingCell?.ToString()} {e.startingFigure?.ToString()}"
                //    + $"\nEND {e.endingCell?.ToString()} {e.endingFigure?.ToString()}");
                if (e.startingFigure != null && e.endingCell != null)
                {
                    //check move
                    //etc
                    if (e.endingFigure == null)
                    {
                        if (currentPath.Contains(e.endingCell))
                        {
                            e.startingFigure.Move(e.startingCell, e.endingCell);
                            whitesMove = !whitesMove;

                        }
                    }
                    else
                    {
                        if (e.endingFigure.white ^ e.startingFigure.white)
                        {
                            //if (e.startingFigure.PossibleMove(e.startingCell, e.endingCell))
                            if (currentPath.Contains(e.endingCell))
                            {
                                e.startingFigure.Move(e.startingCell, e.endingCell, e.endingFigure);
                                whitesMove = !whitesMove;
                            }
                        }
                    }
                    Debug.WriteLine("WHITE KING ATTACKED = " + whiteKing.IsAttacked(desk).ToString());
                    
                }
                e.startingCell = null;
                e.endingCell = null;
                e.endingFigure = null;
                e.startingFigure = null;
            }
            else
            {
                message = "release";
            }

            message += " X: " + newMouse.X.ToString() + " Y: " + newMouse.Y.ToString() + " ";
            message += entitySelected.ToString();
            message += " X: " + selectedFigure?.Position.X.ToString() + " Y: " + selectedFigure?.Position.Y.ToString() + " ";
            message += "WhitesMove = " + whitesMove.ToString();
            foreach (var figure in figureList)
            {
                if (!figure.Active) { MouseClickEvent -= figure.MouseClickEvent; }
            }
            //figureList.RemoveAll(x => x.Active == false);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(deskTexture, new Vector2(0, 30), null, Color.White, 0, new Vector2(0, 0), 0.7f, SpriteEffects.None, 0);
            //_spriteBatch.Draw(queenTexture, queenPosition, null,  Color.White, 0, new Vector2(queenTexture.Width/2, queenTexture.Height/2), 0.15f, SpriteEffects.None, 1);
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
            _spriteBatch.DrawString(font, message, new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(font, whitesMove.ToString(), new Vector2(800, 0), Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        protected virtual void OnMouseClick(Game game, MouseClickEventArgs e)
        {
            MouseClickEvent?.Invoke(this, e);
        }
        public event EventHandler<MouseClickEventArgs> MouseClickEvent;
    }
    public class MouseClickEventArgs : EventArgs
    {
        public Point point;
        public MouseState mouse;
        public int clickNumber;
        public Cell? startingCell;
        public Figure? startingFigure;
        public Cell? endingCell;
        public Figure? endingFigure;
    }
}
