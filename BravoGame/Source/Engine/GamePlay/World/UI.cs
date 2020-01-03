using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BravoGame
{
    public class UI
    {
        public SpriteFont font;

        public UI()
        {
            font = Globals.Content.Load<SpriteFont>(@"Fonts\GameFont");
        }

        public void Update(World world)
        {

        }

        public void Draw(World world)
        {
            string tempString = $"Points = {world.Points}";
            Vector2 stringDimensions = font.MeasureString(tempString);
            Globals.spriteBatch.DrawString(font, tempString, new Vector2(Globals.ScreenWidth / 2 - stringDimensions.X / 2, Globals.ScreenHeight - stringDimensions.Y), Color.Black);
        }
    }
}
