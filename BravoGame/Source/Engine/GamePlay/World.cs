#region Includes

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace BravoGame
{
    public class World
    {
        public int FirstNumber;
        public int SecondNumer;
        public int Result;

        public int Score;
       
        public SpriteFont font;

        public Vector2 Offset;
        public Hero Hero;
        public UI UI;

        public List<Projectile2d> Projectiles;
        public List<Mob> Mobs = new List<Mob>();
        public SpawnPoint SpawnPoint;

        public World()
        {
            Projectiles = new List<Projectile2d>();
            SpawnPoint = new SpawnPoint();

            Score = 0;

            Hero = new Hero(@"Heroes\Hero", new Vector2(Globals.ScreenWidth / 2, Globals.ScreenHeight / 2 + 200), new Vector2(46, 60));
            GameGlobals.PassProjectiles = AddProjectiles;
            GameGlobals.PassMob = AddMobs;
            Offset = new Vector2(0, 0);

            font = Globals.Content.Load<SpriteFont>(@"Fonts\GameFont");
            MathOperation();

            UI = new UI();
        }

        private void MathOperation()
        {
            var random = new Random();
            FirstNumber = random.Next(1, 100);
            SecondNumer = random.Next(1, 100);
            Result = FirstNumber + FirstNumber;
        }

        public virtual void Update()
        {
            Hero.Update(Offset);

            SpawnPoint.Update(Offset);

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
                    Score++;
                    Mobs.RemoveAt(i);
                    i--;
                }
            }

            UI.Update(this);
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

            UI.Draw(this);

            string tempString = $"{FirstNumber} + {SecondNumer} = ?";
            Vector2 stringDimensions = font.MeasureString(tempString);
            Globals.spriteBatch.DrawString(font, tempString, new Vector2(Globals.ScreenWidth - stringDimensions.X - 10, Globals.ScreenHeight - stringDimensions.Y), Color.Black);
        }
    }
}
