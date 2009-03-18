using System.Collections.Generic;
using RoboDojo.Core.Robot;

namespace RoboDojo.Core.Battle
{
    public delegate void BattleStartedHandler(object sender, BattleEventArgs args);

    public delegate void BattleEndedHandler(object sender, BattleEndedEventArgs args);

    public delegate void RobotsInitializedHandler(object sender, BattleEventArgs args);

    public delegate void TurnCompleteHandler(object sender, BattleEventArgs args);

    public delegate void RobotEnteredBattleHandler(object sender, RobotEnteredBattleHandlerArgs args);

    public class BattleEventArgs
    {
        public BattleEventArgs(IEnumerable<IRobot> statusUpdate)
        {
            StatusUpdate = statusUpdate;
        }

        public IEnumerable<IRobot> StatusUpdate { get; protected set; }
    }

    public class RobotEnteredBattleHandlerArgs : BattleEventArgs
    {
        public RobotEnteredBattleHandlerArgs(IEnumerable<IRobot> statusUpdate, IRobot robot)
            : base(statusUpdate)
        {
            Robot = robot;
        }

        public IRobot Robot { get; private set; }
    }


    public class BattleEndedEventArgs : BattleEventArgs
    {
        public BattleEndedEventArgs(ReasonBattleEnded reasonBattleEnded, IEnumerable<IRobot> statusUpdate)
            : base(statusUpdate)
        {
            Winner = null;
            Reason = reasonBattleEnded;
        }

        public BattleEndedEventArgs(ReasonBattleEnded reasonBattleEnded, IEnumerable<IRobot> statusUpdate, IRobot winner)
            : this(reasonBattleEnded, statusUpdate)
        {
            Winner = winner;
        }

        public ReasonBattleEnded Reason { get; private set; }

        public IRobot Winner { get; private set; }
    }

    public enum ReasonBattleEnded
    {
        WINNER,
        TIMEOUT,
        FORCED
    }
}