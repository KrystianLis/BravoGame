namespace BravoGame
{
    #region Usings

    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The first mob.
    /// </summary>
    public class FirstMob : Mob
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FirstMob"/> class.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        public FirstMob(Vector2 position, int result)
            : base(@"Mobs\death_scythe", position, new Vector2(40, 47), result)
        {
        }

        /// <summary>
        /// The draw.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public override void Draw(Vector2 offset)
        {
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
        public override void Update(Vector2 offset, Hero hero)
        {
            base.Update(offset, hero);
        }
    }
}