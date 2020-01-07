namespace BravoGame
{
    #region Usings

    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The projectile 2 d.
    /// </summary>
    public class Projectile2d : Basic2d
    {
        /// <summary>
        /// The direction.
        /// </summary>
        public Vector2 Direction;

        /// <summary>
        /// The done.
        /// </summary>
        public bool Done;

        /// <summary>
        /// The owner.
        /// </summary>
        public Unit Owner;

        /// <summary>
        /// The speed.
        /// </summary>
        public float Speed;

        /// <summary>
        /// The Timer.
        /// </summary>
        public MyTimer Timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Projectile2d"/> class.
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
        /// <param name="owner">
        /// The owner.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        public Projectile2d(string path, Vector2 position, Vector2 dimensions, Unit owner, Vector2 target)
            : base(path, position, dimensions)
        {
            this.Speed = 5.0f;
            this.Owner = owner;
            this.Direction = target - owner.Position;
            this.Direction.Normalize();
            this.Rotation = Globals.RotateTowards(position, new Vector2(target.X - 360, target.Y - 360));
            this.Timer = new MyTimer(4000);
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
        /// The hit something.
        /// </summary>
        /// <param name="units">
        /// The units.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public virtual bool HitSomething(List<Unit> units)
        {
            foreach (Unit t in units)
            {
                if (Globals.GetDistance(this.Position, t.Position) < t.HitDistance)
                {
                    t.GetHit(1);

                    return true;
                }
            }

            return false;
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
        public virtual void Update(Vector2 offset, List<Unit> units)
        {
            this.Position += this.Direction * this.Speed;

            this.Timer.UpdateTimer();

            if (this.Timer.Test())
            {
                this.Done = true;
            }

            if (this.HitSomething(units))
            {
                this.Done = true;
            }
        }
    }
}