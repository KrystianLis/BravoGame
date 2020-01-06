using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BravoGame
{
    public class TileBackground2d : Basic2d
    {
        public Vector2 BackgroundDimensions;

        public TileBackground2d(string path, Vector2 position, Vector2 dimensions, Vector2 backgroundDimensions) : base(path, position, new Vector2((float)Math.Floor(dimensions.X), (float)Math.Floor(dimensions.Y)))
        {
            BackgroundDimensions = new Vector2((float)Math.Floor(backgroundDimensions.X), (float)Math.Floor(backgroundDimensions.Y));
        }

        public override void Draw(Vector2 offset)
        {
            float numX = (float)Math.Ceiling(BackgroundDimensions.X / Dimensions.X);
            float numY = (float)Math.Ceiling(BackgroundDimensions.Y / Dimensions.Y);

            for (int i = 0; i < numX; i++)
            {
                for (int j = 0; j < numY; j++)
                {
                    if(i < numX - 1 && j < numY - 1)
                    {
                        base.Draw(offset + new Vector2(Dimensions.X / 2 + Dimensions.X * i, Dimensions.Y / 2 + Dimensions.Y * j));
                    }
                    else
                    {
                        float xLeft = Math.Min(Dimensions.X, BackgroundDimensions.X - (i * Dimensions.X));
                        float yLeft = Math.Min(Dimensions.Y, BackgroundDimensions.Y - (j * Dimensions.Y));

                        float xPercentLeft = Math.Min(1, xLeft / Dimensions.X);
                        float yPercentLeft = Math.Min(1, yLeft / Dimensions.Y);

                        Globals.spriteBatch.Draw(Model, new Rectangle((int)(Position.X + offset.X + Dimensions.X * i), (int)(Position.Y + offset.Y + Dimensions.Y * j), (int)Math.Ceiling(Dimensions.X * xPercentLeft), (int)Math.Ceiling(Dimensions.Y * yPercentLeft)), new Rectangle(0, 0, (int)(xPercentLeft * Model.Bounds.Width), (int)(yPercentLeft * Model.Bounds.Height)), Color.White, Rotation, new Vector2(0, 0), new SpriteEffects(), 0);
                    }
                }
            }
        }
    }
}
