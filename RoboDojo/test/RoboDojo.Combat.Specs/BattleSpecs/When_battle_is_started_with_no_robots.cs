using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboDojo.Specs;

namespace RoboDojo.Combat.Specs.BattleSpecs
{
    [TestClass]
    public class When_battle_is_started_with_no_robots : AAA
    {
        Battle _battle;
        Rectangle rect = new Rectangle(0,0, 300,300);

        protected override void Arrange()
        {
            _battle = new Battle(rect);
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughRobotsToBattleException))]
        public void Then_there_should_be_an_error()
        {
            _battle.Start();
        }
    }

    
}
