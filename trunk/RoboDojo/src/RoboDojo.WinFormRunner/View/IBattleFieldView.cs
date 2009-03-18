using System.Drawing;
using RoboDojo.WinFormRunner.Presenter;

namespace RoboDojo.WinFormRunner.View
{
    public interface IBattleFieldControlView
    {
        Color BackGroundColor { get; }
        Rectangle BoundingRectangle { get; }
        Graphics GetGraphics();
        void UpdateGraphics(Graphics graphics);

        void InitPresenter(BattleFieldPresenter presenter);
    }
}