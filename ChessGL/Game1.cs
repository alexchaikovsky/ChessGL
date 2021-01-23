using ChessGL.Figures;
using ChessGL.Moves;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ChessGL.Control.Buttons;
using ChessGL.Board;
using ChessGL.Control;



namespace ChessGL
{
    public class Game1 : Game
    {
        Match match;
        bool MatchStarted;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1000;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 1000;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
            Window.Position = new Point(100, 100);
            //base.Window.
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            base.Window.AllowUserResizing = true;
            //mouse = new MouseState();
        }

       

        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            match = new Match(this, _spriteBatch);
            match.LoadButtons();
            match.CreateFigures();
            MatchStarted = true;

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                //_graphics.ToggleFullScreen();
                //_graphics.PreferredBackBufferWidth = 1000;
                //_graphics.PreferredBackBufferHeight = 1000;
               
            }
            if (MatchStarted)
            {
                match.Update();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
           
            _spriteBatch.Begin();
            if (MatchStarted)
            {
                match.Draw();
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
    
}
