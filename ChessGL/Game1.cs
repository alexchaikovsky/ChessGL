using ChessGL.Figures;
using ChessGL.Moves;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using ChessGL.Control.Buttons;
using ChessGL.Menu;
using ChessGL.Control;
using ChessGL.Player;



namespace ChessGL
{
    public class Game1 : Game
    {
        Match match;
        bool MatchStarted;

        //StartTestMatchButton startTestMatchButton;
        StartMenu startMenu;
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
            startMenu = new StartMenu();
            startMenu.LoadButtons(Content.Load<Texture2D>("menu_button"), Content.Load<Texture2D>("engine_menu_button"));
           
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
                if (match.MatchEnded)
                {
                    MatchStarted = false;
                }
                
            }
            else
            {
                switch(startMenu.Update())
                {
                    case 1:
                        match = new Match(this, _spriteBatch, new PcPlayer(), new PcPlayer());
                        match.LoadButtons();
                        match.CreateFigures();
                        MatchStarted = true;
                        Window.Position = new Point(0, 30);
                        _graphics.PreferredBackBufferWidth = 1200;
                        _graphics.PreferredBackBufferHeight = 1000;
                        _graphics.ApplyChanges();
                        break;
                    case 2:
                        match = new Match(this, _spriteBatch, new PcPlayer(), new EnginePlayer());
                        match.LoadButtons();
                        match.CreateFigures();
                        MatchStarted = true;
                        Window.Position = new Point(0, 30);
                        _graphics.PreferredBackBufferWidth = 1200;
                        _graphics.PreferredBackBufferHeight = 1000;
                        _graphics.ApplyChanges();
                        break;
                    default:
                        break;
                }
                //if (startMenu.Update() == 1)
                //{
                    
                //    match = new Match(this, _spriteBatch);
                //    match.LoadButtons();
                //    match.CreateFigures();
                //    MatchStarted = true;
                //    Window.Position = new Point(0, 30);
                //    _graphics.PreferredBackBufferWidth = 1200;
                //    _graphics.PreferredBackBufferHeight = 1000;
                //    _graphics.ApplyChanges();
                //}

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
            else
            {
                startMenu.Draw(_spriteBatch);
            }
            //startTestMatchButton.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        

    }
    
}
