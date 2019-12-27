#region Includes

using Microsoft.Xna.Framework;

#endregion

namespace BravoGame
{
    public class Mob : Unit
    {
        public Mob(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            Speed = 2.0f;
        }

        public virtual void Update(Vector2 offset, Hero hero)
        {
            AI(hero);

            base.Update(offset);
        }

        public virtual void AI(Hero hero)
        {

        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
