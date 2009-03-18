using System;
using System.Reflection;
using RoboDojo.Core.Robot;

namespace RoboDojo.SampleRobots
{
    public class LeftRobot : RobotBase
    {
        public LeftRobot()
        {
            Author = "David Starr";
            ID = Guid.NewGuid();
            Name = "Left Robot";
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        protected override void TakeATurn(IBattleMap battleMap)
        {
            Move(Direction.Left);
        }
    }
}