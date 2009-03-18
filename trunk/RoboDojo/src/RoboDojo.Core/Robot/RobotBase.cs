using System;
using System.ComponentModel;
using System.Drawing;
using RoboDojo.Core.ServiceInterfaces;

namespace RoboDojo.Core.Robot
{
    public abstract partial class RobotBase : IRobot
    {
        // members off limits to implementers
        private IMoveChecker _moveChecker;
        private bool _hasMovedThisTurn;
        private bool _stillAlive;

        protected RobotBase()
        {
            FootPrint = new Rectangle(0, 0, 20, 20);            
        }

        // Properties read-only to all
        private int _energy;
        public int Energy
        {
            get { return _energy; }
            private set
            {
                _energy = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("Energy"));
            }
        }

        private Color _displayColor;
        public Color DisplayColor
        {
            get { return _displayColor; }
            private set
            {
                _displayColor = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("DisplayColor"));
            }
        }

        // Properties for the implementer to set
        public string Author { get; protected set; }
        public Guid ID { get; protected set; }
        public string Name { get; protected set; }
        public string Version { get; protected set; }
        
        private Rectangle _footPrint;
        public Rectangle FootPrint
        {
            get { return _footPrint; }
            private set
            {
                _footPrint = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("FootPrint"));
            }
        }

        // the master function of the robot
        protected abstract void TakeATurn(IBattleMap battleMap);
        
        public void Initialize( IBattleMapCreator battleMapCreator, 
                                IMoveChecker moveChecker,
                                Rectangle startSpace,
                                Color displayColor)
        {
            if (battleMapCreator == null) throw new ArgumentNullException("battleMapCreator");
            if (moveChecker == null) throw new ArgumentNullException("moveChecker");
            
            _moveChecker = moveChecker;
            _stillAlive = true;

            DisplayColor = displayColor;
            Energy = 100;
            FootPrint = startSpace; 
        }

        public void Run(IBattleMap mapOfWhatTheBotCanSee)
        {
            if (!_stillAlive)
                return;

            _hasMovedThisTurn = false;
            this.TakeATurn(mapOfWhatTheBotCanSee);
        }

        protected void Move(Direction direction)
        {
            if (_hasMovedThisTurn || !_stillAlive) return;
            
            _hasMovedThisTurn = true;

            if (_moveChecker.CanMoveToThisDestination(this, direction))
            {
                FootPrint = FootPrint.Move(direction);
            }
            else
            {
                LoseEnergy(3);
                //
            }
        }

        
        private void LoseEnergy(int energyToLose)
        {
            Energy = Energy - energyToLose;
            if (Energy < 1)
            {
                _stillAlive = false;
                Energy = 0;
            }
        }

        public override string ToString()
        {
            return Name + ":" + ID;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler Handler = PropertyChanged;
            if (Handler != null) Handler(this, e);
        }
    }
}