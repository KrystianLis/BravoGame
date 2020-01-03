#region Includes

using Microsoft.Xna.Framework;

#endregion

namespace BravoGame
{
    public class Unit : Basic2d
    {
        public float Speed, HitDistance, Health, HealthMax;
        public bool Dead;

        public Unit(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            Speed = 2.0f;
            HitDistance = 30.0f;

            Health = 1;
            HealthMax = Health;
        }

        public virtual void GetHit(float damage)
        {
            Health -= damage;
            
            if(Health <= 0)
            {
                Dead = true;
            }
        }

        public override void Update(Vector2 offset)
        {
            base.Update(offset);
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
