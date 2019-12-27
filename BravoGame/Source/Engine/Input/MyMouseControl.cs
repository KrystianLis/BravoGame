using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;


namespace BravoGame
{
    public class MyMouseControl
    {
        public bool dragging, rightDrag;
        public Vector2 newMousePosition, oldMousePosition, firstMousePosition, newMouseAdjustedPosition, systemCursorPos, screenLoc;
        public MouseState newMouse, oldMouse, firstMouse;

        public MyMouseControl()
        {
            dragging = false;

            newMouse = Mouse.GetState();
            oldMouse = newMouse;
            firstMouse = newMouse;

            newMousePosition = new Vector2(newMouse.Position.X, newMouse.Position.Y);
            oldMousePosition = new Vector2(newMouse.Position.X, newMouse.Position.Y);
            firstMousePosition = new Vector2(newMouse.Position.X, newMouse.Position.Y);

            GetMouseAndAdjust();

            //screenLoc = new Vector2((int)(systemCursorPos.X/Globals.screenWidth), (int)(systemCursorPos.Y/Globals.ScreenHeight));
        }

        #region Properties

        public MouseState First
        {
            get { return firstMouse; }
        }

        public MouseState New
        {
            get { return newMouse; }
        }

        public MouseState Old
        {
            get { return oldMouse; }
        }

        #endregion

        public void Update()
        {
            GetMouseAndAdjust();

            if(newMouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
            {
                firstMouse = newMouse;
                firstMousePosition = newMousePosition = GetScreenPosition(firstMouse);
            }
        }

        public void UpdateOld()
        {
            oldMouse = newMouse;
            oldMousePosition = GetScreenPosition(oldMouse);
        }

        public virtual float GetDistanceFromClick()
        {
            return Globals.GetDistance(newMousePosition, firstMousePosition);
        }

        public virtual void GetMouseAndAdjust()
        {
            newMouse = Mouse.GetState();
            newMousePosition = GetScreenPosition(newMouse);
        }

        public int GetMouseWheelChange()
        {
            return newMouse.ScrollWheelValue - oldMouse.ScrollWheelValue;
        }

        public Vector2 GetScreenPosition(MouseState mouse)
        {
            Vector2 tempVectore = new Vector2(mouse.Position.X, mouse.Position.Y);
            return tempVectore;
        }

        public virtual bool LeftClick()
        {
            if( newMouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton != ButtonState.Pressed && newMouse.Position.X >= 0 && newMouse.Position.X <= Globals.ScreenWidth && newMouse.Position.Y >= 0 && newMouse.Position.Y <= Globals.ScreenHeight)
            {
                return true;
            }

            return false;
        }

        public virtual bool LeftClickHold()
        {
            bool holding = false;

            if( newMouse.LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Pressed && newMouse.Position.X >= 0 && newMouse.Position.X <= Globals.ScreenWidth && newMouse.Position.Y >= 0 && newMouse.Position.Y <= Globals.ScreenHeight)
            {
                holding = true;

                if(Math.Abs(newMouse.Position.X - firstMouse.Position.X) > 8 || Math.Abs(newMouse.Position.Y - firstMouse.Position.Y) > 8)
                {
                    dragging = true;
                }
            }

            return holding;
        }

        public virtual bool LeftClickRelease()
        {
            if(newMouse.LeftButton == ButtonState.Released && oldMouse.LeftButton == ButtonState.Pressed)
            {
                dragging = false;
                return true;
            }

            return false;
        }

        public virtual bool RightClick()
        {
            return newMouse.RightButton == ButtonState.Pressed && oldMouse.RightButton != ButtonState.Pressed && newMouse.Position.X >= 0 && newMouse.Position.X <= Globals.ScreenWidth && newMouse.Position.Y >= 0 && newMouse.Position.Y <= Globals.ScreenHeight
                ? true
                : false;
        }

        public virtual bool RightClickHold()
        {
            bool holding = false;

            if( newMouse.RightButton == ButtonState.Pressed && oldMouse.RightButton == ButtonState.Pressed && newMouse.Position.X >= 0 && newMouse.Position.X <= Globals.ScreenWidth && newMouse.Position.Y >= 0 && newMouse.Position.Y <= Globals.ScreenHeight)
            {
                holding = true;

                if(Math.Abs(newMouse.Position.X - firstMouse.Position.X) > 8 || Math.Abs(newMouse.Position.Y - firstMouse.Position.Y) > 8)
                {
                    rightDrag = true;
                }
            }

            return holding;
        }

        public virtual bool RightClickRelease()
        {
            if( newMouse.RightButton == ButtonState.Released && oldMouse.RightButton == ButtonState.Pressed)
            {
                dragging = false;
                return true;
            }

            return false;
        }

        public void SetFirst()
        {

        }
    }
}
