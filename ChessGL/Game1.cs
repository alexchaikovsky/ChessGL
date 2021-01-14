using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;
using System.Collections.Generic;
using ChessGL.Figures;

namespace ChessGL
{
    public class Game1 : Game
    {
        Texture2D queenTexture;
        Texture2D deskTexture;

        Vector2 queenPosition;

        Queen whiteQueen;
        King whiteKing;

        SpriteFont font;
        string pressed = "Pressed";
        string notPressed = "Not Pressed";

        string message = "Init";
        List <Figure> figureList;
        //MouseState mouse;


        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1000;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 1000;   // set this value to the desired height of your window
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            figureList = new List<Figure>();

            whiteQueen = new Queen();
            whiteQueen.Position = new Point(100, 100);
            figureList.Add(whiteQueen);

            whiteKing = new King();
            whiteKing.Position = new Point(200, 100);
            figureList.Add(whiteKing);
            //queenPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,_graphics.PreferredBackBufferHeight / 2);
            base.Initialize();
            //base.Window.AllowUserResizing = true;
            //mouse = new MouseState();
        }

        protected override void LoadContent()
        {
            deskTexture = Content.Load<Texture2D>("desk");
            //queenTexture = Content.Load<Texture2D>("white_queen");
            whiteQueen.LoadTexture(Content.Load<Texture2D>("white_queen"));
            whiteKing.LoadTexture(Content.Load<Texture2D>("white_king"));
            font = Content.Load<SpriteFont>("basicFont");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _graphics.ToggleFullScreen();
            }

            // TODO: Add your update logic here
            var mouse = Mouse.GetState();
            var kstate = Keyboard.GetState();

            //if (kstate.IsKeyDown(Keys.Up))
            //Figure movingFigure;
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                message = pressed;
                foreach (var figure in figureList)
                {
                    if (figure.PointInFigureArea(mouse.Position))
                    {
                       figure.Position = mouse.Position;
                    }
                }
                //queenPosition = mouse.Position.ToVector2();
                //whiteQueen.Position = mouse.Position;
                // queenPosition.X = mouse.X;
                // queenPosition.Y = mouse.Y;
            }
            else
            {
                message = notPressed;
            }
            
            message += " X: " + mouse.X.ToString() + " Y: " + mouse.Y.ToString();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(deskTexture, new Vector2(0, 30), null, Color.White, 0, new Vector2(0, 0), 0.7f, SpriteEffects.None, 0);
            //_spriteBatch.Draw(queenTexture, queenPosition, null,  Color.White, 0, new Vector2(queenTexture.Width/2, queenTexture.Height/2), 0.15f, SpriteEffects.None, 1);
            foreach (var figure in figureList)
            {
                figure.Draw(_spriteBatch);
            }
            _spriteBatch.DrawString(font, message, new Vector2(0, 0), Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
