#region Includes

using Microsoft.Xna.Framework;

#endregion

namespace BravoGame
{
    public class SpawnPoint
    {
        public Vector2 Position;
        public float hitDistance;
        public bool Dead;
        public MyTimer spawnTimer = new MyTimer(10000);

        public SpawnPoint(Vector2 position)
        {
            hitDistance = 35.0f;
            Position = position;
        }

        public virtual void GetHit()
        {
            Dead = true;
        }

        public virtual void Update(Vector2 offset)
        {
            spawnTimer.UpdateTimer();
            SpawnMob();

            if(spawnTimer.Test())
            {
                spawnTimer.ResetToZero();
            }
        }

        public virtual void SpawnMob()
        {
            GameGlobals.PassMob(new FirstMob(new Vector2(Position.X, Position.Y)));
        }
    }
}
