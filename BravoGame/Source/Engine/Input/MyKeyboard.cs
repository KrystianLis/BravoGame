namespace BravoGame
{
    #region Usings

    using System.Collections.Generic;

    using Microsoft.Xna.Framework.Input;

    #endregion

    /// <summary>
    /// The my keyboard.
    /// </summary>
    public class MyKeyboard
    {
        /// <summary>
        /// The new keyboard.
        /// </summary>
        public KeyboardState NewKeyboard, OldKeyboard;

        /// <summary>
        /// The pressed keys.
        /// </summary>
        public List<MyKey> PressedKeys = new List<MyKey>(), PreviousPressedKeys = new List<MyKey>();

        /// <summary>
        /// The get press.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GetPress(string key)
        {
            for (var i = 0; i < this.PressedKeys.Count; i++)
            {
                if (this.PressedKeys[i].Key == key)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The get pressed keys.
        /// </summary>
        public virtual void GetPressedKeys()
        {
            this.PressedKeys.Clear();

            for (var i = 0; i < this.NewKeyboard.GetPressedKeys().Length; i++)
            {
                this.PressedKeys.Add(new MyKey(this.NewKeyboard.GetPressedKeys()[i].ToString(), 1));
            }
        }

        /// <summary>
        /// The get single press.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool GetSinglePress(string key)
        {
            for (var i = 0; i < this.PressedKeys.Count; i++)
            {
                var isIn = false;

                for (var j = 0; j < this.PreviousPressedKeys.Count; j++)
                {
                    isIn = true;

                    break;
                }

                if (!isIn && (this.PressedKeys[i].Key == key || this.PressedKeys[i].Print == key))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// The update.
        /// </summary>
        public virtual void Update()
        {
            this.NewKeyboard = Keyboard.GetState();
            this.GetPressedKeys();
        }

        /// <summary>
        /// The update old.
        /// </summary>
        public void UpdateOld()
        {
            this.OldKeyboard = this.NewKeyboard;
            this.PreviousPressedKeys = new List<MyKey>();

            for (var i = 0; i < this.PressedKeys.Count; i++)
            {
                this.PreviousPressedKeys.Add(this.PressedKeys[i]);
            }
        }
    }
}