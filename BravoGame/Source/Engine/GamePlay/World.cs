#region Includes

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace BravoGame
{
    public class World
    {
        public Vector2 Offset;
        public Hero Hero;
        public List<Projectile2d> Projectiles = new List<Projectile2d>();
        public List<Mob> Mobs = new List<Mob>();
        public List<SpawnPoint> SpawnPoints = new List<SpawnPoint>();

        public World()
        {
            Hero = new Hero(@"Heroes\Hero", new Vector2(300, 300), new Vector2(25, 49));
            GameGlobals.PassProjectiles = AddProjectiles;
            GameGlobals.PassMob = AddMobs;
            Offset = new Vector2(0, 0);
            SpawnPoints.Add(new SpawnPoint(new Vector2(200, 200)));
            SpawnPoints.Add(new SpawnPoint(new Vector2(Globals.ScreenWidth / 2, 200)));
            SpawnPoints.Add(new SpawnPoint(new Vector2(Globals.ScreenWidth - 200, 200)));
        }

        public virtual void Update()
        {
            Hero.Update(Offset);

            for (int i = 0; i < SpawnPoints.Count; i++)
            {
                SpawnPoints[i].Update(Offset);
            }

            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Update(Offset, Mobs.ToList<Unit>());

                if(Projectiles[i].Done)
                {
                    Projectiles.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < Mobs.Count; i++)
            {
                Mobs[i].Update(Offset, Hero);

                if (Mobs[i].Dead)
                {
                    Mobs.RemoveAt(i);
                    i--;
                }
            }
        }

        public virtual void AddProjectiles(object info)
        {
            Projectiles.Add((Projectile2d)info);
        }

        public virtual void AddMobs(object info)
        {
            Mobs.Add((Mob)info);
        }

        public virtual void Draw(Vector2 offset)
        {
            Hero.Draw(offset);

            for (int i = 0; i < Projectiles.Count; i++)
            {
                Projectiles[i].Draw(offset);
            }

            for (int i = 0; i < Mobs.Count; i++)
            {
                Mobs[i].Draw(Offset);
            }
        }
    }
}
