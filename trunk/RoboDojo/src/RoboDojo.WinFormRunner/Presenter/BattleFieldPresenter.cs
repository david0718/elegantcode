using System.Collections.Generic;
using System.Drawing;
using RoboDojo.Core.Battle;
using RoboDojo.Core.Robot;
using RoboDojo.WinFormRunner.View;

namespace RoboDojo.WinFormRunner.Presenter
{
    public class BattleFieldPresenter
    {
        private readonly IBattleFieldControlView _view;
        private readonly IBattle _battle;

        public BattleFieldPresenter(IBattleFieldControlView view, IBattle battle)
        {
            _view = view;
            _battle = battle;

            _battle.OnBattleStarted += BattleEventHandler;
            _battle.OnTurnComplete += BattleEventHandler;
            _battle.OnBattleEnded += BattleEventHandler;
            _battle.OnRobotEnteredBattle += BattleEventHandler;
        }

        private void DrawRobots(IEnumerable<IRobot> robots)
        {
            Graphics graphicsToDrawOn = _view.GetGraphics();
            graphicsToDrawOn.Clear(_view.BackGroundColor);

            foreach (var robot in robots)
            {
                DrawRobot(robot, graphicsToDrawOn);
            }
        }

        private void DrawRobot(IRobot robot, Graphics drawingSurface)
        {
            var solidBrush = new SolidBrush(robot.DisplayColor);
            drawingSurface.FillRectangle(solidBrush, robot.FootPrint);
            solidBrush.Dispose();
        }

        void BattleEventHandler(object sender, BattleEventArgs args)
        {
            DrawRobots(args.StatusUpdate);
        }
    }
}