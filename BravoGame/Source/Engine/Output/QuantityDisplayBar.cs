using Microsoft.Xna.Framework;

namespace BravoGame
{
    public class QuantityDisplayBar
    {
        public int Border;

        public Basic2d Bar, BarBackground;

        public Color Color;

        public QuantityDisplayBar(Vector2 dimensions, int border, Color color)
        {
            Border = border;
            Color = color;

            Bar = new Basic2d(@"Misc\solid", new Vector2(0, 0), new Vector2(dimensions.X - border * 2, dimensions.Y - border * 2));
            BarBackground = new Basic2d(@"Misc\shade", new Vector2(0, 0), new Vector2(dimensions.X, dimensions.Y));
        }

        public virtual void Update(float current, float max)
        {
            Bar.Dimensions = new Vector2(current / max * (BarBackground.Dimensions.X - Border * 2), Bar.Dimensions.Y);
        }

        public virtual void Draw(Vector2 offset)
        {
            BarBackground.Draw(offset, new Vector2(0, 0), Color.Black);
            Bar.Draw(offset + new Vector2(Border, Border), new Vector2(0, 0), Color);
        }
    }
}
