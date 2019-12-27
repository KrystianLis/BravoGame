#region Includes

using Microsoft.Xna.Framework;

#endregion

namespace BravoGame
{
    public class Hero : Unit
    {
        public Hero(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            speed = 2.0f;
        }

        public override void Update()
        {
            if(Globals.keyboard.GetPress("A"))
            {
                Position = new Vector2(Position.X - speed, Position.Y);
            }
            if (Globals.keyboard.GetPress("D"))
            {
                Position = new Vector2(Position.X + speed, Position.Y);
            }
            if (Globals.keyboard.GetPress("W"))
            {
                Position = new Vector2(Position.X, Position.Y - speed);
            }
            if (Globals.keyboard.GetPress("S"))
            {
                Position = new Vector2(Position.X, Position.Y + speed);
            }

            rotation = Globals.RotateTowards(Position, 
                new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y));

            if(Globals.mouse.LeftClick())
            {
                GameGlobals.PassProjectiles(new FireBall(new Vector2(Position.X, Position.Y), this, 
                    new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y)));
            }

            base.Update();
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
