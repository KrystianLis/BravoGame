namespace BravoGame
{
    #region Usings

    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    #endregion

    /// <summary>
    /// The pass object.
    /// </summary>
    /// <param name="obj">
    /// The obj.
    /// </param>
    public delegate void PassObject(object obj);

    /// <summary>
    /// The invoke method.
    /// </summary>
    public delegate void InvokeMethod();

    /// <summary>
    /// The pass object and retrun.
    /// </summary>
    /// <param name="obj">
    /// The obj.
    /// </param>
    public delegate object PassObjectAndRetrun(object obj);

    /// <summary>
    /// The pass values.
    /// </summary>
    /// <param name="x">
    /// The x.
    /// </param>
    /// <param name="y">
    /// The y.
    /// </param>
    /// <param name="z">
    /// The z.
    /// </param>
    public delegate void PassValues(int x, int y, int z);

    /// <summary>
    /// The globals.
    /// </summary>
    public class Globals
    {
        /// <summary>
        /// The content.
        /// </summary>
        public static ContentManager Content;

        /// <summary>
        /// The game time.
        /// </summary>
        public static GameTime GameTime;

        /// <summary>
        /// The keyboard.
        /// </summary>
        public static MyKeyboard Keyboard;

        /// <summary>
        /// The mouse.
        /// </summary>
        public static MyMouseControl Mouse;

        /// <summary>
        /// The screen height.
        /// </summary>
        public static int ScreenHeight, ScreenWidth;

        /// <summary>
        /// The sprite batch.
        /// </summary>
        public static SpriteBatch spriteBatch;

        /// <summary>
        /// The get distance.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// </returns>
        public static float GetDistance(Vector2 position, Vector2 target)
        {
            return (float)Math.Sqrt(Math.Pow(position.X - target.X, 2) + Math.Pow(position.Y - target.Y, 2));
        }

        /// <summary>
        /// The rotate towards.
        /// </summary>
        /// <param name="Pos">
        /// The pos.
        /// </param>
        /// <param name="focus">
        /// The focus.
        /// </param>
        /// <returns>
        /// The <see cref="float"/>.
        /// </returns>
        public static float RotateTowards(Vector2 Pos, Vector2 focus)
        {
            float h, sineTheta, angle;

            if (Pos.Y - focus.Y != 0)
            {
                h = (float)Math.Sqrt(Math.Pow(Pos.X - focus.X, 2) + Math.Pow(Pos.Y - focus.Y, 2));
                sineTheta = Math.Abs(Pos.Y - focus.Y) / h;
            }
            else
            {
                h = Pos.X - focus.X;
                sineTheta = 0;
            }

            angle = (float)Math.Asin(sineTheta);

            if (Pos.X - focus.X > 0 && Pos.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI * 3 / 2 + angle);
            }
            else if (Pos.X - focus.X > 0 && Pos.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI * 3 / 2 - angle);
            }
            else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y > 0)
            {
                angle = (float)(Math.PI / 2 - angle);
            }
            else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y < 0)
            {
                angle = (float)(Math.PI / 2 + angle);
            }
            else if (Pos.X - focus.X > 0 && Pos.Y - focus.Y == 0)
            {
                angle = (float)Math.PI * 3 / 2;
            }
            else if (Pos.X - focus.X < 0 && Pos.Y - focus.Y == 0)
            {
                angle = (float)Math.PI / 2;
            }
            else if (Pos.X - focus.X == 0 && Pos.Y - focus.Y > 0)
            {
                angle = 0;
            }
            else if (Pos.X - focus.X == 0 && Pos.Y - focus.Y < 0)
            {
                angle = (float)Math.PI;
            }

            return angle;
        }
    }
}