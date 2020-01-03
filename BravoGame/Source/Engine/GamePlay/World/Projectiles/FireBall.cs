using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BravoGame
{
    public class FireBall : Projectile2d
    {

        public FireBall(Vector2 position, Unit owner, Vector2 target) : base(@"Projectiles\fireball", position, new Vector2(20, 20), owner, target)
        {

        }

        public override void Update(Vector2 offset, List<Unit> units)
        {
            base.Update(offset, units);
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
