#region Includes

using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

#endregion

namespace BravoGame
{
    public class MyKeyboard
    {
        public KeyboardState NewKeyboard, OldKeyboard;
        public List<MyKey> PressedKeys = new List<MyKey>(), PreviousPressedKeys = new List<MyKey>();

        public MyKeyboard()
        {
        }

        public virtual void Update()
        {
            NewKeyboard = Keyboard.GetState();

            GetPressedKeys();
        }

        public void UpdateOld()
        {
            OldKeyboard = NewKeyboard;

            PreviousPressedKeys = new List<MyKey>();
            for (int i = 0; i < PressedKeys.Count; i++)
            {
                PreviousPressedKeys.Add(PressedKeys[i]);
            }
        }

        public bool GetPress(string key)
        {
            for (int i = 0; i < PressedKeys.Count; i++)
            {
                if (PressedKeys[i].Key == key)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual void GetPressedKeys()
        {
            bool Found = false;

            PressedKeys.Clear();
            for (int i = 0; i < NewKeyboard.GetPressedKeys().Length; i++)
            {
                PressedKeys.Add(new MyKey(NewKeyboard.GetPressedKeys()[i].ToString(), 1));
            }
        }
    }
}
