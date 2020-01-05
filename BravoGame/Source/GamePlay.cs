using Microsoft.Xna.Framework;

namespace BravoGame
{
    public class GamePlay
    {
        int playState;

        World world;

        public GamePlay()
        {
            playState = 0;
            ResetWorld(null);
        }

        public virtual void ResetWorld(object info)
        {
            world = new World(ResetWorld);
        }

        public void Update()
        {
            if(playState == 0)
            {
                world.Update();
            }
        }

        public virtual void Draw()
        {
            if (playState == 0)
            {
                world.Draw(Vector2.Zero);
            }
        }
    }
}
