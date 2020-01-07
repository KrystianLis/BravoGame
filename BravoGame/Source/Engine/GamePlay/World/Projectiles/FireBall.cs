namespace BravoGame
{
    #region Usings

    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The fire ball.
    /// </summary>
    public class FireBall : Projectile2d
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FireBall"/> class.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        public FireBall(Vector2 position, Unit owner, Vector2 target)
            : base(@"Projectiles\fireball", position, new Vector2(20, 20), owner, target)
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
        /// <param name="units">
        /// The units.
        /// </param>
        public override void Update(Vector2 offset, List<Unit> units)
        {
            base.Update(offset, units);
        }
    }
}