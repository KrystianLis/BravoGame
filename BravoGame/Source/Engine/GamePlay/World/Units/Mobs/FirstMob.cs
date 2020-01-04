#region Includes

using Microsoft.Xna.Framework;

#endregion

namespace BravoGame
{
    public class FirstMob : Mob
    {
        public FirstMob(Vector2 position, int result) : base(@"Mobs\death_scythe", position, new Vector2(40, 47), result)
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
