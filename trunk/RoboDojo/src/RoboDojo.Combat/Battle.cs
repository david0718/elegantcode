using System;
using System.Collections.Generic;
using System.Drawing;
using RoboDojo.Combat.Services;
using RoboDojo.Core.Battle;
using RoboDojo.Core.Robot;
using RoboDojo.Core.ServiceInterfaces;

namespace RoboDojo.Combat
{
    public partial class Battle : IBattle
    {
        // TODO: make this a simple IList?
        private readonly Dictionary<Guid, RobotBase> _robots;
        private readonly IBattleMapCreator _mapMakerService;
        private RobotPositioningService _robotPositioningService;
        
        public Battle(Rectangle battleField)
        {
            BattleField = battleField;

            IsRaging = false;

            _robots = new Dictionary<Guid, RobotBase>();
            _mapMakerService = new StandardBattleMapCreator(this);
            _robotPositioningService = new RobotPositioningService(this);
        }

        #region IBattle Members

        public Rectangle BattleField { get; private set; }
        public bool IsRaging { get; private set; }

        public void Start()
        {
            if (_robots.Count < 2)
                throw new NotEnoughRobotsToBattleException();
            InitializeTheRobots();
            
            IsRaging = true;

            InvokeOnBattleStarted();
        }

        public void TakeTurn()
        {
            if (IsRaging)
            {
                foreach (var robot in _robots.Values)
                {
                    robot.Run(_mapMakerService.CreateBattleMap(robot));
                }

                InvokeOnTurnComplete();

                if (ThereIsAWinner())
                    Stop(ReasonBattleEnded.WINNER);
            }
        }

        public void Stop(ReasonBattleEnded reasonBattleEnded)
        {
            IsRaging = false;
            InvokeOnBattleEnded(reasonBattleEnded);
        }

        public void SendInARobot(RobotBase robot)
        {
            _robots.Add(robot.ID, robot);
            InvokeOnRobotEnteredBattle(robot);
        }

        public IList<IRobot> GetRobots()
        {
            IList<IRobot> ibots = new List<IRobot>();
            foreach (var bot in _robots.Values)
            {
                ibots.Add(bot);
            }
            return ibots;
        }

        #endregion

        #region Helpers

        private bool ThereIsAWinner()
        {
            return GetTheWinner() != null;
        }

        // TODO: Refactor the heck out of this.
        private IRobot GetTheWinner()
        {
            int liveBots = 0;
            IRobot winner = null;

            foreach (var robot in _robots.Values)
            {
                if (robot.Energy > 0)
                {
                    // HACK: this is a bug, leaving it here on purpose for now.
                    liveBots++;
                    winner = robot;
                }
            }

            if (liveBots > 1)
                return null;

            return winner;
        }

        private void InitializeTheRobots()
        {
            foreach (var robot in _robots.Values)
            {
                robot.Initialize(new StandardBattleMapCreator(this), 
                                        new StandardMoveCheckerService(this),
                                        _robotPositioningService.PositionRobot(robot), 
                                        ColorGeneratorService.GetNextColor());
            }
        }

        #endregion
    }
}