namespace BravoGame
{
    #region Usings

    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The unit.
    /// </summary>
    public class Unit : Basic2d
    {
        /// <summary>
        /// The dead.
        /// </summary>
        public bool Dead;

        /// <summary>
        /// The speed.
        /// </summary>
        public float Speed, HitDistance, Health, HealthMax;

        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class.
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
        public Unit(string path, Vector2 position, Vector2 dimensions)
            : base(path, position, dimensions)
        {
            this.Speed = 2.0f;
            this.HitDistance = 30.0f;

            this.Health = 1;
            this.HealthMax = this.Health;
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
        /// The get hit.
        /// </summary>
        /// <param name="damage">
        /// The damage.
        /// </param>
        public virtual void GetHit(float damage)
        {
            this.Health -= damage;

            if (this.Health <= 0)
            {
                this.Dead = true;
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public override void Update(Vector2 offset)
        {
            base.Update(offset);
        }
    }
}