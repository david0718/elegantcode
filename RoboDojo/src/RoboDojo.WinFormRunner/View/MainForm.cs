using System;
using System.Drawing;
using System.Windows.Forms;
using RoboDojo.Combat;
using RoboDojo.WinFormRunner.Presenter;

namespace RoboDojo.WinFormRunner.View
{
    public partial class MainForm : Form, IMainFormView
    {
        private readonly MainFormPresenter _presenter;

        public MainForm()
        {
            InitializeComponent();

            Rectangle battleFieldRectangle = new Rectangle(0, 0, _battleField.Width, _battleField.Height);
            var battle = new Battle(battleFieldRectangle); 
            
            _presenter = new MainFormPresenter(this, battle);

            InitChildPresenters(battle);
        }

        private void InitChildPresenters(IBattle battle)
        {
            _battleField.InitPresenter(new BattleFieldPresenter(_battleField, battle));
            _battleGrid.InitPresenter(new BattleGridPresenter(_battleGrid, battle));
        }

        private void _btnStartBattle_Click(object sender, EventArgs e)
        {
            _presenter.StartTheBattle();
            
        }

        private void _btnEndBattle_Click(object sender, EventArgs e)
        {
            _presenter.StopTheBattle();
        }

        private void _btnLoadRobot_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != this._openFileDialog.ShowDialog(this))
                return;

            foreach (var fileName in _openFileDialog.FileNames)
            {
                _presenter.LoadRobotsFromDLL(fileName);
            }
        }

        public void ShowBattleRunning()
        {
            _btnStartBattle.Enabled = false;
            _btnEndBattle.Enabled = true;
            _btnLoadRobot.Enabled = false;
        }

        public void ShowReadyForBattle()
        {
            _btnStartBattle.Enabled = true;
            _btnEndBattle.Enabled = false;
            
        }

        public void ShowNotReadyForBattle()
        {
            _btnStartBattle.Enabled = false;
            _btnEndBattle.Enabled = false;
            _btnLoadRobot.Enabled = true;
        }
    }
}