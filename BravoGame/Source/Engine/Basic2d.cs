#region Includes

using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;

#endregion

namespace BravoGame
{
    public class Basic2d
    {
        public float Rotation;
        public Vector2 Position, Dimensions;
        public Texture2D Model;

        public Basic2d(string path, Vector2 position, Vector2 dimensions)
        {
            Position = position;
            Dimensions = dimensions;

            Model = Globals.Content.Load<Texture2D>(path);
        }

        public virtual void Update(Vector2 offset)
        {

        }

        public virtual void Draw(Vector2 offset)
        {
            if(Model != null)
            {
                Globals.spriteBatch.Draw(Model, new Rectangle((int)(Position.X + offset.X), (int)(Position.Y + offset.Y), (int)Dimensions.X, (int)Dimensions.Y), null, Color.White, Rotation, new Vector2(Model.Bounds.Width / 2, Model.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }

        public virtual void Draw(Vector2 offset, Vector2 origin, Color color)
        {
            if (Model != null)
            {
                Globals.spriteBatch.Draw(Model, new Rectangle((int)(Position.X + offset.X), (int)(Position.Y + offset.Y), (int)Dimensions.X, (int)Dimensions.Y), null, color, Rotation, new Vector2(origin.X, origin.Y), new SpriteEffects(), 0);
            }
        }
    }
}
