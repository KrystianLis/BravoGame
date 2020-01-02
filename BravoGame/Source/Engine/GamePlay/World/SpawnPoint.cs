#region Includes

using Microsoft.Xna.Framework;

#endregion

namespace BravoGame
{
    public class SpawnPoint
    {
        public Vector2 Position;
        public MyTimer spawnTimer = new MyTimer(10000);

        public SpawnPoint(Vector2 position)
        {
            Position = position;
            SpawnMob();
        }

        public virtual void Update(Vector2 offset)
        {
            spawnTimer.UpdateTimer();

            if(spawnTimer.Test())
            {
                SpawnMob();
                spawnTimer.ResetToZero();
            }
        }

        public virtual void SpawnMob()
        {
            GameGlobals.PassMob(new FirstMob(new Vector2(Position.X, Position.Y)));
        }
    }
}
