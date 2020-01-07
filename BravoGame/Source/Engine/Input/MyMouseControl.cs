namespace BravoGame
{
    #region Usings

    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    #endregion

    /// <summary>
    /// The my mouse control.
    /// </summary>
    public class MyMouseControl
    {
        /// <summary>
        /// The dragging.
        /// </summary>
        public bool Dragging, RightDrag;

        /// <summary>
        /// The first mouse.
        /// </summary>
        public MouseState FirstMouse;

        /// <summary>
        /// The first mouse position.
        /// </summary>
        public Vector2 FirstMousePosition;

        /// <summary>
        /// The new mouse.
        /// </summary>
        public MouseState NewMouse;

        /// <summary>
        /// The new mouse adjusted position.
        /// </summary>
        public Vector2 NewMouseAdjustedPosition;

        /// <summary>
        /// The new mouse position.
        /// </summary>
        public Vector2 NewMousePosition;

        /// <summary>
        /// The old mouse.
        /// </summary>
        public MouseState OldMouse;

        /// <summary>
        /// The old mouse position.
        /// </summary>
        public Vector2 OldMousePosition;

        /// <summary>
        /// The screen loc.
        /// </summary>
        public Vector2 ScreenLoc;

        /// <summary>
        /// The system cursor pos.
        /// </summary>
        public Vector2 SystemCursorPos;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyMouseControl" /> class.
        /// </summary>
        public MyMouseControl()
        {
            this.Dragging = false;

            this.NewMouse = Mouse.GetState();
            this.OldMouse = this.NewMouse;
            this.FirstMouse = this.NewMouse;

            this.NewMousePosition = new Vector2(this.NewMouse.Position.X, this.NewMouse.Position.Y);
            this.OldMousePosition = new Vector2(this.NewMouse.Position.X, this.NewMouse.Position.Y);
            this.FirstMousePosition = new Vector2(this.NewMouse.Position.X, this.NewMouse.Position.Y);

            this.GetMouseAndAdjust();
        }

        /// <summary>
        /// The get mouse and adjust.
        /// </summary>
        public virtual void GetMouseAndAdjust()
        {
            this.NewMouse = Mouse.GetState();
            this.NewMousePosition = this.GetScreenPosition(this.NewMouse);
        }

        /// <summary>
        /// The get screen position.
        /// </summary>
        /// <param name="mouse">
        /// The mouse.
        /// </param>
        /// <returns>
        /// The <see cref="Vector2"/>.
        /// </returns>
        public Vector2 GetScreenPosition(MouseState mouse)
        {
            var tempVectore = new Vector2(mouse.Position.X, mouse.Position.Y);
            return tempVectore;
        }

        /// <summary>
        /// The left click.
        /// </summary>
        /// <returns>
        /// The <see cref="bool" />.
        /// </returns>
        public virtual bool LeftClick()
        {
            if (this.NewMouse.LeftButton == ButtonState.Pressed && this.OldMouse.LeftButton != ButtonState.Pressed
                && this.NewMouse.Position.X >= 0 && this.NewMouse.Position.X <= Globals.ScreenWidth
                && this.NewMouse.Position.Y >= 0 && this.NewMouse.Position.Y <= Globals.ScreenHeight)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The update.
        /// </summary>
        public void Update()
        {
            this.GetMouseAndAdjust();

            if (this.NewMouse.LeftButton == ButtonState.Pressed && this.OldMouse.LeftButton == ButtonState.Released)
            {
                this.FirstMouse = this.NewMouse;
                this.FirstMousePosition = this.NewMousePosition = this.GetScreenPosition(this.FirstMouse);
            }
        }

        /// <summary>
        /// The update old.
        /// </summary>
        public void UpdateOld()
        {
            this.OldMouse = this.NewMouse;
            this.OldMousePosition = this.GetScreenPosition(this.OldMouse);
        }
    }
}