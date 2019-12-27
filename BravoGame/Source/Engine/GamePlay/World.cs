#region Includes

using Microsoft.Xna.Framework;
using System.Collections.Generic;

#endregion

namespace BravoGame
{
    public class World
    {
        public Vector2 Offset;
        public Hero Hero;
        public List<Projectile2d> Projectiles = new List<Projectile2d>();

        public World()
        {
            Hero = new Hero(@"Heroes\Hero", new Vector2(300, 300), new Vector2(25, 49));
            GameGlobals.PassProjectiles = AddProjectiles;
            Offset = new Vector2(0, 0);
        }

        public virtual void Update()
        {
            Hero.Update();

            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Update(Offset, null);
            }
        }

        public virtual void AddProjectiles(object info)
        {
            Projectiles.Add((Projectile2d)info);
        }

        public virtual void Draw(Vector2 offset)
        {
            Hero.Draw(offset);

            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Draw(offset);
            }
        }
    }
}
