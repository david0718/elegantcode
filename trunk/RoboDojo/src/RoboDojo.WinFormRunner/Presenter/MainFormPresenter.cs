using System;
using System.Windows.Forms;
using RoboDojo.Core.Battle;
using RoboDojo.WinFormRunner.Service;
using RoboDojo.WinFormRunner.View;

namespace RoboDojo.WinFormRunner.Presenter
{
    public class MainFormPresenter : IDisposable
    {
        private readonly RobotLoader _loader;
        private readonly IBattle _theBattle;
        private readonly Timer _timer;
        private readonly IMainFormView _view;

        public MainFormPresenter(IMainFormView view, IBattle theBattle)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (theBattle == null) throw new ArgumentNullException("theBattle");

            _view = view;
            _view.ShowNotReadyForBattle();

            _theBattle = theBattle;
            WireUpBattleEvents();

            _loader = new RobotLoader();
            WireUpLoaderEvents();

            _timer = new Timer {Interval = 1};
            _timer.Tick += PulseTheGame;
        }

        #region IDisposable Members

        public void Dispose()
        {
            _timer.Dispose();
        }

        #endregion

        public void StartTheBattle()
        {
            if (_theBattle.IsRaging)
                return;

            _view.ShowBattleRunning();

            _theBattle.Start();
            _timer.Start();
        }

        public void StopTheBattle()
        {
            if (!_theBattle.IsRaging)
                return;

            _timer.Stop();
            _theBattle.Stop(ReasonBattleEnded.FORCED);
        }

        public void LoadRobotsFromDLL(string fileName)
        {
            _loader.LoadRobotAssembly(fileName);
        }

        #region EventHandlers

        private void PulseTheGame(object sender, EventArgs e)
        {
            if (_theBattle.IsRaging)
            {
                _theBattle.TakeTurn();
            }
        }

        private void loader_OnRobotLoaded(object sender, RobotLoader.RobotLoadedHandlerArgs args)
        {
            _theBattle.SendInARobot(args.Robot);
            _view.ShowReadyForBattle();
        }

        private void loader_OnTypeLoadedErrored(object sender, RobotLoader.TypeLoadErrorHandlerArgs args)
        {
            string msg = string.Format("Error loading type: {0}\n\n{1}\n\n{2}", args.TypeName, args.Exception.Message,
                                       args.Exception.StackTrace);
            _view.ShowErrorMessage(msg);
        }

        private void loader_OnAssemblyLoadErrored(object sender, RobotLoader.AssemblyLoadErrorHandlerArgs args)
        {
            string msg = string.Format("Error loading DLL: {0}\n\n{1}", args.AssemblyFilename, args.Exception.Message);
            _view.ShowErrorMessage(msg);
        }

        private void TheBattle_OnBattleStarted(object sender, BattleEventArgs args)
        {
            _view.ShowBattleRunning();
        }

        private void TheBattle_OnBattleEnded(object sender, BattleEndedEventArgs args)
        {
            string msg = GetEndGameMessage(args);
            MessageBox.Show(msg);

            _view.ShowReadyForBattle();
        }

        
        #endregion

        #region Some Helpers

        private string GetEndGameMessage(BattleEndedEventArgs args)
        {
            string msg = "Battle Complete: ";
            switch (args.Reason)
            {
                case ReasonBattleEnded.FORCED:
                    msg += "Manual Stop.";
                    break;

                case ReasonBattleEnded.TIMEOUT:
                    msg += "Timeout.";
                    break;

                case ReasonBattleEnded.WINNER:
                    msg += "Winner -> " + args.Winner.Name;
                    break;

                default:
                    msg += "No idea why :)";
                    break;
            }
            return msg;
        }
        
        private void WireUpLoaderEvents()
        {
            _loader.OnRobotLoaded += loader_OnRobotLoaded;
            _loader.OnAssemblyLoadErrored += loader_OnAssemblyLoadErrored;
            _loader.OnTypeLoadedErrored += loader_OnTypeLoadedErrored;
        }

        private void WireUpBattleEvents()
        {
            _theBattle.OnBattleEnded += TheBattle_OnBattleEnded;
            _theBattle.OnBattleStarted += TheBattle_OnBattleStarted;
        }

        #endregion
    }
}