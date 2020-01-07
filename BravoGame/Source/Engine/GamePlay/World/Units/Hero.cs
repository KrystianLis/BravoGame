namespace BravoGame
{
    #region Usings

    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The hero.
    /// </summary>
    public class Hero : Unit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hero"/> class.
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
        public Hero(string path, Vector2 position, Vector2 dimensions)
            : base(path, position, dimensions)
        {
            this.Speed = 2.0f;
            this.Health = 5;
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
        /// The update.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public override void Update(Vector2 offset)
        {
            if (Globals.Keyboard.GetPress("A"))
            {
                this.Position = new Vector2(this.Position.X - this.Speed, this.Position.Y);
            }
            if (Globals.Keyboard.GetPress("D"))
            {
                this.Position = new Vector2(this.Position.X + this.Speed, this.Position.Y);
            }
            if (Globals.Keyboard.GetPress("W"))
            {
                this.Position = new Vector2(this.Position.X, this.Position.Y - this.Speed);
            }
            if (Globals.Keyboard.GetPress("S"))
            {
                this.Position = new Vector2(this.Position.X, this.Position.Y + this.Speed);
            }

            this.Rotation = Globals.RotateTowards(
                this.Position,
                new Vector2(Globals.Mouse.NewMousePosition.X, Globals.Mouse.NewMousePosition.Y));

            if (Globals.Mouse.LeftClick())
            {
                GameGlobals.PassProjectiles(
                    new FireBall(
                        new Vector2(this.Position.X, this.Position.Y),
                        this,
                        new Vector2(Globals.Mouse.NewMousePosition.X, Globals.Mouse.NewMousePosition.Y)));
            }

            base.Update(offset);
        }
    }
}