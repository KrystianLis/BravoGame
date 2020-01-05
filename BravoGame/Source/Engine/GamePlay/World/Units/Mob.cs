#region Includes

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion

namespace BravoGame
{
    public class Mob : Unit
    {
        public SpriteFont font;

        public int Result;

        public Mob(string path, Vector2 position, Vector2 dimensions, int result) : base(path, position, dimensions)
        {
            Result = result;
            font = Globals.Content.Load<SpriteFont>(@"Fonts\GameFont");
        }

        public virtual void Update(Vector2 offset, Hero hero)
        {
            base.Update(offset);
        }

        public override void Draw(Vector2 offset)
        {
            string tempString = $"{Result}";
            Globals.spriteBatch.DrawString(font, tempString, new Vector2(Position.X, Position.Y - (float)(Dimensions.Y * 1.5)), Color.Black);
            base.Draw(offset);
        }
    }
}
