namespace BravoGame
{
    #region Usings

    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The tile background 2D.
    /// </summary>
    public class TileBackground2d : Basic2d
    {
        /// <summary>
        /// The background dimensions.
        /// </summary>
        public Vector2 BackgroundDimensions;

        /// <summary>
        /// Initializes a new instance of the <see cref="TileBackground2d"/> class.
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
        /// <param name="backgroundDimensions">
        /// The background dimensions.
        /// </param>
        public TileBackground2d(string path, Vector2 position, Vector2 dimensions, Vector2 backgroundDimensions)
            : base(path, position, new Vector2((float)Math.Floor(dimensions.X), (float)Math.Floor(dimensions.Y)))
        {
            this.BackgroundDimensions = new Vector2(
                (float)Math.Floor(backgroundDimensions.X),
                (float)Math.Floor(backgroundDimensions.Y));
        }

        /// <summary>
        /// The draw.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public override void Draw(Vector2 offset)
        {
            var numX = (float)Math.Ceiling(this.BackgroundDimensions.X / this.Dimensions.X);
            var numY = (float)Math.Ceiling(this.BackgroundDimensions.Y / this.Dimensions.Y);

            for (var i = 0; i < numX; i++)
            {
                for (var j = 0; j < numY; j++)
                {
                    if (i < numX - 1 && j < numY - 1)
                    {
                        base.Draw(
                            offset + new Vector2(
                                this.Dimensions.X / 2 + this.Dimensions.X * i,
                                this.Dimensions.Y / 2 + this.Dimensions.Y * j));
                    }
                    else
                    {
                        var xLeft = Math.Min(this.Dimensions.X, this.BackgroundDimensions.X - (i * this.Dimensions.X));
                        var yLeft = Math.Min(this.Dimensions.Y, this.BackgroundDimensions.Y - (j * this.Dimensions.Y));

                        var xPercentLeft = Math.Min(1, xLeft / this.Dimensions.X);
                        var yPercentLeft = Math.Min(1, yLeft / this.Dimensions.Y);

                        Globals.spriteBatch.Draw(
                            this.Model,
                            new Rectangle(
                                (int)(this.Position.X + offset.X + this.Dimensions.X * i),
                                (int)(this.Position.Y + offset.Y + this.Dimensions.Y * j),
                                (int)Math.Ceiling(this.Dimensions.X * xPercentLeft),
                                (int)Math.Ceiling(this.Dimensions.Y * yPercentLeft)),
                            new Rectangle(
                                0,
                                0,
                                (int)(xPercentLeft * this.Model.Bounds.Width),
                                (int)(yPercentLeft * this.Model.Bounds.Height)),
                            Color.White,
                            this.Rotation,
                            new Vector2(0, 0),
                            new SpriteEffects(),
                            0);
                    }
                }
            }
        }
    }
}