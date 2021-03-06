﻿#region Includes

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
        public int Miss;

        public int Score;
       
        public SpriteFont font;

        public Vector2 Offset;

        public TileBackground2d TileBackground2D;
        public Hero Hero;
        public UI UI;

        public List<Projectile2d> Projectiles;
        public List<Mob> Mobs;
        public SpawnPoint SpawnPoint;

        PassObject ResetWorld;

        public World(PassObject reseWorld)
        {
            ResetWorld = reseWorld;

            GameGlobals.PassValues = GetValues;
            GameGlobals.PassProjectiles = AddProjectiles;
            GameGlobals.PassMob = AddMobs;
            GameGlobals.InvokeRemovingMobs = RemoveMobs;

            Projectiles = new List<Projectile2d>();
            Mobs = new List<Mob>();
            SpawnPoint = new SpawnPoint();

            Score = 0;
            Miss = 0;

            Hero = new Hero(@"Heroes\Hero", new Vector2(Globals.ScreenWidth / 2, Globals.ScreenHeight / 2 + 200), new Vector2(46, 60));
            font = Globals.Content.Load<SpriteFont>(@"Fonts\GameFont");

            Offset = new Vector2(0, 0);

            UI = new UI();

            TileBackground2D = new TileBackground2d(@"Backgrounds\StandardGrass", new Vector2(-100, -100), new Vector2(120, 100), new Vector2(1024 + 100, 768 + 100));
        }

        public virtual void Update()
        {
            if(!Hero.Dead && !GameGlobals.Pause)
            {
                Hero.Update(Offset);

                SpawnPoint.Update(Offset);

                for (int i = 0; i < Projectiles.Count; i++)
                {
                    Projectiles[i].Update(Offset, Mobs.ToList<Unit>());

                    if (Projectiles[i].Done)
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
                        if (Mobs[i].Result == Result)
                        {
                            Score++;
                        }
                        else
                        {
                            Miss++;
                            Hero.Health--;

                            if (Hero.Health == 0)
                            {
                                Hero.Dead = true;
                            }
                        }

                        Mobs.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                if (Globals.Keyboard.GetPress("Enter"))
                {
                    ResetWorld(null);
                }
            }

            if (Globals.Keyboard.GetSinglePress("Space"))
            {
                GameGlobals.Pause = !GameGlobals.Pause;
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

        public virtual void RemoveMobs()
        {
            Mobs.Clear();
        }

        public virtual void GetValues(int firstValue, int secondValue, int result)
        {
            FirstNumber = firstValue;
            SecondNumer = secondValue;
            Result = result;
        }

        public virtual void Draw(Vector2 offset)
        {
            TileBackground2D.Draw(offset);

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
