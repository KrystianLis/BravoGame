#region Includes

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

#endregion

namespace BravoGame
{
    public class SpawnPoint
    {
        public Vector2 Position;
        public MyTimer spawnTimer = new MyTimer(7000);

        public SpawnPoint()
        {
        }

        public (int, int, int) MathOperationValues()
        {
            var random = new Random();

            int firstValue = random.Next(1, 100);
            int secondValue = random.Next(1, 100);
            int resultValue = firstValue + secondValue;

            GameGlobals.PassValues(firstValue, secondValue, resultValue);

            int firstFakeResult = random.Next(resultValue - 10, resultValue + 10);
            int secondFakeResult = random.Next(resultValue - 10, resultValue + 10);

            return (resultValue, firstFakeResult, secondFakeResult);
        }

        public virtual void Update(Vector2 offset)
        {
            spawnTimer.UpdateTimer();

            if(spawnTimer.Test())
            {
                (int a, int b, int c) = MathOperationValues();
                
                var resultList = new List<int>()
                {
                    a,
                    b,
                    c,
                };

                resultList.Shuffle();

                SpawnMob(resultList);

                spawnTimer.ResetToZero();
            }
        }

        public virtual void SpawnMob(IList<int> result)
        {
            GameGlobals.PassMob(new FirstMob(new Vector2(200, 200), result[0]));
            GameGlobals.PassMob(new FirstMob(new Vector2(Globals.ScreenWidth / 2, 200), result[1]));
            GameGlobals.PassMob(new FirstMob(new Vector2(Globals.ScreenWidth - 200, 200), result[2]));
        }
    }
}
