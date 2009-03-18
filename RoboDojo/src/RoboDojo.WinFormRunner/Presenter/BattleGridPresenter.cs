using System;
using System.Collections.Generic;
using System.ComponentModel;
using RoboDojo.Core.Battle;
using RoboDojo.Core.Robot;
using RoboDojo.WinFormRunner.View;

namespace RoboDojo.WinFormRunner.Presenter
{
    public class BattleGridPresenter
    {
        private readonly IBattleGridView _view;
        private readonly IBattle _battle;

        public BattleGridPresenter(IBattleGridView view, IBattle model)
        {
            _view = view;
            _view.RobotBindingList = new BindingList<IRobot>();
            _battle = model;

            _battle.OnRobotEnteredBattle += new RobotEnteredBattleHandler(_battle_OnRobotEnteredBattle);
        }

        void _battle_OnRobotEnteredBattle(object sender, RobotEnteredBattleHandlerArgs args)
        {
            _view.RobotBindingList.Add(args.Robot);
        }
    }
}