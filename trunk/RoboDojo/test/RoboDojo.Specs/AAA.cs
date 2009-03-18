using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoboDojo.Specs
{
    public class AAA
    {
        [TestInitialize]
        public void MainSetup()
        {
            Arrange();
            Act();
        }

        [TestCleanup]
        public void MainTeardown()
        {
            CleanUp();
        }

        protected virtual void Act()
        {
        }

        protected virtual void Arrange()
        {
        }

        protected virtual void CleanUp()
        {
        }
    }
}