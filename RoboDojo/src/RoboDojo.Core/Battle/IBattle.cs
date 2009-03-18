using System.Collections.Generic;
using System.Drawing;
using RoboDojo.Core.Battle;
using RoboDojo.Core.Robot;

public interface IBattle
{
    bool IsRaging { get; }
    Rectangle BattleField { get; }

    void SendInARobot(RobotBase robot);
    
    void Start();
    void TakeTurn();
    void Stop(ReasonBattleEnded reason);

    IList<IRobot> GetRobots();

    event TurnCompleteHandler OnTurnComplete;
    event RobotEnteredBattleHandler OnRobotEnteredBattle;
    event BattleStartedHandler OnBattleStarted;
    event BattleEndedHandler OnBattleEnded;
}