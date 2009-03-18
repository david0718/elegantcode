using RoboDojo.Core.Robot;

namespace RoboDojo.Core.ServiceInterfaces
{
    public interface IMoveChecker
    {
        bool CanMoveToThisDestination(IRobot robot, Direction direction);
    }
}