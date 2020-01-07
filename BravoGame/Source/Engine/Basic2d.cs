namespace BravoGame
{
    #region Usings

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The basic 2 d.
    /// </summary>
    public class Basic2d
    {
        /// <summary>
        /// The model.
        /// </summary>
        public Texture2D Model;

        /// <summary>
        /// The position.
        /// </summary>
        public Vector2 Position, Dimensions;

        /// <summary>
        /// The rotation.
        /// </summary>
        public float Rotation;

        /// <summary>
        /// Initializes a new instance of the <see cref="Basic2d"/> class.
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
        public Basic2d(string path, Vector2 position, Vector2 dimensions)
        {
            this.Position = position;
            this.Dimensions = dimensions;

            this.Model = Globals.Content.Load<Texture2D>(path);
        }

        /// <summary>
        /// The draw.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public virtual void Draw(Vector2 offset)
        {
            if (this.Model != null)
            {
                Globals.spriteBatch.Draw(
                    this.Model,
                    new Rectangle(
                        (int)(this.Position.X + offset.X),
                        (int)(this.Position.Y + offset.Y),
                        (int)this.Dimensions.X,
                        (int)this.Dimensions.Y),
                    null,
                    Color.White,
                    this.Rotation,
                    new Vector2(this.Model.Bounds.Width / 2, this.Model.Bounds.Height / 2),
                    new SpriteEffects(),
                    0);
            }
        }

        /// <summary>
        /// The draw.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        /// <param name="origin">
        /// The origin.
        /// </param>
        /// <param name="color">
        /// The color.
        /// </param>
        public virtual void Draw(Vector2 offset, Vector2 origin, Color color)
        {
            if (this.Model != null)
            {
                Globals.spriteBatch.Draw(
                    this.Model,
                    new Rectangle(
                        (int)(this.Position.X + offset.X),
                        (int)(this.Position.Y + offset.Y),
                        (int)this.Dimensions.X,
                        (int)this.Dimensions.Y),
                    null,
                    color,
                    this.Rotation,
                    new Vector2(origin.X, origin.Y),
                    new SpriteEffects(),
                    0);
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public virtual void Update(Vector2 offset)
        {
        }
    }
}