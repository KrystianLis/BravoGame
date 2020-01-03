#region Includes

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

#endregion

namespace BravoGame
{
    public class Hero : Unit
    {
        public int FirstNumber;
        public int SecondNumer;
        public int Result;

        public SpriteFont font;

        public Hero(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            Speed = 2.0f;

            Health = 1;
            HealthMax = Health;

            font = Globals.Content.Load<SpriteFont>(@"Fonts\GameFont");
            MathOperation();
        }

        private void MathOperation()
        {
            var random = new Random();
            FirstNumber = random.Next(1, 100);
            SecondNumer = random.Next(1, 100);
            Result = FirstNumber + FirstNumber;
        }

        public override void Update(Vector2 offset)
        {
            if(Globals.Keyboard.GetPress("A"))
            {
                Position = new Vector2(Position.X - Speed, Position.Y);
            }
            if (Globals.Keyboard.GetPress("D"))
            {
                Position = new Vector2(Position.X + Speed, Position.Y);
            }
            if (Globals.Keyboard.GetPress("W"))
            {
                Position = new Vector2(Position.X, Position.Y - Speed);
            }
            if (Globals.Keyboard.GetPress("S"))
            {
                Position = new Vector2(Position.X, Position.Y + Speed);
            }

            Rotation = Globals.RotateTowards(Position, 
                new Vector2(Globals.Mouse.newMousePosition.X, Globals.Mouse.newMousePosition.Y));

            if(Globals.Mouse.LeftClick())
            {
                GameGlobals.PassProjectiles(new FireBall(new Vector2(Position.X, Position.Y), this, 
                    new Vector2(Globals.Mouse.newMousePosition.X, Globals.Mouse.newMousePosition.Y)));
            }

            base.Update(offset);
        }

        public override void Draw(Vector2 offset)
        {
            string tempString = $"{FirstNumber} + {SecondNumer} = ?";
            Vector2 stringDimensions = font.MeasureString(tempString);
            Globals.spriteBatch.DrawString(font, tempString, new Vector2(Globals.ScreenWidth - stringDimensions.X - 10, Globals.ScreenHeight - stringDimensions.Y), Color.Black);

            base.Draw(offset);
        }
    }
}
