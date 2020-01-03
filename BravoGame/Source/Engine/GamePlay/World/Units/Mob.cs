#region Includes

using Microsoft.Xna.Framework;

#endregion

namespace BravoGame
{
    public class Mob : Unit
    {
        public Mob(string path, Vector2 position, Vector2 dimensions) : base(path, position, dimensions)
        {
        }

        public virtual void Update(Vector2 offset, Hero hero)
        {
            base.Update(offset);
        }

        // TODO: Add mathematical logic
        //public virtual void MethematicalLogic(Hero hero)
        //{
        //    if()
        //    {
        //        hero.GetHit(1);
        //        Dead = true;
        //    }
        //}

        public override void Draw(Vector2 offset)
        {
            base.Draw(offset);
        }
    }
}
