using System;
using RoboDojo.Core.Robot;
using RoboDojo.Core.ServiceInterfaces;

namespace RoboDojo.Combat.Services
{
    public class StandardBattleMapCreator : IBattleMapCreator
    {
        private readonly IBattle _battle;

        public StandardBattleMapCreator(IBattle battle)
        {
            if (battle == null) throw new ArgumentNullException("battle");

            _battle = battle;
        }

        #region IBattleMapCreator Members

        public IBattleMap CreateBattleMap(IRobot robotRequestingMap)
        {
            if (robotRequestingMap == null) throw new ArgumentNullException("robotRequestingMap");
            
            return CreateMasterBattleMap(); // TODO: need to limit the view for a single bot
        }

        public IBattleMap CreateMasterBattleMap()
        {
            return new StandardBattleMap(_battle.BattleField, _battle.GetRobots());
        }


        #endregion
    }
}