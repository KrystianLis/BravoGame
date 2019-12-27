using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BravoGame
{
    public class Projectile2d : Basic2d
    {
        public bool done;

        public float speed;

        public Vector2 direction;

        public Unit _owner;

        public MyTimer timer;

        public Projectile2d(string path, Vector2 position, Vector2 dimensions, Unit owner, Vector2 target) : base(path, position, dimensions)
        {
            done = false;
            speed = 5.0f;
            _owner = owner;
            direction = target - owner.Position;
            direction.Normalize();

            rotation = Globals.RotateTowards(position, new Vector2(target.X - 360, target.Y - 360));

            timer = new MyTimer(1200);
        }

        public virtual void Update(Vector2 offset, List<Unit> units)
        {
            Position += direction * speed;

            timer.UpdateTimer();

            if(timer.Test())
            {
                done = true;
            }

            if(HitSomething(units))
            {
                done = true;
            }
        }

        public virtual bool HitSomething(List<Unit> units)
        {
            return false;
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
