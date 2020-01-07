namespace BravoGame
{
    #region Usings

    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The quantity display bar.
    /// </summary>
    public class QuantityDisplayBar
    {
        /// <summary>
        /// The bar.
        /// </summary>
        public Basic2d Bar, BarBackground;

        /// <summary>
        /// The border.
        /// </summary>
        public int Border;

        /// <summary>
        /// The color.
        /// </summary>
        public Color Color;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityDisplayBar"/> class.
        /// </summary>
        /// <param name="dimensions">
        /// The dimensions.
        /// </param>
        /// <param name="border">
        /// The border.
        /// </param>
        /// <param name="color">
        /// The color.
        /// </param>
        public QuantityDisplayBar(Vector2 dimensions, int border, Color color)
        {
            this.Border = border;
            this.Color = color;

            this.Bar = new Basic2d(
                @"Misc\solid",
                new Vector2(0, 0),
                new Vector2(dimensions.X - border * 2, dimensions.Y - border * 2));
            this.BarBackground = new Basic2d(@"Misc\shade", new Vector2(0, 0), new Vector2(dimensions.X, dimensions.Y));
        }

        /// <summary>
        /// The draw.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public virtual void Draw(Vector2 offset)
        {
            this.BarBackground.Draw(offset, new Vector2(0, 0), Color.Black);
            this.Bar.Draw(offset + new Vector2(this.Border, this.Border), new Vector2(0, 0), this.Color);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="current">
        /// The current.
        /// </param>
        /// <param name="max">
        /// The max.
        /// </param>
        public virtual void Update(float current, float max)
        {
            this.Bar.Dimensions = new Vector2(
                current / max * (this.BarBackground.Dimensions.X - this.Border * 2),
                this.Bar.Dimensions.Y);
        }
    }
}