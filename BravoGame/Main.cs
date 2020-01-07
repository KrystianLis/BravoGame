namespace BravoGame
{
    #region Usings

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    #endregion

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : Game
    {
        /// <summary>
        /// The cursor.
        /// </summary>
        Basic2d cursor;

        /// <summary>
        /// The game play.
        /// </summary>
        GamePlay gamePlay;

        /// <summary>
        /// The graphics.
        /// </summary>
        readonly GraphicsDeviceManager graphics;

        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.Content.RootDirectory = "Content";
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">
        /// Provides a snapshot of timing values.
        /// </param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            this.gamePlay.Draw();
            this.cursor.Draw(
                new Vector2(Globals.Mouse.NewMousePosition.X, Globals.Mouse.NewMouse.Y),
                new Vector2(0, 0),
                Color.White);

            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Globals.ScreenWidth = 1024;
            Globals.ScreenHeight = 768;

            this.graphics.PreferredBackBufferWidth = Globals.ScreenWidth;
            this.graphics.PreferredBackBufferHeight = Globals.ScreenHeight;
            this.graphics.ApplyChanges();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Globals.Content = this.Content;
            Globals.spriteBatch = new SpriteBatch(this.GraphicsDevice);

            this.cursor = new Basic2d(@"Cursor\cursor", new Vector2(0, 0), new Vector2(24, 24));

            Globals.Keyboard = new MyKeyboard();
            Globals.Mouse = new MyMouseControl();

            this.gamePlay = new GamePlay();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">
        /// Provides a snapshot of timing values.
        /// </param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape)) this.Exit();

            Globals.GameTime = gameTime;
            Globals.Keyboard.Update();
            Globals.Mouse.Update();

            this.gamePlay.Update();

            Globals.Keyboard.UpdateOld();
            Globals.Mouse.UpdateOld();

            base.Update(gameTime);
        }
    }

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            using (var game = new Main()) game.Run();
        }
    }
#endif
}