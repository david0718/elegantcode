using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoboDojo.Specs
{
    public class GivenWhenThen
    {
        [TestInitialize]
        public void MainSetup()
        {
            Given();
            When();
        }

        [TestCleanup]
        public void MainTeardown()
        {
            CleanUp();
        }

        protected virtual void Given()
        {
        }

        protected virtual void When()
        {
        }

        protected virtual void CleanUp()
        {
        }
    }
}