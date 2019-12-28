#region Includes

using Microsoft.Xna.Framework;

#endregion

namespace BravoGame
{
    public class SpawnPoint : Basic2d
    {
        public float hitDistance;
        public bool Dead;
        public MyTimer spawnTimer = new MyTimer(10000);

        public SpawnPoint(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            hitDistance = 35.0f;
        }

        public virtual void GetHit()
        {
            Dead = true;
        }

        public override void Update(Vector2 offset)
        {
            spawnTimer.UpdateTimer();
            SpawnMob();

            if(spawnTimer.Test())
            {
                spawnTimer.ResetToZero();
            }

            base.Update(offset);
        }

        public virtual void SpawnMob()
        {
            GameGlobals.PassMob(new FirstMob(new Vector2(Position.X, Position.Y)));
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
