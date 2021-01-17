using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;
using System;
using System.Collections.Generic;
using ChessGL.Figures;
using ChessGL.Moves;
using System.Diagnostics;

namespace ChessGL
{
    public class Game1 : Game
    {
        Texture2D queenTexture;
        Texture2D deskTexture;
        MouseClickEventArgs e;
        //private MouseState lastMouseState = new MouseState();
        TwoStageMouse mouse;
        bool entitySelected = false;
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
        List <Figure> figureList;
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
            mouse = new TwoStageMouse();
            desk = new Desk(0.7f);
            figureList = new List<Figure>();
            e = new MouseClickEventArgs();
            whiteQueen = new Queen(true);
            //whiteQueen.Position = new Point(100, 100);
            figureList.Add(whiteQueen);

            whiteKing = new King(true);
            //whiteKing.Position = new Point(200, 100);
            figureList.Add(whiteKing);
            for (int i = 0; i < 8; i++)
            {
                var blackPawn = new Pawn(false);
                //blackPawn.white = true;
                blackPawn.LoadTexture(Content.Load<Texture2D>(blackPawn.thisTexturePath));
                desk.board[6][i].figure = blackPawn;
                desk.board[6][i].Empty = false;
                blackPawn.Position = desk.board[6][i].Position;
                Debug.WriteLine($"Pawn {i} Pos{blackPawn.Position.ToString()}");
                figureList.Add(blackPawn);
                
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
                    cell.LoadTexture(Content.Load<Texture2D>("green_circle"));
                    //foreach (var figure in figureList) {
                    //    cell.CellClickEvent += figure.CellClickEvent;
                    // }
                }
            }
            desk.board[0][0].figure = whiteQueen;
            desk.board[0][0].Empty = false;
            whiteQueen.Position = desk.board[0][0].Position;
            desk.board[0][1].figure = whiteKing;
            desk.board[0][1].Empty = false;
            whiteKing.Position = desk.board[0][1].Position;

            
            //queenPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,_graphics.PreferredBackBufferHeight / 2);
            base.Initialize();
            base.Window.AllowUserResizing = true;
            //mouse = new MouseState();
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
                foreach (var figure in figureList)
                {
                    figure.ToDefaultPosition();
                }
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
                }
                else
                {
                    desk.ShowPath(e.startingCell, e.startingFigure);
                }
                
            }
            else if (mouseAnswer == 2)
            {
                desk.ShutPath();
                
                e.clickNumber = 2;
                MouseClickEvent(this, e);
                message = "2nd click";
                Debug.WriteLine($"START {e.startingCell?.ToString()} {e.startingFigure?.ToString()}"
                    + $"\nEND {e.endingCell?.ToString()} {e.endingFigure?.ToString()}");
                if (e.startingFigure != null && e.endingCell != null)
                {
                    //check move
                    //etc
                    if (e.endingFigure == null)
                    {
                        if (e.startingFigure.PossibleMove(e.startingCell, e.endingCell))
                        {
                            e.startingFigure.Position = e.endingCell.Position;
                            e.endingCell.Empty = false;
                            e.startingCell.Empty = true;

                        }
                    }
                    else
                    {
                        if (e.endingFigure.white ^ e.startingFigure.white)
                        {
                            if (e.startingFigure.PossibleMove(e.startingCell, e.endingCell))
                            {
                                e.startingFigure.Position = e.endingCell.Position;
                                e.endingCell.Empty = false;
                                e.endingFigure.Active = false;
                                e.startingCell.Empty = true;

                            }
                        }
                    }
                    e.startingCell = null;
                    e.endingCell = null;
                    e.endingFigure = null;
                    e.startingFigure = null;
                }
            }
            else
            {
                message = "release";
            }
            
            message += " X: " + newMouse.X.ToString() + " Y: " + newMouse.Y.ToString() + " ";
            message += entitySelected.ToString();
            message += " X: " + selectedFigure?.Position.X.ToString() + " Y: " + selectedFigure?.Position.Y.ToString() + " ";

            foreach(var figure in figureList)
            {
                if (!figure.Active) { MouseClickEvent -= figure.MouseClickEvent; }
            }
            figureList.RemoveAll(x => x.Active == false);

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
                figure.Draw(_spriteBatch);
            }
            _spriteBatch.DrawString(font, message, new Vector2(0, 0), Color.White);
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
    public class MouseClickEventArgs: EventArgs
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
