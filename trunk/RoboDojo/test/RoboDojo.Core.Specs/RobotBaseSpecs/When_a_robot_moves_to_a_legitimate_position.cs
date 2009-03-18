using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboDojo.Core.Robot;
using RoboDojo.Specs;

namespace RoboDojo.Core.Specs.RobotBaseSpecs
{
    [TestClass]
    public class When_a_robot_moves_to_a_legitimate_position
        : Arrange_an_initialized_RobotBase
    {
        protected override void Act()
        {
            _robot.Move_ExternalAccessor(Direction.Up);
        }

        [TestMethod]
        public void Then_its_position_should_change_to_the_new_position()
        {
            _robot.FootPrint.X.ShouldEqual(_destination.X);
            _robot.FootPrint.Y.ShouldEqual(_destination.X);
        }
    }
}