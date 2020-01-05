using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BravoGame
{
    public class UI
    {
        public SpriteFont font;

        public QuantityDisplayBar HealthBar;

        public UI()
        {
            font = Globals.Content.Load<SpriteFont>(@"Fonts\GameFont");
            HealthBar = new QuantityDisplayBar(new Vector2(104, 16), 2, Color.Red);
        }

        public void Update(World world)
        {
            HealthBar.Update(world.Hero.Health, world.Hero.HealthMax);
        }

        public void Draw(World world)
        {
            string tempString = $"Score = {world.Score}\nMiss = {world.Miss}";
            Vector2 stringDimensions = font.MeasureString(tempString);
            Globals.spriteBatch.DrawString(font, tempString, new Vector2(Globals.ScreenWidth / 2 - stringDimensions.X / 2, Globals.ScreenHeight - stringDimensions.Y), Color.Black);
            
            HealthBar.Draw(new Vector2(20, Globals.ScreenHeight - 40));

            if (world.Hero.Dead)
            {
                tempString = $"You lost! Press Enter to Restart";
                stringDimensions = font.MeasureString(tempString);
                Globals.spriteBatch.DrawString(font, tempString, new Vector2(Globals.ScreenWidth / 2 - stringDimensions.X / 2, Globals.ScreenHeight / 2), Color.Black);
            }

            if (GameGlobals.Pause)
            {
                tempString = $"Pause";
                stringDimensions = font.MeasureString(tempString);
                Globals.spriteBatch.DrawString(font, tempString, new Vector2(Globals.ScreenWidth / 2 - stringDimensions.X / 2, Globals.ScreenHeight / 2), Color.Black);
            }
        }
    }
}
