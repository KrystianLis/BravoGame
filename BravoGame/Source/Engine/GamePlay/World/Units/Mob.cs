namespace BravoGame
{
    #region Usings

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The mob.
    /// </summary>
    public class Mob : Unit
    {
        /// <summary>
        /// The Font.
        /// </summary>
        public SpriteFont Font;

        /// <summary>
        /// The result.
        /// </summary>
        public int Result;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mob"/> class.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <param name="dimensions">
        /// The dimensions.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        public Mob(string path, Vector2 position, Vector2 dimensions, int result)
            : base(path, position, dimensions)
        {
            this.Result = result;
            this.Font = Globals.Content.Load<SpriteFont>(@"Fonts\GameFont");
        }

        /// <summary>
        /// The draw.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public override void Draw(Vector2 offset)
        {
            var tempString = $"{this.Result}";
            Globals.spriteBatch.DrawString(
                this.Font,
                tempString,
                new Vector2(this.Position.X, this.Position.Y - (float)(this.Dimensions.Y * 1.5)),
                Color.Black);
            base.Draw(offset);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        /// <param name="hero">
        /// The hero.
        /// </param>
        public virtual void Update(Vector2 offset, Hero hero)
        {
            base.Update(offset);
        }
    }
}