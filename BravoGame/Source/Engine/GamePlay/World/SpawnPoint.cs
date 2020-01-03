#region Includes

using Microsoft.Xna.Framework;

#endregion

namespace BravoGame
{
    public class SpawnPoint
    {
        public Vector2 Position;
        public MyTimer spawnTimer = new MyTimer(7000);

        public SpawnPoint()
        {
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
            GameGlobals.PassMob(new FirstMob(new Vector2(200, 200)));
            GameGlobals.PassMob(new FirstMob(new Vector2(Globals.ScreenWidth / 2, 200)));
            GameGlobals.PassMob(new FirstMob(new Vector2(Globals.ScreenWidth - 200, 200)));
        }
    }
}
