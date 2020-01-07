namespace BravoGame
{
    #region Usings

    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

    #endregion

    /// <summary>
    /// The spawn point.
    /// </summary>
    public class SpawnPoint
    {
        /// <summary>
        /// The position.
        /// </summary>
        public Vector2 Position;

        /// <summary>
        /// The spawn Timer.
        /// </summary>
        public MyTimer spawnTimer = new MyTimer(7000);

        /// <summary>
        /// The math operation values.
        /// </summary>
        /// <returns>
        /// The <see cref="(int, int, int)"/>.
        /// </returns>
        public (int, int, int) MathOperationValues()
        {
            var random = new Random();

            var firstValue = random.Next(1, 100);
            var secondValue = random.Next(1, 100);
            var resultValue = firstValue + secondValue;

            GameGlobals.PassValues(firstValue, secondValue, resultValue);

            var firstFakeResult = random.Next(resultValue - 10, resultValue + 10);
            var secondFakeResult = random.Next(resultValue - 10, resultValue + 10);

            return (resultValue, firstFakeResult, secondFakeResult);
        }

        /// <summary>
        /// The spawn mob.
        /// </summary>
        /// <param name="result">
        /// The result.
        /// </param>
        public virtual void SpawnMob(IList<int> result)
        {
            GameGlobals.InvokeRemovingMobs();
            GameGlobals.PassMob(new FirstMob(new Vector2(200, 200), result[0]));
            GameGlobals.PassMob(new FirstMob(new Vector2(Globals.ScreenWidth / 2, 200), result[1]));
            GameGlobals.PassMob(new FirstMob(new Vector2(Globals.ScreenWidth - 200, 200), result[2]));
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="offset">
        /// The offset.
        /// </param>
        public virtual void Update(Vector2 offset)
        {
            this.spawnTimer.UpdateTimer();

            if (this.spawnTimer.Test())
            {
                (int a, int b, int c) = this.MathOperationValues();

                var resultList = new List<int> { a, b, c };

                resultList.Shuffle();

                this.SpawnMob(resultList);

                this.spawnTimer.ResetToZero();
            }
        }
    }
}