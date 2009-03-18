using System.Collections.Generic;
using System.Drawing;

namespace RoboDojo.Core.Robot
{
    public interface IBattleMap
    {
        IList<IRobot> VisibleRobots { get; }
        Rectangle ViewableArea { get; }
    }
}