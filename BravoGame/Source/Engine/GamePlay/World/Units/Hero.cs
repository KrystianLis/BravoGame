#region Includes

using Microsoft.Xna.Framework;

#endregion

namespace BravoGame
{
    public class Hero : Unit
    {
        public Hero(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            Speed = 2.0f;
        }

        public override void Update()
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

            base.Update();
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
