using System;
using System.Drawing;

namespace RoboDojo.Core.Robot
{
    public delegate void WeaponFiredHandler(object sender, WeaponFiredEventArgs args);

    public delegate void RobotDiedHandler(object sender, RobotEventArgs args);

    public delegate void RobotDamagedHandler(object sender, RobotEventArgs args);

    public class RobotEventArgs : EventArgs
    {
        public RobotEventArgs(RobotBase theBot)
        {
            if (theBot == null) throw new ArgumentNullException("theBot");

            TheRobot = theBot;
        }

        public RobotBase TheRobot { get; private set; }
    }

    public class WeaponFiredEventArgs : RobotEventArgs
    {
        public WeaponFiredEventArgs(RobotBase theBot, Point firingPosition, Point targetPosition)
            : base(theBot)
        {
            if (firingPosition == null) throw new ArgumentNullException("firingPosition");
            if (targetPosition == null) throw new ArgumentNullException("targetPosition");

            FiringPosition = firingPosition;
            TargetPosition = targetPosition;
        }

        public Point FiringPosition { get; private set; }
        public Point TargetPosition { get; private set; }

        public override string ToString()
        {
            string msg = "{0} fired from {1} at {2}";
            return string.Format(msg, TheRobot, FiringPosition, TargetPosition);
        }
    }
}