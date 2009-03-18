using System;
using System.Drawing;
using RoboDojo.Core.Robot;
using RoboDojo.Core.ServiceInterfaces;

public class StandardMoveCheckerService : IMoveChecker
{
    private readonly IBattle _battle;

    public StandardMoveCheckerService(IBattle battle)
    {
        if (battle == null) throw new ArgumentNullException("battle");

        _battle = battle;
    }

    public bool CanMoveToThisDestination(IRobot robot, Direction direction)
    {
        var destinationRect = robot.FootPrint.Move(direction);
        
        if (!AvoidsWalls(destinationRect)) 
            return false;

        if (CollidesWithAnotherRobot(destinationRect, robot.ID))
            return false;

        return true;
    }

    private bool CollidesWithAnotherRobot(Rectangle robotRect, Guid movingRobotId)
    {
        var robots = _battle.GetRobots();
        
        foreach (var opponent in robots)
        {
            if (opponent.ID != movingRobotId &&
                robotRect.IntersectsWith(opponent.FootPrint))
            {
                return true;
            }
        }

        return false;
    }

    #region Boundary Checking methods

    public bool AvoidsWalls(Rectangle robotRect)
    {
        var battleField = new Rectangle(0, 0, _battle.BattleField.Width, _battle.BattleField.Height);
        return battleField.Contains(robotRect);
    }

    #endregion

}