namespace BravoGame
{
    #region Usings

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The ui.
    /// </summary>
    public class UI
    {
        /// <summary>
        /// The Font.
        /// </summary>
        public SpriteFont Font;

        /// <summary>
        /// The health bar.
        /// </summary>
        public QuantityDisplayBar HealthBar;

        /// <summary>
        /// Initializes a new instance of the <see cref="UI"/> class.
        /// </summary>
        public UI()
        {
            this.Font = Globals.Content.Load<SpriteFont>(@"Fonts\GameFont");
            this.HealthBar = new QuantityDisplayBar(new Vector2(104, 16), 2, Color.Red);
        }

        /// <summary>
        /// The draw.
        /// </summary>
        /// <param name="world">
        /// The world.
        /// </param>
        public void Draw(World world)
        {
            var tempString = $"Score = {world.Score}\nMiss = {world.Miss}";
            var stringDimensions = this.Font.MeasureString(tempString);
            Globals.spriteBatch.DrawString(
                this.Font,
                tempString,
                new Vector2(
                    Globals.ScreenWidth / 2 - stringDimensions.X / 2,
                    Globals.ScreenHeight - stringDimensions.Y),
                Color.Black);

            this.HealthBar.Draw(new Vector2(20, Globals.ScreenHeight - 40));

            if (world.Hero.Dead)
            {
                tempString = $"You lost! Press Enter to Restart";
                stringDimensions = this.Font.MeasureString(tempString);
                Globals.spriteBatch.DrawString(
                    this.Font,
                    tempString,
                    new Vector2(Globals.ScreenWidth / 2 - stringDimensions.X / 2, Globals.ScreenHeight / 2),
                    Color.Black);
            }

            if (GameGlobals.Pause)
            {
                tempString = $"Paused";
                stringDimensions = this.Font.MeasureString(tempString);
                Globals.spriteBatch.DrawString(
                    this.Font,
                    tempString,
                    new Vector2(Globals.ScreenWidth / 2 - stringDimensions.X / 2, Globals.ScreenHeight / 2),
                    Color.Black);
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="world">
        /// The world.
        /// </param>
        public void Update(World world)
        {
            this.HealthBar.Update(world.Hero.Health, world.Hero.HealthMax);
        }
    }
}