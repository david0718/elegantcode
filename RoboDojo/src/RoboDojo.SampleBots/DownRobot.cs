using System;
using System.Drawing;
using System.Reflection;
using System.Threading;
using RoboDojo.Core.Robot;

namespace RoboDojo.SampleRobots
{
    public class DownRobot : RobotBase
    {
        public DownRobot()
        {
            Author = "David Starr";
            ID = Guid.NewGuid();
            Name = "Down Robot";
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        protected override void TakeATurn(IBattleMap battleMap)
        {
            Move(Direction.Down);
        }
    }
}