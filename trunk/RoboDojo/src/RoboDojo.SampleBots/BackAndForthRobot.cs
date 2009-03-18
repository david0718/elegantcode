using System;
using System.Reflection;
using RoboDojo.Core.Robot;

namespace RoboDojo.SampleRobots
{
    public class BackAndForthRobot : RobotBase
    {
        private Direction _lastMoveDirection;

        public BackAndForthRobot()
        {
            Author = "David Starr";
            ID = Guid.NewGuid();
            Name = "BackAndForth Robot";
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        protected override void TakeATurn(IBattleMap battleMap)
        {
            if (_lastMoveDirection == Direction.Right && ICanMoveRight(battleMap))
                _lastMoveDirection = Direction.Right;
            
            else if (_lastMoveDirection == Direction.Left && ICanMoveLeft(battleMap))
                _lastMoveDirection = Direction.Left;
            
            else if (ICanMoveLeft(battleMap))
                _lastMoveDirection = Direction.Left;
            
            else if (ICanMoveRight(battleMap))
                _lastMoveDirection = Direction.Right;

            else
                _lastMoveDirection = Direction.None;
            
            Move(_lastMoveDirection);
        }

        private bool ICanMoveLeft(IBattleMap battleMap)
        {
            return this.FootPrint.Left > 1;
        }

        private bool ICanMoveRight(IBattleMap battleMap)
        {
            return this.FootPrint.Right < battleMap.ViewableArea.Right;
        }
    }
}