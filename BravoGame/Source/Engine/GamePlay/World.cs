#region Includes

using Microsoft.Xna.Framework;
using System.Collections.Generic;

#endregion

namespace BravoGame
{
    public class World
    {
        public Vector2 offset;

        public Hero Hero;

        public List<Projectile2d> projectiles = new List<Projectile2d>();

        public World()
        {
            Hero = new Hero(@"Heroes\Hero", new Vector2(300, 300), new Vector2(25, 49));
            GameGlobals.PassProjectiles = AddProjectiles;
            offset = new Vector2(0, 0);
        }

        public virtual void Update()
        {
            Hero.Update();

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Update(offset, null);
            }
        }

        public virtual void AddProjectiles(object info)
        {
            projectiles.Add((Projectile2d)info);
        }

        public virtual void Draw(Vector2 offset)
        {
            Hero.Draw(offset);

            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].Draw(offset);
            }
        }
    }
}
