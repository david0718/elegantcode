using System;
using System.Reflection;
using RoboDojo.Core.Robot;

namespace RoboDojo.SampleRobots
{
    public class RightRobot : RobotBase
    {
        public RightRobot()
        {
            Author = "David Starr";
            ID = Guid.NewGuid();
            Name = "Right Robot";
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        protected override void TakeATurn(IBattleMap battleMap)
        {
            Move(Direction.Right);
        }
    }
}