using System;
using System.Reflection;
using RoboDojo.Core.Robot;

namespace RoboDojo.SampleRobots
{
    public class UpRobot : RobotBase
    {
        public UpRobot()
        {
            Author = "David Starr";
            ID = Guid.NewGuid();
            Name = "Up Robot";
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        protected override void TakeATurn(IBattleMap battleMap)
        {
            Move(Direction.Up);
        }
    }
}