using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RoboDojo.Specs
{
    public class ContextSpecification
    {
        [TestInitialize]
        public void MainSetup()
        {
            Context();
            Because();
        }

        [TestCleanup]
        public void MainTeardown()
        {
            CleanUp();
        }

        protected virtual void Because()
        {
        }

        protected virtual void Context()
        {
        }

        protected virtual void CleanUp()
        {
        }
    }
}