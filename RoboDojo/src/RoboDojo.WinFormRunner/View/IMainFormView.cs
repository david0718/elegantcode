using RoboDojo.WinFormRunner.Presenter;

namespace RoboDojo.WinFormRunner.View
{
    public interface IMainFormView
    {
        void ShowErrorMessage(string message);
        void ShowBattleRunning();
        void ShowReadyForBattle();
        void ShowNotReadyForBattle();
    }
}