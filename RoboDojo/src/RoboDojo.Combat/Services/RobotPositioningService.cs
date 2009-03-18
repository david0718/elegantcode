using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using RoboDojo.Core.Robot;

namespace RoboDojo.Combat.Services
{
    public class RobotPositioningService
    {
        private readonly IBattle _battle;
        private readonly IList<Rectangle> _footPrints;

        public RobotPositioningService(IBattle battle)
        {
            if (battle == null) throw new ArgumentNullException("battle");
            _battle = battle;
            _footPrints = new List<Rectangle>();
        }

        public Rectangle PositionRobot(IRobot robot)
        {
            if (robot == null) throw new ArgumentNullException("robot");
            
            Rectangle targetRect = GetASpaceOnTheField(robot.FootPrint.Size);

            if (TooCloseToAnotherSpace(robot, targetRect))
            {
                return PositionRobot(robot);
            }
            
            return targetRect;
        }

        private bool TooCloseToAnotherSpace(IRobot robotToPosition, Rectangle candidateFootPrint)
        {
            foreach (var opponent in _battle.GetRobots().Where(robot => robot.ID != robotToPosition.ID))
            {
                if (opponent.FootPrint.IntersectsWith(candidateFootPrint))
                    return true;
            }
            return false;
        }

        private Rectangle GetASpaceOnTheField(Size size)
        {
            var random = new Random(DateTime.Now.Millisecond);
            int x = random.Next(size.Width, _battle.BattleField.Width - size.Width);
            int y = random.Next(size.Height, _battle.BattleField.Height - size.Height);

            return new Rectangle(new System.Drawing.Point(x, y), size);
        }
    }
}
