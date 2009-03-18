using System;
using System.Drawing;
using System.Windows.Forms;
using RoboDojo.WinFormRunner.Presenter;
using RoboDojo.WinFormRunner.View;

namespace RoboDojo.WinFormRunner.View
{
    public partial class BattleField : UserControl, IBattleFieldControlView
    {
        private BattleFieldPresenter _presenter;
            
        public BattleField()
        {
            InitializeComponent();
        }

        public Color BackGroundColor
        {
            get { return this.BackColor; }
        }

        public void UpdateGraphics(Graphics graphics)
        {
            this.RaisePaintEvent(this, new PaintEventArgs(graphics, this.BoundingRectangle));
        }

        public void InitPresenter(BattleFieldPresenter presenter)
        {
            if (presenter == null) throw new ArgumentNullException("presenter");
            _presenter = presenter;
        }

        public Graphics GetGraphics()
        {
            return this.CreateGraphics();
        }

        public Rectangle BoundingRectangle
        {
            get { return this.Bounds; }
        }

    }
}