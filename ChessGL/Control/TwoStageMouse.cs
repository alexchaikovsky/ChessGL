using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ChessGL.Control
{
    public enum ClickType
    {
        Single,
        Double,
        Hold
    }
    public class TwoStageMouse
    {
        MouseState lastMouseState;
        bool mousePressed;
        public bool firstClick;
        public TwoStageMouse()
        {
            lastMouseState = new MouseState();
            mousePressed = false;
            firstClick = true;
        }
        public ClickType CheckClick(MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
            {
                mousePressed = true;
                lastMouseState = mouseState;
                //Debug.WriteLine("Click");
                if (firstClick)
                {
                    firstClick = false;
                    Debug.WriteLine("1st Click");
                    return ClickType.Single;
                }
                else
                {
                    firstClick = true;
                    Debug.WriteLine("2nd Click");
                    return ClickType.Double;
                }
                //MouseClickEvent(this, new MouseClickEventArgs { point = mouse.Position, mouse = mouse });
                //Debug.WriteLine("Click");
            }


            /*if (mouseState.LeftButton == ButtonState.Released && lastMouseState.LeftButton == ButtonState.Pressed)
            {
                mousePressed = false;
                Debug.WriteLine("Release");
                lastMouseState = mouseState;
                return -1;
            }*/

            return ClickType.Hold;
        }
    }
}
