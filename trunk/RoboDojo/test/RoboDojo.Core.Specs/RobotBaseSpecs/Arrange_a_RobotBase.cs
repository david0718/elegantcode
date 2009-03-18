using System.Drawing;
using Moq;
using RoboDojo.Core.ServiceInterfaces;
using RoboDojo.Core.Specs.Util;
using RoboDojo.Specs;

namespace RoboDojo.Core.Specs.RobotBaseSpecs
{
    public class Arrange_an_initialized_RobotBase
        : AAA
    {
        protected Point _destination;
        internal Mock<IMoveChecker> _mock_IBattleEntityMover;
        internal Mock<IBattleMapCreator> _mock_IBattleViewCreator;
        internal Point _pointOfOrigin;
        internal RobotBaseTestImplementation _robot;

        protected override void Arrange()
        {
            _mock_IBattleViewCreator = new Mock<IBattleMapCreator>();
            _pointOfOrigin = new Point(2, 2);
            _destination = new Point(0, 0);

            _robot = new RobotBaseTestImplementation();
            // _robot.Initialize(_mock_IBattleViewCreator.Object, new FakeMoverService_AlwaysCanMove(), _pointOfOrigin, Color.Green);
        }
    }
}