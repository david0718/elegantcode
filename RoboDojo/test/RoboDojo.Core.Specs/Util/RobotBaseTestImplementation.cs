using System;
using System.Reflection;
using RoboDojo.Core.Robot;

namespace RoboDojo.Core.Specs.Util
{
    internal class RobotBaseTestImplementation : RobotBase
    {
        public RobotBaseTestImplementation()
        {
            Author = "David Starr";
            ID = Guid.NewGuid();
            Name = "Fake Robot";
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        protected override void TakeATurn(IBattleMap battleMap)
        {
            // do nothing
        }

        internal void Move_ExternalAccessor(Direction direction)
        {
            Move(direction);
        }
    }
}