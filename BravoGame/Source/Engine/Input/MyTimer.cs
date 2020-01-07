namespace BravoGame
{
    #region Usings

    using System;

    #endregion

    /// <summary>
    /// The my Timer.
    /// </summary>
    public class MyTimer
    {
        /// <summary>
        /// The good to go.
        /// </summary>
        public bool GoodToGo;

        /// <summary>
        /// The Timer.
        /// </summary>
        protected TimeSpan Timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyTimer"/> class.
        /// </summary>
        /// <param name="miliSeconds">
        /// The mili seconds.
        /// </param>
        public MyTimer(int miliSeconds)
        {
            this.GoodToGo = false;
            this.MiliSec = miliSeconds;
        }

        /// <summary>
        /// Gets or sets the mili sec.
        /// </summary>
        public int MiliSec { get; set; }

        /// <summary>
        /// The reset to zero.
        /// </summary>
        public void ResetToZero()
        {
            this.Timer = TimeSpan.Zero;
            this.GoodToGo = false;
        }

        /// <summary>
        /// The test.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Test()
        {
            if (this.Timer.TotalMilliseconds >= this.MiliSec || this.GoodToGo)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// The update Timer.
        /// </summary>
        public void UpdateTimer()
        {
            this.Timer += Globals.GameTime.ElapsedGameTime;
        }
    }
}