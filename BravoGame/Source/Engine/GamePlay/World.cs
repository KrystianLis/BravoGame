namespace BravoGame
{
    #region Usings

    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The world.
    /// </summary>
    public class World
    {
        /// <summary>
        /// The first number.
        /// </summary>
        public int FirstNumber;

        /// <summary>
        /// The Font.
        /// </summary>
        public SpriteFont Font;

        /// <summary>
        /// The hero.
        /// </summary>
        public Hero Hero;

        /// <summary>
        /// The miss.
        /// </summary>
        public int Miss;

        /// <summary>
        /// The mobs.
        /// </summary>
        public List<Mob> Mobs;

        /// <summary>
        /// The offset.
        /// </summary>
        public Vector2 Offset;

        /// <summary>
        /// The projectiles.
        /// </summary>
        public List<Projectile2d> Projectiles;

        /// <summary>
        /// The result.
        /// </summary>
        public int Result;

        /// <summary>
        /// The score.
        /// </summary>
        public int Score;

        /// <summary>
        /// The second numer.
        /// </summary>
        public int SecondNumer;

        /// <summary>
        /// The spawn point.
        /// </summary>
        public SpawnPoint SpawnPoint;

        /// <summary>
        /// The tile background 2 d.
        /// </summary>
        public TileBackground2d TileBackground2D;

        /// <summary>
        /// The ui.
        /// </summary>
        public UI UI;

        /// <summary>
        /// The reset world.
        /// </summary>
        readonly PassObject ResetWorld;

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        /// <param name="reseWorld">
        /// The rese world.
        /// </param>
        public World(PassObject reseWorld)
        {
            this.ResetWorld = reseWorld;

            GameGlobals.PassValues = this.GetValues;
            GameGlobals.PassProjectiles = this.AddProjectiles;
            GameGlobals.PassMob = this.AddMobs;
            GameGlobals.InvokeRemovingMobs = this.RemoveMobs;

            this.Projectiles = new List<Projectile2d>();
            this.Mobs = new List<Mob>();
            this.SpawnPoint = new SpawnPoint();

            this.Score = 0;
            this.Miss = 0;

            this.Hero = new Hero(
                @"Heroes\Hero",
                new Vector2(Globals.ScreenWidth / 2, Globals.ScreenHeight / 2 + 200),
                new Vector2(46, 60));
            this.Font = Globals.Content.Load<SpriteFont>(@"Fonts\GameFont");

            this.Offset = new Vector2(0, 0);

            this.UI = new UI();

            this.TileBackground2D = new TileBackground2d(
                @"Backgrounds\StandardGrass",
                new Vector2(-100, -100),
                new Vector2(120, 100),
                new Vector2(1024 + 100, 768 + 100));
        }

        /// <summary>
        /// The add mobs.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        public virtual void AddMobs(object info)
        {
            this.Mobs.Add((Mob)info);
        }

        /// <summary>
        /// The add projectiles.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        public virtual void AddProjectiles(object info)
        {
            this.Projectiles.Add((Projectile2d)info);
        }

        /// <summary>
        /// The draw.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public virtual void Draw(Vector2 offset)
        {
            this.TileBackground2D.Draw(offset);

            this.Hero.Draw(offset);

            for (var i = 0; i < this.Projectiles.Count; i++)
            {
                this.Projectiles[i].Draw(offset);
            }

            for (var i = 0; i < this.Mobs.Count; i++)
            {
                this.Mobs[i].Draw(this.Offset);
            }

            this.UI.Draw(this);

            var tempString = $"{this.FirstNumber} + {this.SecondNumer} = ?";
            var stringDimensions = this.Font.MeasureString(tempString);
            Globals.spriteBatch.DrawString(
                this.Font,
                tempString,
                new Vector2(Globals.ScreenWidth - stringDimensions.X - 10, Globals.ScreenHeight - stringDimensions.Y),
                Color.Black);
        }

        /// <summary>
        /// The get values.
        /// </summary>
        /// <param name="firstValue">
        /// The first value.
        /// </param>
        /// <param name="secondValue">
        /// The second value.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        public virtual void GetValues(int firstValue, int secondValue, int result)
        {
            this.FirstNumber = firstValue;
            this.SecondNumer = secondValue;
            this.Result = result;
        }

        /// <summary>
        /// The remove mobs.
        /// </summary>
        public virtual void RemoveMobs()
        {
            this.Mobs.Clear();
        }

        /// <summary>
        /// The update.
        /// </summary>
        public virtual void Update()
        {
            if (!this.Hero.Dead && !GameGlobals.Pause)
            {
                this.Hero.Update(this.Offset);

                this.SpawnPoint.Update(this.Offset);

                for (var i = 0; i < this.Projectiles.Count; i++)
                {
                    this.Projectiles[i].Update(this.Offset, this.Mobs.ToList<Unit>());

                    if (this.Projectiles[i].Done)
                    {
                        this.Projectiles.RemoveAt(i);
                        i--;
                    }
                }

                for (var i = 0; i < this.Mobs.Count; i++)
                {
                    this.Mobs[i].Update(this.Offset, this.Hero);

                    if (this.Mobs[i].Dead)
                    {
                        if (this.Mobs[i].Result == this.Result)
                        {
                            this.Score++;
                        }
                        else
                        {
                            this.Miss++;
                            this.Hero.Health--;

                            if (this.Hero.Health == 0)
                            {
                                this.Hero.Dead = true;
                            }
                        }

                        this.Mobs.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                if (Globals.Keyboard.GetPress("Enter"))
                {
                    this.ResetWorld(null);
                }
            }

            if (Globals.Keyboard.GetSinglePress("Space"))
            {
                GameGlobals.Pause = !GameGlobals.Pause;
            }

            this.UI.Update(this);
        }
    }
}