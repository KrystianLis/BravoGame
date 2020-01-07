namespace BravoGame
{
    #region Usings

    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The game play.
    /// </summary>
    public class GamePlay
    {
        /// <summary>
        /// The play state.
        /// </summary>
        readonly int playState;

        /// <summary>
        /// The world.
        /// </summary>
        World world;

        /// <summary>
        /// Initializes a new instance of the <see cref="GamePlay"/> class.
        /// </summary>
        public GamePlay()
        {
            this.playState = 0;
            this.ResetWorld(null);
        }

        /// <summary>
        /// The draw.
        /// </summary>
        public virtual void Draw()
        {
            if (this.playState == 0)
            {
                this.world.Draw(Vector2.Zero);
            }
        }

        /// <summary>
        /// The reset world.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        public virtual void ResetWorld(object info)
        {
            this.world = new World(this.ResetWorld);
        }

        /// <summary>
        /// The update.
        /// </summary>
        public void Update()
        {
            if (this.playState == 0)
            {
                this.world.Update();
            }
        }
    }
}