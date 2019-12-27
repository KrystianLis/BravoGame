#region Includes

using Microsoft.Xna.Framework;

#endregion

namespace BravoGame
{
    public class Unit : Basic2d
    {
        public float Speed;

        public Unit(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
            Speed = 2.0f;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
