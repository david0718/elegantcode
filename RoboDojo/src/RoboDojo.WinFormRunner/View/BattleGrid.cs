using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RoboDojo.Core.Robot;
using RoboDojo.WinFormRunner.Presenter;

namespace RoboDojo.WinFormRunner.View
{
    public partial class BattleGrid : UserControl, IBattleGridView
    {
        private BattleGridPresenter _presenter;

        public BattleGrid()
        {
            InitializeComponent();
        }

        public BindingList<IRobot> RobotBindingList
        {
            get { return (BindingList<IRobot>)_dataGridView.DataSource; }
            set 
            {   
                _dataGridView.DataSource = value; 
            }
        }

        public void InitPresenter(BattleGridPresenter presenter)
        {
            if (presenter == null) throw new ArgumentNullException("presenter");
            _presenter = presenter;
        }
    }
}