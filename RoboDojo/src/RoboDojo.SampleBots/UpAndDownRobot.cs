using System;
using System.Reflection;
using RoboDojo.Core.Robot;

namespace RoboDojo.SampleRobots
{
    public class UpAndDownRobot : RobotBase
    {
        private Direction _lastMoveDirection;

        public UpAndDownRobot()
        {
            Author = "David Starr";
            ID = Guid.NewGuid();
            Name = "UpAndDown Robot";
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        protected override void TakeATurn(IBattleMap battleMap)
        {
            if (_lastMoveDirection == Direction.Up && ICanMoveUp(battleMap))
                _lastMoveDirection = Direction.Up;

            else if (_lastMoveDirection == Direction.Down && ICanMoveDown(battleMap))
                _lastMoveDirection = Direction.Down;

            else if (ICanMoveUp(battleMap))
                _lastMoveDirection = Direction.Up;

            else if (ICanMoveDown(battleMap))
                _lastMoveDirection = Direction.Down;

            else
                _lastMoveDirection = Direction.None;

            Move(_lastMoveDirection);
        }

        private bool ICanMoveDown(IBattleMap battleMap)
        {
            return FootPrint.Bottom < battleMap.ViewableArea.Bottom;
        }

        private bool ICanMoveUp(IBattleMap battleMap)
        {
            return FootPrint.Top > 1;
        }
    }
}