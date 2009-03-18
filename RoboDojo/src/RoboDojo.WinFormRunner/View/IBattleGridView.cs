using System.ComponentModel;
using RoboDojo.Core.Robot;
using RoboDojo.WinFormRunner.Presenter;

namespace RoboDojo.WinFormRunner.View
{
    public interface IBattleGridView
    {
        BindingList<IRobot> RobotBindingList { get; set; }
        void InitPresenter(BattleGridPresenter presenter);
    }
}