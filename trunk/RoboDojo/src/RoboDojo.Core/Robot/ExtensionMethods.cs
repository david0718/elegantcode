using System.Drawing;

namespace RoboDojo.Core.Robot
{
    public static class ExtensionMethods
    {
        public static Rectangle Move(this Rectangle rectangle, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Rectangle(rectangle.X, rectangle.Y - 1, rectangle.Width, rectangle.Height);

                case Direction.Down:
                    return new Rectangle(rectangle.X, rectangle.Y + 1, rectangle.Width, rectangle.Height);

                case Direction.Left:
                    return new Rectangle(rectangle.X - 1, rectangle.Y, rectangle.Width, rectangle.Height);
                
                case Direction.Right:
                    return new Rectangle(rectangle.X + 1, rectangle.Y, rectangle.Width, rectangle.Height);
            }
            return rectangle;
        }
    }
}