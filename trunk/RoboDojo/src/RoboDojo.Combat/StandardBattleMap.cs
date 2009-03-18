using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using RoboDojo.Core.Robot;

namespace RoboDojo.Combat
{
    public class StandardBattleMap : IBattleMap
    {
        public Rectangle ViewableArea { get; private set; }
        public IList<IRobot> VisibleRobots { get; private set; }

        public StandardBattleMap(Rectangle viewableArea, IList<IRobot> visibleRobots)
        {
            ViewableArea = viewableArea;
            VisibleRobots = visibleRobots;
        }
    }
}