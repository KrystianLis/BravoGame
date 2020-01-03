using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BravoGame
{
    public class Projectile2d : Basic2d
    {
        public bool Done;
        public float Speed;
        public Vector2 Direction;
        public Unit Owner;
        public MyTimer Timer;

        public Projectile2d(string path, Vector2 position, Vector2 dimensions, Unit owner, Vector2 target) : base(path, position, dimensions)
        {
            Speed = 5.0f;
            Owner = owner;
            Direction = target - owner.Position;
            Direction.Normalize();
            Rotation = Globals.RotateTowards(position, new Vector2(target.X - 360, target.Y - 360));
            Timer = new MyTimer(4000);
        }

        public virtual void Update(Vector2 offset, List<Unit> units)
        {
            Position += Direction * Speed;

            Timer.UpdateTimer();

            if(Timer.Test())
            {
                Done = true;
            }

            if(HitSomething(units))
            {
                Done = true;
            }
        }

        public virtual bool HitSomething(List<Unit> units)
        {
            for (int i = 0; i < units.Count; i++)
            {
                if(Globals.GetDistance(Position, units[i].Position) < units[i].HitDistance)
                {
                    units[i].GetHit(1);

                    return true;
                }
            }

            return false;
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
