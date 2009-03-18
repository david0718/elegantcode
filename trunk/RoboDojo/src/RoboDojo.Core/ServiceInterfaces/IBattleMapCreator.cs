using RoboDojo.Core.Robot;

namespace RoboDojo.Core.ServiceInterfaces
{
    public interface IBattleMapCreator
    {
        IBattleMap CreateBattleMap(IRobot robotRequestingMap);
    }
}