using RoboDojo.Core.Battle;
using RoboDojo.Core.Robot;

namespace RoboDojo.Combat
{
    partial class Battle : IBattle
    {
        public event BattleStartedHandler OnBattleStarted;
        public event BattleEndedHandler OnBattleEnded;
        public event RobotEnteredBattleHandler OnRobotEnteredBattle;
        public event TurnCompleteHandler OnTurnComplete;

        private void InvokeOnTurnComplete()
        {
            var args = new BattleEventArgs(GetRobots());
            
            TurnCompleteHandler Handler = OnTurnComplete;
            if (Handler != null) Handler(this, args);
        }

        private void InvokeOnRobotEnteredBattle(IRobot robot)
        {
            var args = new RobotEnteredBattleHandlerArgs(GetRobots(), robot);
            
            RobotEnteredBattleHandler Handler = OnRobotEnteredBattle;
            if (Handler != null) Handler(this, args);
        }

        private void InvokeOnBattleStarted()
        {
            var args = new BattleEventArgs(GetRobots());
            
            BattleStartedHandler Handler = OnBattleStarted;
            if (Handler != null) Handler(this, args);
        }

        private void InvokeOnBattleEnded(ReasonBattleEnded reason)
        {
            var args = new BattleEndedEventArgs(reason, GetRobots(), GetTheWinner());
            
            BattleEndedHandler Handler = OnBattleEnded;
            if (Handler != null) Handler(this, args);
        }
    }
}