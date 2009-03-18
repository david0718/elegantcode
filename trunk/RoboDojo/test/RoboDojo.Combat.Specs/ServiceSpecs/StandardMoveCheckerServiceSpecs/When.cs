using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboDojo.Specs;

namespace RoboDojo.Combat.Specs.ServiceSpecs.StandardMoveCheckerServiceSpecs
{
    [TestClass]
    public class When_DO_SOMETHING_TO_THE_SUT 
        : AAA
    {
        IBattle _battle;
        StandardMoveCheckerService _service;
        Rectangle _battleFieldRect = new Rectangle(0, 0, 300, 300);
        
        protected override void Arrange()
        {
            _battle = new Battle(_battleFieldRect);
            _service = new StandardMoveCheckerService(_battle);
        }
    }

}
