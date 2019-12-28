#region Includes

using Microsoft.Xna.Framework;

#endregion

namespace BravoGame
{
    public class FirstMob : Mob
    {
        public FirstMob(Vector2 position) : base(@"Mobs\FirstMob", position, new Vector2(40, 40))
        {
            Speed = 2.0f;
        }

        public override void Update(Vector2 offset, Hero hero)
        {
            base.Update(offset, hero);
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
